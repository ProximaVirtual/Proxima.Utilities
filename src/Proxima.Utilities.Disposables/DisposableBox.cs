namespace Proxima.Utilities.Disposables;

/// <summary>
/// Provides an easy way to collect <see cref="IDisposable"/> instances to then dispose them in a single pass.
/// </summary>
public sealed class DisposableBox : IDisposable
{
    private readonly List<IDisposable> _disposables;

    /// <summary>
    /// Creates a new <see cref="DisposableBox"/> with a default capacity.
    /// </summary>
    public DisposableBox()
    {
        _disposables = new List<IDisposable>();
    }
    
    /// <summary>
    /// Creates a new <see cref="DisposableBox"/> from an existing array of <see cref="IDisposable"/> objects.
    /// </summary>
    /// <param name="disposables"></param>
    public DisposableBox(params IDisposable[] disposables)
    {
        _disposables = new List<IDisposable>(disposables.Length);
        _disposables.AddRange(disposables);
    }

    /// <summary>
    /// Creates a new <see cref="DisposableBox"/> and initializes it with a default capacity.
    /// </summary>
    /// <param name="defaultCapacity"></param>
    public DisposableBox(int defaultCapacity)
    {
        _disposables = new List<IDisposable>(defaultCapacity);
    }

    internal void Add(IDisposable disposable)
    {
        // If the disposable being added is this instance of
        // the bag, we want to pre-emptively throw this exception.
        if (ReferenceEquals(this, disposable))
            throw new RecursiveDisposableBoxException();
        
        _disposables.Add(disposable);
    }
    
    public void Dispose()
    {
        foreach (var disposable in _disposables)
            disposable?.Dispose();
    }
}