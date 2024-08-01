# KrapkaNet.Repositories.Abstractions

Repository Pattern is a design pattern that mediates between the domain and data mapping layers using a collection-like interface for accessing domain objects.

- IRepositoryReader<T, in TKey> - Is a read-only interface for accessing your data.
- IRepositoryWriter<T> - Is a write-only interface for accessing your data.
- IRepositoryRemover<in T, in TKey> - Is a remove-only interface for accessing your data.
- IRepository<T, in TKey> - Is a read-write interface for accessing your data.

##### IRepositoryRemover

Is a remove-only interface for accessing your data.

## Getting started

### Prerequisites

Add the following NuGet package to your project:

```shell
dotnet add package KrapkaNet.Repositories.Abstractions
```

## Feedback

- Create an issue on [GitHub](https://github.com/artdolya/krapka/issues).
