C# projects using unit tests to show a fluent builder for a "Russian dolls" product (simple search parameters, search with sort, search with sort and limit), with two options to check the build order:

- **Run-time check** → use of:
  - [Maybe(Of TProductPart)](https://github.com/rdeneau/NullAlternatives) enables build step checking.
  - [InvalidOperationException](https://msdn.microsoft.com/fr-fr/library/system.invalidoperationexception(v=vs.110).aspx) is thrown if necessary.
- **Design-time check** - more elegant but more difficult to create → use of Interfaces with:
  - Builder to constrain the code to follow the build order.
  - Output product to show only its built parts.


## Configuration

- Visual Studio 2015
- C#6


## Guide

- Run the unit tests to check they're green.
- Debug each unit tests to step into the code.


## References

- [Builder: C# • Ted Neward's Blog](http://blogs.tedneward.com/patterns/Builder-CSharp/)
- [Applying Functional Principles • Enterprise Craftsmanship (Vladimir Khorikov)](http://enterprisecraftsmanship.com/2016/04/11/applying-functional-principles-in-c-pluralsight-course/)