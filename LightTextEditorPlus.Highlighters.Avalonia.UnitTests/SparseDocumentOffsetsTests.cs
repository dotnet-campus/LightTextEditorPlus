using LightTextEditorPlus.Core.Utils;
using LightTextEditorPlus.Highlighters;

namespace LightTextEditorPlus.Highlighters.Avalonia.UnitTests;

public class SparseDocumentOffsetsTests
{
    [Theory]
    [InlineData("")]
    [InlineData("中文abc\n结束")]
    [InlineData("a\r\nb\rc\nd\r\n")]
    [InlineData("a\U0001F600b\U0001F601\r\n末尾")]
    public void EveryIndexMatchesExistingConverter(string text)
    {
        var offsets = SparseDocumentOffsets.Create(text);
        var indices = Enumerable.Range(0, text.Length + 1).Reverse().ToArray();
        Assert.Equal(indices.Select(i => TextIndexConverter.ConvertUtf16IndexToDocumentOffset(text, i).Offset),
            indices.Select(i => SparseDocumentOffsets.Convert(offsets, text.Length, i)));
    }

    [Fact]
    public void MalformedSurrogatesMatchExistingConverter()
    {
        var text = new string(['\uD800', 'a', '\uDC00', '\uD800', '\uD800', '\uDC00', '\r', '\n']);
        var offsets = SparseDocumentOffsets.Create(text);
        Assert.Equal(Enumerable.Range(0, text.Length + 1).Select(i => TextIndexConverter.ConvertUtf16IndexToDocumentOffset(text, i).Offset),
            Enumerable.Range(0, text.Length + 1).Select(i => SparseDocumentOffsets.Convert(offsets, text.Length, i)));
    }

    [Fact]
    public void OrdinaryTextUsesSharedEmptyArray()
    {
        Assert.Same(Array.Empty<int>(), SparseDocumentOffsets.Create(new string('文', 200000) + "\n"));
    }

    [Fact]
    public void OnlyCollapsedPairsOccupyStorage()
    {
        Assert.Equal(new[] { 3, 6 }, SparseDocumentOffsets.Create("a\r\nb\U0001F600end"));
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(4)]
    public void InvalidIndexThrows(int index)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => SparseDocumentOffsets.Convert([], 3, index));
    }
}
