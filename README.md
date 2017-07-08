# Cactoos.Net
.Net port of Yegor Bugayenko's Java library Cactoos for OOP primitives : https://github.com/yegor256/cactoos
It's a little bit changed to better suit to c#, but the overall oop concept is kept within.
For example in you want to write a String to a text file. How it looks in java:
```java
new LengthOfInput(
  new TeeInput(
    new BytesAsInput(
      new TextAsBytes(
        new StringAsText(
          "Hello, world!"
        )
      )
    ),
    new FileAsOutput(
      new File("/tmp/hello.txt")
    )
  )
).value(); // happens here
```
And how it looks in Cactoos.Net:
```csharp
 new OutputCollection(
     new StringInput("hello cactoos"),
     new PathOutput("file2.txt", FileMode.Truncate)
 ).Count(); //happens here
```
Some words about `OutputCollection`.`OutputCollection` is `IEnumerable<byte>`:
```csharp
    public class OutputCollection : IEnumerable<byte>, IDisposable
```
It wraps two sources of data(`Stream`, `IEnumerable<byte>`, `IInput`)
and writes first data source to second(`Stream` or `IOutput`) just like a `TeeInput` in the original library
as the iteration happens. I prefer to use C# LINQ `Count()` instead of `LenghtOfInput` for brevity.
The same is true about `InputCollection`, it implements `IEnumerable<byte>` and allows to iterate over `Stream`.
