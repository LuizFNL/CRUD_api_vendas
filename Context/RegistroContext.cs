using Microsoft.EntityFrameworkCore;
using tech_test_payment_api.Models;

namespace tech_test_payment_api.Context {
    public class RegistroContext : DbContext
{
    public RegistroContext() { }
    public RegistroContext(DbContextOptions<RegistroContext> options) : base(options) { }

    public DbSet<Venda> Vendas { get; set; }
    public DbSet<Vendedor> Vendedores { get; set; }
    public DbSet<Produto> Produtos { get; set; }
}
}