using System.Diagnostics.CodeAnalysis;
using LanguageExt;
using LanguageExt.Common;

namespace Essentials.Func.Utils.Core.Extensions;

/// <summary>
/// Методы расширения для монады Validation
/// </summary>
[SuppressMessage("ReSharper", "IdentifierTypo")]
[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
public static class ValidationExtensions
{
    /// <summary>
    /// Вызывает делегат func в случае успешого статуса монады
    /// </summary>
    /// <param name="validation">Объект validation</param>
    /// <param name="func">Делегат</param>
    /// <typeparam name="TValue">Тип значения в монаде</typeparam>
    /// <typeparam name="TResult">Тип результата</typeparam>
    /// <returns></returns>
    public static Task<Validation<Error, TResult>> DefaultBindAsync<TValue, TResult>(
        this Validation<Error, TValue> validation,
        Func<TValue, Validation<Error, TResult>> func)
    {
        return validation.Bind(func).AsTask();
    }
    
    /// <summary>
    /// Вызывает делегат func в случае успешого статуса монады
    /// </summary>
    /// <param name="task">Задача с объектом validation</param>
    /// <param name="func">Делегат</param>
    /// <typeparam name="TValue">Тип значения в монаде</typeparam>
    /// <typeparam name="TResult">Тип результата</typeparam>
    /// <returns></returns>
    public static Task<Validation<Error, TResult>> DefaultBindAsync<TValue, TResult>(
        this Task<Validation<Error, TValue>> task,
        Func<TValue, Validation<Error, TResult>> func)
    {
        return task.Result.DefaultBindAsync(func);
    }

    /// <summary>
    /// Вызывает делегат func в случае успешого статуса монады
    /// </summary>
    /// <param name="validation">Объект validation</param>
    /// <param name="func">Делегат</param>
    /// <typeparam name="TValue">Тип значения в монаде</typeparam>
    /// <typeparam name="TResult">Тип результата</typeparam>
    /// <returns></returns>
    public static Task<Validation<Error, TResult>> DefaultBindAsync<TValue, TResult>(
        this Validation<Error, TValue> validation,
        Func<TValue, Task<Validation<Error, TResult>>> func)
    {
        return validation.DefaultBindAsync(value => func(value).Result);
    }

    /// <summary>
    /// Вызывает делегат func в случае успешого статуса монады
    /// </summary>
    /// <param name="task">Задача с объектом validation</param>
    /// <param name="func">Делегат</param>
    /// <typeparam name="TValue">Тип значения в монаде</typeparam>
    /// <typeparam name="TResult">Тип результата</typeparam>
    /// <returns></returns>
    public static Task<Validation<Error, TResult>> DefaultBindAsync<TValue, TResult>(
        this Task<Validation<Error, TValue>> task,
        Func<TValue, Task<Validation<Error, TResult>>> func)
    {
        return task.Result.DefaultBindAsync(func);
    }

    /// <summary>
    /// Вызывает делегат func в случае успешого статуса монады
    /// </summary>
    /// <param name="validation">Объект validation</param>
    /// <param name="func">Делегат</param>
    /// <typeparam name="TValue">Тип значения в монаде</typeparam>
    /// <typeparam name="TResult">Тип результата</typeparam>
    /// <returns></returns>
    public static Task<Validation<Error, TResult>> DefaultBindAsync<TValue, TResult>(
        this Validation<Error, TValue> validation,
        Func<TValue, TResult> func)
    {
        return validation.Bind<TResult>(value => func(value)).AsTask();
    }

    /// <summary>
    /// Вызывает делегат func в случае успешого статуса монады
    /// </summary>
    /// <param name="task">Задача с объектом validation</param>
    /// <param name="func">Делегат</param>
    /// <typeparam name="TValue">Тип значения в монаде</typeparam>
    /// <typeparam name="TResult">Тип результата</typeparam>
    /// <returns></returns>
    public static Task<Validation<Error, TResult>> DefaultBindAsync<TValue, TResult>(
        this Task<Validation<Error, TValue>> task,
        Func<TValue, TResult> func)
    {
        return task.Result.DefaultBindAsync(func);
    }

    /// <summary>
    /// Вызывает делегат func в случае успешого статуса монады
    /// </summary>
    /// <param name="validation">Объект validation</param>
    /// <param name="func">Делегат</param>
    /// <typeparam name="TValue">Тип значения в монаде</typeparam>
    /// <typeparam name="TResult">Тип результата</typeparam>
    /// <returns></returns>
    public static Task<Validation<Error, TResult>> DefaultBindAsync<TValue, TResult>(
        this Validation<Error, TValue> validation,
        Func<TValue, Task<TResult>> func)
    {
        return validation.DefaultBindAsync(value => func(value).Result);
    }

    /// <summary>
    /// Вызывает делегат func в случае успешого статуса монады
    /// </summary>
    /// <param name="task">Задача с объектом validation</param>
    /// <param name="func">Делегат</param>
    /// <typeparam name="TValue">Тип значения в монаде</typeparam>
    /// <typeparam name="TResult">Тип результата</typeparam>
    /// <returns></returns>
    public static Task<Validation<Error, TResult>> DefaultBindAsync<TValue, TResult>(
        this Task<Validation<Error, TValue>> task,
        Func<TValue, Task<TResult>> func)
    {
        return task.Result.DefaultBindAsync(func);
    }

    /// <summary>
    /// Вызывает делегат Succ или Fail в зависимости от статуса монады
    /// </summary>
    /// <param name="validation">Объект validation</param>
    /// <param name="Succ">Делегат, вызывающийся в случае статуса успеха</param>
    /// <param name="Fail">Делегат, вызывающийся в случае статуса ошибки</param>
    /// <typeparam name="TValue">Тип значения в монаде</typeparam>
    /// <typeparam name="TResult">Тип результата</typeparam>
    /// <returns></returns>
    public static Task<TResult> DefaultMatchAsync<TValue, TResult>(
        this Validation<Error, TValue> validation,
        Func<TValue, TResult> Succ,
        Func<Seq<Error>, TResult> Fail)
        where TResult : notnull
    {
        return validation.Match(Succ, Fail).AsTask();
    }

    /// <summary>
    /// Вызывает делегат Succ или Fail в зависимости от статуса монады
    /// </summary>
    /// <param name="task">Задача с объектом validation</param>
    /// <param name="Succ">Делегат, вызывающийся в случае статуса успеха</param>
    /// <param name="Fail">Делегат, вызывающийся в случае статуса ошибки</param>
    /// <typeparam name="TValue">Тип значения в монаде</typeparam>
    /// <typeparam name="TResult">Тип результата</typeparam>
    /// <returns></returns>
    public static Task<TResult> DefaultMatchAsync<TValue, TResult>(
        this Task<Validation<Error, TValue>> task,
        Func<TValue, TResult> Succ,
        Func<Seq<Error>, TResult> Fail)
        where TResult : notnull
    {
        return task.Result.DefaultMatchAsync(Succ, Fail);
    }

    /// <summary>
    /// Вызывает делегат Succ или Fail в зависимости от статуса монады, не проверяя результат на null
    /// </summary>
    /// <param name="validation">Объект validation</param>
    /// <param name="Succ">Делегат, вызывающийся в случае статуса успеха</param>
    /// <param name="Fail">Делегат, вызывающийся в случае статуса ошибки</param>
    /// <typeparam name="TValue">Тип значения в монаде</typeparam>
    /// <typeparam name="TResult">Тип результата</typeparam>
    /// <returns></returns>
    public static Task<TResult?> DefaultMatchUnsafeAsync<TValue, TResult>(
        this Validation<Error, TValue> validation,
        Func<TValue, TResult?> Succ,
        Func<Seq<Error>, TResult?> Fail)
    {
        return validation.MatchUnsafe(Succ, Fail).AsTask();
    }

    /// <summary>
    /// Вызывает делегат Succ или Fail в зависимости от статуса монады, не проверяя результат на null
    /// </summary>
    /// <param name="task">Задача с объектом validation</param>
    /// <param name="Succ">Делегат, вызывающийся в случае статуса успеха</param>
    /// <param name="Fail">Делегат, вызывающийся в случае статуса ошибки</param>
    /// <typeparam name="TValue">Тип значения в монаде</typeparam>
    /// <typeparam name="TResult">Тип результата</typeparam>
    /// <returns></returns>
    public static Task<TResult?> DefaultMatchUnsafeAsync<TValue, TResult>(
        this Task<Validation<Error, TValue>> task,
        Func<TValue, TResult?> Succ,
        Func<Seq<Error>, TResult?> Fail)
    {
        return task.Result.DefaultMatchUnsafeAsync(Succ, Fail);
    }

    /// <summary>
    /// Вызывает делегат Succ или Fail в зависимости от статуса монады
    /// </summary>
    /// <param name="validation">Объект validation</param>
    /// <param name="Succ">Делегат, вызывающийся в случае статуса успеха</param>
    /// <param name="Fail">Делегат, вызывающийся в случае статуса ошибки</param>
    /// <typeparam name="TValue">Тип значения в монаде</typeparam>
    /// <typeparam name="TResult">Тип результата</typeparam>
    /// <returns></returns>
    public static Task<TResult> DefaultMatchAsync<TValue, TResult>(
        this Validation<Error, TValue> validation,
        Func<TValue, Task<TResult>> Succ,
        Func<Seq<Error>, TResult> Fail)
        where TResult : notnull
    {
        return validation.DefaultMatchAsync(value => Succ(value).Result, Fail);
    }

    /// <summary>
    /// Вызывает делегат Succ или Fail в зависимости от статуса монады
    /// </summary>
    /// <param name="task">Задача с объектом validation</param>
    /// <param name="Succ">Делегат, вызывающийся в случае статуса успеха</param>
    /// <param name="Fail">Делегат, вызывающийся в случае статуса ошибки</param>
    /// <typeparam name="TValue">Тип значения в монаде</typeparam>
    /// <typeparam name="TResult">Тип результата</typeparam>
    /// <returns></returns>
    public static Task<TResult> DefaultMatchAsync<TValue, TResult>(
        this Task<Validation<Error, TValue>> task,
        Func<TValue, Task<TResult>> Succ,
        Func<Seq<Error>, TResult> Fail)
        where TResult : notnull
    {
        return task.Result.DefaultMatchAsync(Succ, Fail);
    }

    /// <summary>
    /// Вызывает делегат Succ или Fail в зависимости от статуса монады, не проверяя результат на null
    /// </summary>
    /// <param name="validation">Объект validation</param>
    /// <param name="Succ">Делегат, вызывающийся в случае статуса успеха</param>
    /// <param name="Fail">Делегат, вызывающийся в случае статуса ошибки</param>
    /// <typeparam name="TValue">Тип значения в монаде</typeparam>
    /// <typeparam name="TResult">Тип результата</typeparam>
    /// <returns></returns>
    public static Task<TResult?> DefaultMatchUnsafeAsync<TValue, TResult>(
        this Validation<Error, TValue> validation,
        Func<TValue, Task<TResult?>> Succ,
        Func<Seq<Error>, TResult?> Fail)
    {
        return validation.DefaultMatchUnsafeAsync(value => Succ(value).Result, Fail);
    }

    /// <summary>
    /// Вызывает делегат Succ или Fail в зависимости от статуса монады, не проверяя результат на null
    /// </summary>
    /// <param name="task">Задача с объектом validation</param>
    /// <param name="Succ">Делегат, вызывающийся в случае статуса успеха</param>
    /// <param name="Fail">Делегат, вызывающийся в случае статуса ошибки</param>
    /// <typeparam name="TValue">Тип значения в монаде</typeparam>
    /// <typeparam name="TResult">Тип результата</typeparam>
    /// <returns></returns>
    public static Task<TResult?> DefaultMatchUnsafeAsync<TValue, TResult>(
        this Task<Validation<Error, TValue>> task,
        Func<TValue, Task<TResult?>> Succ,
        Func<Seq<Error>, TResult?> Fail)
    {
        return task.Result.DefaultMatchUnsafeAsync(Succ, Fail);
    }
}