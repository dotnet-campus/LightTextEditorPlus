using Avalonia;
using LightTextEditorPlus.Core.Primitive;

namespace LightTextEditorPlus.Utils;

/// <summary>
/// Provides extension methods for converting between Avalonia and LightTextEditorPlus types.
/// </summary>
public static class TextUnitConverter
{
    /// <summary>
    /// Converts an Avalonia <see cref="Point"/> to a LightTextEditorPlus <see cref="TextPoint"/>.
    /// </summary>
    /// <param name="point">The Avalonia <see cref="Point"/> to convert.</param>
    /// <returns>A <see cref="TextPoint"/> representing the same coordinates.</returns>
    internal static TextPoint ToTextPoint(this Point point)
        => new(point.X, point.Y);

    /// <summary>
    /// Converts a LightTextEditorPlus <see cref="TextPoint"/> to an Avalonia <see cref="Point"/>.
    /// </summary>
    /// <param name="textPoint">The LightTextEditorPlus <see cref="TextPoint"/> to convert.</param>
    /// <returns>A <see cref="Point"/> representing the same coordinates.</returns>
    public static Point ToAvaloniaPoint(this TextPoint textPoint)
        => new(textPoint.X, textPoint.Y);

    /// <summary>
    /// Converts an Avalonia <see cref="Rect"/> to a LightTextEditorPlus <see cref="TextRect"/>.
    /// </summary>
    /// <param name="rect">The Avalonia <see cref="Rect"/> to convert.</param>
    /// <returns>A <see cref="TextRect"/> representing the same rectangle.</returns>
    internal static TextRect ToTextRect(this Rect rect)
        => TextRect.FromLeftTopRightBottom(rect.Left, rect.Top, rect.Right, rect.Bottom);

    /// <summary>
    /// Converts a LightTextEditorPlus <see cref="TextRect"/> to an Avalonia <see cref="Rect"/>.
    /// </summary>
    /// <param name="textRect">The LightTextEditorPlus <see cref="TextRect"/> to convert.</param>
    /// <returns>A <see cref="Rect"/> representing the same rectangle.</returns>
    public static Rect ToAvaloniaRect(this TextRect textRect)
        => new Rect(textRect.X, textRect.Y, textRect.Width, textRect.Height);
}