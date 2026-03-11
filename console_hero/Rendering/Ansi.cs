namespace console_hero;

public static class Ansi
{
    // ================= RESET =================
    // ZAWSZE dodawaj to na końcu stringa, żeby zresetować konsolę!
    public const string Reset = "\x1b[0m";

    // ================= STYLE =================
    public const string Bold = "\x1b[1m";          // Pogrubienie (lub jaśniejszy kolor w starych konsolach)
    public const string Dim = "\x1b[2m";           // Przygaszony tekst
    public const string Italic = "\x1b[3m";        // Kursywa
    public const string Underline = "\x1b[4m";     // Podkreślenie
    public const string SlowBlink = "\x1b[5m";     // Miganie (super do ostrzeżeń o niskim HP!)
    public const string RapidBlink = "\x1b[6m";    // Szybkie miganie
    public const string Invert = "\x1b[7m";        // Zamienia kolor tła z kolorem tekstu
    public const string Hidden = "\x1b[8m";        // Ukryty tekst (np. do haseł)
    public const string Strikethrough = "\x1b[9m"; // Przekreślenie

    // ============ KOLORY TEKSTU (Foreground) ============
    public const string FgBlack = "\x1b[30m";
    public const string FgRed = "\x1b[31m";
    public const string FgGreen = "\x1b[32m";
    public const string FgYellow = "\x1b[33m";
    public const string FgBlue = "\x1b[34m";
    public const string FgMagenta = "\x1b[35m";    
    public const string FgCyan = "\x1b[36m";       
    public const string FgWhite = "\x1b[37m";

    // ======== JASNE KOLORY TEKSTU (Bright Foreground) ========
    public const string FgBrightBlack = "\x1b[90m"; 
    public const string FgBrightRed = "\x1b[91m";
    public const string FgBrightGreen = "\x1b[92m";
    public const string FgBrightYellow = "\x1b[93m";
    public const string FgBrightBlue = "\x1b[94m";
    public const string FgBrightMagenta = "\x1b[95m"; 
    public const string FgBrightCyan = "\x1b[96m";
    public const string FgBrightWhite = "\x1b[97m";

    // ============ KOLORY TŁA (Background) ============
    public const string BgBlack = "\x1b[40m";
    public const string BgRed = "\x1b[41m";
    public const string BgGreen = "\x1b[42m";
    public const string BgYellow = "\x1b[43m";
    public const string BgBlue = "\x1b[44m";
    public const string BgMagenta = "\x1b[45m";
    public const string BgCyan = "\x1b[46m";
    public const string BgWhite = "\x1b[47m";

    // ======== JASNE KOLORY TŁA (Bright Background) ========
    public const string BgBrightBlack = "\x1b[100m";
    public const string BgBrightRed = "\x1b[101m";
    public const string BgBrightGreen = "\x1b[102m";
    public const string BgBrightYellow = "\x1b[103m";
    public const string BgBrightBlue = "\x1b[104m";
    public const string BgBrightMagenta = "\x1b[105m";
    public const string BgBrightCyan = "\x1b[106m";
    public const string BgBrightWhite = "\x1b[107m";

    // ============ MAGIA: 16 MILIONÓW KOLORÓW (RGB) ============
    // Pozwala na użycie dowolnego koloru z palety RGB (Red, Green, Blue od 0 do 255)
    public static string FgRgb(int r, int g, int b) => $"\x1b[38;2;{r};{g};{b}m";
    public static string BgRgb(int r, int g, int b) => $"\x1b[48;2;{r};{g};{b}m";
}