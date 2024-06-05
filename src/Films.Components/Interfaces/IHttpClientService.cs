namespace Films.Components.Interfaces
{
    public interface IHttpClientService<T>
    {
        Task<T?> PostAsync(T item, string endpoint);
        Task<T?> GetAsync(T item, string endpoint);
    }
}
