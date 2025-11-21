using Shared.Models;

namespace Server.Service.Supplier
{
    public interface ISuppliersService
    {
        Task<List<Proveedor>> GetSuppliersAsync();
        Task<Proveedor> GetSupplierByIdAsync(int id);
        Task<Proveedor> CreateSupplierAsync(Proveedor supplier);
        Task<Proveedor?> UpdatesSupplierAsync(int id , Proveedor supplier); 
        Task<bool> DeleteSupplierAsync(int id);
    }
}
