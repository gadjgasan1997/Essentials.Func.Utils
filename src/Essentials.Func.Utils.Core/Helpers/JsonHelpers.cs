using Newtonsoft.Json;

namespace Essentials.Func.Utils.Helpers;

/// <summary>
/// Хелперы для работы с Json
/// </summary>
public static class JsonHelpers
{
    private static readonly JsonSerializerSettings _settings = new()
    {
        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
    };

    /// <summary>
    /// Серилизует объект в строку
    /// </summary>
    /// <param name="obj">Объект</param>
    /// <typeparam name="T">Тип объекта</typeparam>
    /// <returns>Строка</returns>
    public static string Serialize<T>(T? obj) => JsonConvert.SerializeObject(obj, _settings);
}