using System.Net.Http;
using System.Net.Http.Json;

namespace FakeStoreApi
{
    public class FakeStore
    {
        private readonly HttpClient httpClient;
        private readonly string apiUrl = "https://fakestoreapi.com";
        public FakeStore()
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.UserAgent.ParseAdd(
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/142.0.0.0 Safari/537.36"
            );
        }

        public async Task<string> GetProducts()
        {
            var response = await httpClient.GetAsync($"{apiUrl}/products");
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetProduct(int productId)
        {
            var response = await httpClient.GetAsync($"{apiUrl}/products/{productId}");
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> AddProduct(
            int productId,
            string title,
            double price,
            string description,
            string category,
            string image)
        {
            var data = JsonContent.Create(new
            {
                id = productId,
                title = title,
                price = price,
                description = description,
                category = category,
                image = image
            });
            var response = await httpClient.PostAsync($"{apiUrl}/products/", data);
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> DeleteProduct(int productId)
        {
            var response = await httpClient.DeleteAsync($"{apiUrl}/products/{productId}");
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetCarts()
        {
            var response = await httpClient.GetAsync($"{apiUrl}/carts");
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetCart(int cartId)
        {
            var response = await httpClient.GetAsync($"{apiUrl}/carts/{cartId}");
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> AddCart(int cartId, int userId, string productsJson)
        {
            var data = JsonContent.Create(new
            {
                id = cartId,
                userid = userId,
                products = productsJson
            });
            var response = await httpClient.PostAsync($"{apiUrl}/carts", data);
            return await response.Content.ReadAsStringAsync();
        }
        public async Task<string> DeleteCart(int cartId)
        {
            var response = await httpClient.DeleteAsync($"{apiUrl}/carts/{cartId}");
            return await response.Content.ReadAsStringAsync();
        }
        public async Task<string> GetUsers()
        {
            var response = await httpClient.GetAsync($"{apiUrl}/users");
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetUser(int userId)
        {
            var response = await httpClient.GetAsync($"{apiUrl}/users/{userId}");
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> AddUser(
            int userId, string username, string email, string password)
        {
            var data = JsonContent.Create(new
            {
                id = userId,
                username = username,
                email = email,
                password = password
            });
            var response = await httpClient.PostAsync($"{apiUrl}/users", data);
            return await response.Content.ReadAsStringAsync();
        }
      
        public async Task<string> DeleteUser(int userId)
        {
            var response = await httpClient.DeleteAsync($"{apiUrl}/users/{userId}");
            return await response.Content.ReadAsStringAsync();
        }
      
        public async Task<string> Login(string username, string password)
        {
            var data = JsonContent.Create(new { username = username, password = password });
            var response = await httpClient.PostAsync($"{apiUrl}/auth/login", data);
            return await response.Content.ReadAsStringAsync();
        }
    }
}
