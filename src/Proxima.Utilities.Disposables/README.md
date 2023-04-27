# Proxima.Utilities.Disposables

Provides useful utilities related to `System.IDisposable`.

## Features

### DisposableBox

Inspired by the DisposableBag from [MessagePipe](https://github.com/Cysharp/MessagePipe), this provides a simple
wrapper (or "box") which makes it easy to collect instances of IDisposable and to dispose them with one call.

#### Code Example

```csharp
public class Example
{
    public void Method()
    {
        // Provide anything that implements IDisposable.
        MyDisposable disposable1 = new(123);
        MyDisposable disposable2 = new(667);
        
        DisposableBox box = new(disposable1, disposable2);
        
        // Add more to the box after creation.
        MyDisposable disposable3 = new(902);
        disposable3.AddTo(box);
        
        // Once you're ready to dispose...
        box.Dispose();
    }
}

public record MyDisposable(int Id) : IDisposable
{
    public void Dispose() => Console.WriteLine($"Disposed {Id}");
}
```

#### Console Output
```text
Disposed 123
Disposed 667
Disposed 902
```