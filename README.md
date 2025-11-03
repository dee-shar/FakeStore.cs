# FakeStore.cs
Web-API for [fakestoreapi.com](https://fakestoreapi.com/) a free RESTful API for developers, ideal for prototyping, testing, or teaching. No backend setup required.

## Example
```cs
using FakeStoreApi;

namespace Application
{
    internal class Program
    {
        static async Task Main()
        {
            var api = new FakeStore();
            string users = await api.GetUsers();
            Console.WriteLine(users);
        }
    }
}
```
