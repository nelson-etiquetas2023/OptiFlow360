using Microsoft.EntityFrameworkCore;
using Server.Data;
using Shared.Models;

namespace Server.Service.Customers
{
    public class CustomersServices : ICustomersService
    {
        public OptiFlowDbContext context { get; set; }
        public CustomersServices(OptiFlowDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Customer>> GetCustomersAsync()
        {
            return await context.Clientes.ToListAsync();
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            var cliente = await context.Clientes.FindAsync(id);

            if (cliente == null) 
                throw new InvalidOperationException($"no se encontro el cliente con el codigo: {id}");

            return cliente;
        }

        public async Task<Customer> CreateCustomerAsync(Customer customer)
        {
            context.Clientes.Add(customer);
            await context.SaveChangesAsync();
            return customer; 

        }

        public async Task<Customer?> UpdateCustomerAsync(int id, Customer customer)
        {
            var customerUpdate = await context.Clientes.FindAsync(id);

            if (customerUpdate == null)
                return null;    

            customerUpdate.CustomerName = customer.CustomerName;
            customerUpdate.Direction = customer.Direction;
            customerUpdate.Itbis = customer.Itbis;
            customerUpdate.Phone = customer.Phone;
            customerUpdate.Email = customer.Email;
            customerUpdate.Contact = customer.Contact;
            await context.SaveChangesAsync();
            return customerUpdate;
        }
        public  async Task<bool> DeleteCustomerAsync(int id)
        {
            var cliente = await context.Clientes.FindAsync(id);
            if (cliente is null) return false;

            context.Clientes.Remove(cliente);
            await context.SaveChangesAsync();
            return true;
        }


      

        
    }
}
