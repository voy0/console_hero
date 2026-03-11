using System.Text.RegularExpressions;

namespace console_hero;

// Klasa musi być static, żeby metody rozszerzające zadziałały
public static class StringExtensions
{
    // Ten Regex rozpoznaje każdy kod koloru ANSI (te zaczynające się od \x1b[ i kończące na m)
    private static readonly Regex AnsiRegex = new Regex("\x1b\\[[0-9;]*m", RegexOptions.Compiled);

    // Zwraca długość tekstu BEZ ukrytych znaków kolorów
    public static int GetVisibleLength(this string text)
    {
        if (string.IsNullOrEmpty(text)) return 0;
        
        // Zastępujemy kody kolorów pustym stringiem i liczymy długość tego, co zostało
        return AnsiRegex.Replace(text, "").Length;
    }

    // Nasz nowy, mądrzejszy PadRight!
    public static string PadRightVisible(this string text, int totalWidth, char paddingChar = ' ')
    {
        int visibleLength = text.GetVisibleLength();
        int paddingNeeded = totalWidth - visibleLength;
        
        if (paddingNeeded <= 0) return text; // Jeśli tekst jest już za długi, zwracamy go bez zmian
        
        // Zwracamy oryginalny (pokolorowany) tekst + wyliczoną ilość spacji
        return text + new string(paddingChar, paddingNeeded);
    }

    // Dodajmy też PadLeft dla kompletności, jakbyś potrzebował wyrównywać do prawej
    public static string PadLeftVisible(this string text, int totalWidth, char paddingChar = ' ')
    {
        int visibleLength = text.GetVisibleLength();
        int paddingNeeded = totalWidth - visibleLength;
        
        if (paddingNeeded <= 0) return text;
        
        return new string(paddingChar, paddingNeeded) + text;
    }
}