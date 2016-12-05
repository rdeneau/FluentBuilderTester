C# projects using unit tests to show a fluent builder with two options to check the build order:

- **Run-time check** → use of:
  - [Maybe(Of TProductPart)](https://github.com/rdeneau/NullAlternatives) enables build step checking.
  - [InvalidOperationException](https://msdn.microsoft.com/fr-fr/library/system.invalidoperationexception(v=vs.110).aspx) is thrown if necessary.
- **Design-time check** - more elegant but more difficult to create → use of Interfaces with:
  - Builder to constrain the code to follow the build order.
  - Output product to show only its built parts.


## Model

### Product: `SearchParameter`

- Generic class to search the database for a list of item
- The `Parameters` property can contain all criterias to use.
- The `Order` property can be used to sort the resulting list. It should be used only if the `Parameters` have been defined.
- The `Pagination` property can be used to filter the resulting list to get only one "page". It should be used only if the `Order` have been defined.

### Builders

#### Methods:
- Create: static method to get an instance of the builder
- Build: returns the product
- WithParameters: set the `Parameters` property
- WithOrder: set the `Order` property
- WithPagination: set the `Pagination` property

#### Build order:

```
┌────────────────┐   ┌────────────────┐
│     Create     │ → │     Build      │
└────────────────┘   └────────────────┘
        ↓                  ↑ ↑ ↑
┌────────────────┐         │ │ │
│ WithParameters │ ────────┘ │ │
└────────────────┘           │ │
        ↓                    │ │
┌────────────────┐           │ │
│   WithOrder    │ ──────────┘ │
└────────────────┘             │
        ↓                      │
┌────────────────┐             │
│ WithPagination │ ────────────┘
└────────────────┘
```

With the 1st builder:
- When the above order is not followed, it will throw an [InvalidOperationException](https://msdn.microsoft.com/fr-fr/library/system.invalidoperationexception(v=vs.110).aspx).
- We can check which step has been performed i.e. which property has been set with its own property `HasValue` given by its `Maybe` type:
  - `Create().Build().Parameters.HasValue == false`
  - `Create().Build().WithParameters(null).Parameters.HasValue == true` and `Create().Build().WithParameters(null).Parameters.Value == null`.


## Configuration

- Visual Studio 2015
- C#6


## Guide

- Run the unit tests to check they're green.
- Debug each unit tests to step into the code.


## References

- [Builder: C# • Ted Neward's Blog](http://blogs.tedneward.com/patterns/Builder-CSharp/)
- [Applying Functional Principles • Enterprise Craftsmanship (Vladimir Khorikov)](http://enterprisecraftsmanship.com/2016/04/11/applying-functional-principles-in-c-pluralsight-course/)