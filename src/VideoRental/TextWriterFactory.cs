namespace VideoRental;

public static class TextWriterFactory
{
    private static TextWriter? _textWriter;

    public static TextWriter GetTextWriter(string path) =>
        _textWriter ?? new StreamWriter(path, true);

    public static void SetTextWriter(TextWriter? textWriter) =>
        _textWriter = textWriter;
}