using System;

namespace LightTextEditorPlus.Highlighters;

internal static class SparseDocumentOffsets
{
    internal static int[] Create(string text)
    {
        var count = 0;
        for (var i = 1; i < text.Length; i++)
        {
            if (IsCollapsedPair(text, i))
                count++;
        }
        if (count == 0)
            return Array.Empty<int>();

        var ends = new int[count];
        var position = 0;
        for (var i = 1; i < text.Length; i++)
        {
            if (IsCollapsedPair(text, i))
                ends[position++] = i + 1;
        }
        return ends;
    }

    internal static int Convert(int[] collapsedPairEnds, int textLength, int utf16Index)
    {
        if ((uint) utf16Index > (uint) textLength)
            throw new ArgumentOutOfRangeException(nameof(utf16Index));

        // 仅在完整跨过 CRLF 或代理对时减一，保留代理对中间索引的既有语义。
        var low = 0;
        var high = collapsedPairEnds.Length;
        while (low < high)
        {
            var middle = low + (high - low) / 2;
            if (collapsedPairEnds[middle] <= utf16Index)
                low = middle + 1;
            else
                high = middle;
        }
        return utf16Index - low;
    }

    private static bool IsCollapsedPair(string text, int index) =>
        (text[index - 1] == '\r' && text[index] == '\n') ||
        (char.IsHighSurrogate(text[index - 1]) && char.IsLowSurrogate(text[index]));
}
