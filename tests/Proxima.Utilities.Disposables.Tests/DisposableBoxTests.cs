namespace Proxima.Utilities.Disposables.Tests;

public sealed class DisposableBoxTests
{
    [Fact]
    public void BoxWithDefaultDisposablesDoesDispose()
    {
        var disposable = Substitute.For<IDisposable>();
        DisposableBox box = new(disposable);
        
        box.Dispose();
        
        disposable.Received().Dispose();
    }

    [Fact]
    public void BoxWithAddedDisposableDoesDispose()
    {
        var disposable = Substitute.For<IDisposable>();
        DisposableBox box = new();
        
        disposable.AddTo(box);
        box.Dispose();
        
        disposable.Received().Dispose();
    }

    [Fact]
    public void BoxAddsItselfDoesThrow()
    {
        DisposableBox box = new();

        // Add the box to itself
        var act = () => box.AddTo(box);

        // Check for exception.
        act.Should().Throw<RecursiveDisposableBoxException>();
    }
}