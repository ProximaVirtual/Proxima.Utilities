namespace Proxima.Utilities.Disposables;

public static class ProximaUtilitiesDisposableExtensions
{
    /// <summary>
    /// Adds an <see cref="IDisposable"/> to a <see cref="DisposableBox"/>
    /// </summary>
    /// <param name="disposable">The <see cref="IDisposable"/> to add.</param>
    /// <param name="box">The box to add the <see cref="IDisposable"/> to.</param>
    public static void AddTo(this IDisposable disposable, DisposableBox box)
    {
        box.Add(disposable);
    }
}