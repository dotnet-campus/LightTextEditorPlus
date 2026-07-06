using System;
using System.Collections;
using System.Collections.Generic;
using LightTextEditorPlus.Core.Document;
using LightTextEditorPlus.Core.Document.Segments;
using LightTextEditorPlus.Core.Primitive;
using LightTextEditorPlus.Core.Rendering;

namespace LightTextEditorPlus.Core.Primitive.Collections;

/// <summary>
/// 段落渲染信息只读列表
/// </summary>
public readonly struct ParagraphRenderInfoReadonlyList : IReadOnlyList<ParagraphRenderInfo>
{
    internal ParagraphRenderInfoReadonlyList(RenderInfoProvider renderInfoProvider)
    {
        ArgumentNullException.ThrowIfNull(renderInfoProvider);
        _renderInfoProvider = renderInfoProvider;
        _paragraphList = _renderInfoProvider.TextEditor.DocumentManager.ParagraphManager.GetParagraphList();
    }

    private readonly RenderInfoProvider _renderInfoProvider;
    private readonly IReadOnlyList<ParagraphData> _paragraphList;

    /// <inheritdoc />
    public int Count => _paragraphList.Count;

    /// <inheritdoc />
    public ParagraphRenderInfo this[int index] => ToParagraphRenderInfo(index);

    /// <summary>
    /// Returns an enumerator that iterates through the collection
    /// </summary>
    /// <returns></returns>
    public Enumerator GetEnumerator()
    {
        return new Enumerator(this);
    }

    IEnumerator<ParagraphRenderInfo> IEnumerable<ParagraphRenderInfo>.GetEnumerator()
    {
        return GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    internal ParagraphRenderInfo ToParagraphRenderInfo(int index)
    {
        var list = _paragraphList;
        _renderInfoProvider.VerifyNotDirty();
        var paragraphData = list[index];
        return new ParagraphRenderInfo(new ParagraphIndex(index), paragraphData, _renderInfoProvider);
    }

    /// <summary>
    /// 枚举器，用于迭代段落渲染信息
    /// </summary>
    public struct Enumerator : IEnumerator<ParagraphRenderInfo>
    {
        internal Enumerator(ParagraphRenderInfoReadonlyList list)
        {
            List = list;
            _index = -1;
        }

        private ParagraphRenderInfoReadonlyList List { get; }

        private int _index;

        /// <inheritdoc />
        public void Dispose()
        {
        }

        /// <inheritdoc />
        public bool MoveNext()
        {
            _index++;
            if (_index >= List.Count)
            {
                return false;
            }

            return true;
        }

        /// <inheritdoc />
        public void Reset()
        {
            _index = -1;
        }

        /// <inheritdoc />
        public ParagraphRenderInfo Current => List.ToParagraphRenderInfo(_index);
        object IEnumerator.Current => Current;
    }
}
