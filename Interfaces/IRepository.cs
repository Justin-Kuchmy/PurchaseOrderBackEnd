using Microsoft.AspNetCore.Mvc;
using PurchaseOrderBackEnd.Vendors;

namespace PurchaseOrderBackEnd.Interfaces
{
    public interface IRepository<T, K>
    {
        Task<List<T>> findAll();
        Task<T?> updateOne(K type, T entity);
        Task<T?> addOne(T entity);
        Task<bool> deleteOne(K type);
        Task<int> Save();
    }
}
