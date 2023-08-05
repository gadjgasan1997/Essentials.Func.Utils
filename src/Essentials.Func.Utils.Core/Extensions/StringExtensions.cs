namespace Essentials.Func.Utils.Extensions;

/// <summary>
/// Методы расширения для строк
/// </summary>
public static class StringExtensions
{
    /// <summary>
    /// Убирает все пробелы в строке
    /// </summary>
    /// <param name="string">Исходная строка</param>
    /// <returns>Строка без пробелов</returns>
    public static string FullTrim(this string @string) => @string.Replace(" ", string.Empty);
}