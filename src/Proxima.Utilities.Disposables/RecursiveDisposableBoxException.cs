namespace Proxima.Utilities.Disposables;

public sealed class RecursiveDisposableBoxException : Exception
{
    private const string ExceptionMessage =
    """
    An attempt was made to add a DisposableBox to itself. This could cause a stack overflow exception.
    """;
    
    public RecursiveDisposableBoxException() : base(ExceptionMessage)
    {
        
    }
}