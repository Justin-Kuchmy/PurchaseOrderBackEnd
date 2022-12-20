using Microsoft.AspNetCore.Mvc;
using PurchaseOrderBackEnd.Vendors;

namespace PurchaseOrderBackEnd.Interfaces
{
    public interface IRepository<T>
    {
        Task<List<Vendor>> findAll();
        Task<bool> updateOne(T entity);
        Task<Vendor?> addOne(T entity);
        Task<bool> deleteOne(int id);

        Task Save();
    }
}
