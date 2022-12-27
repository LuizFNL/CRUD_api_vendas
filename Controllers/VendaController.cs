using Microsoft.AspNetCore.Mvc;
using tech_test_payment_api.Context;
using tech_test_payment_api.Models;

namespace tech_test_payment_api.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class VendaController : ControllerBase
    {
        
        private readonly RegistroContext _context;

        public VendaController(RegistroContext context)
        {
            _context = context;
        }

        [HttpPost("CadastroVendedor")]
        public IActionResult CadastrarVendedor(Vendedor vendedor)
        {
            _context.Add(vendedor);
            _context.SaveChanges();

            return CreatedAtAction(nameof(BuscarVendedores), new { id = vendedor.Id }, vendedor);
        }

        [HttpGet("BuscarVendedor")]
        public IActionResult BuscarVendedores(int id)
        {
            var vendedorBanco = _context.Vendedores.Find(id);
            if (vendedorBanco == null)
                return NotFound();

            return Ok(vendedorBanco);
        }
        
        [HttpPost("CadastrarProdutos")]
        public IActionResult CadastrarProdutos(Produto produto)
        {
            _context.Add(produto);
            _context.SaveChanges();

            return CreatedAtAction(nameof(BuscarProdutos), new { id = produto.Id }, produto);
        }

        [HttpDelete("DeletarProduto")]
        public IActionResult DeletarProdutos(int id)
        {
            var produtoBanco = _context.Produtos.Find(id);

            _context.Remove(produtoBanco);
            _context.SaveChanges();

            return Ok("Produto removido com sucesso.");
        }

        [HttpGet("ProdutosDisponiveis")]
        public IActionResult BuscarProdutos()
        {
            var produtosBanco = _context.Produtos.ToList();
            if (produtosBanco == null)
                return NotFound();

            return Ok(produtosBanco);
        }

        [HttpPost("RealizarVenda")]
        public IActionResult RealizarVenda(int idvendedor, int idproduto, Venda venda)
        {
            var importVendedor = _context.Vendedores.Find(idvendedor);

            if (importVendedor == null)
                return NotFound("Vendedor não encontrado");

            venda.Vendedor = importVendedor;

            var importProduto = _context.Produtos.Find(idproduto);
            
            if (importProduto == null)
                return NotFound("Produto não existe");

            venda.Produto = importProduto;

            venda.DataVenda = DateTime.Now;

            venda.Status = (EnumStatusVenda)0;
            _context.Add(venda);
            _context.SaveChanges();

            return Ok(venda);
        }
        
        [HttpPut("AtualizarVenda")]
        public IActionResult AtualizarVenda(int id, EnumStatusVenda status)
        {
            var vendaBanco = _context.Vendas.Find(id);

            if (vendaBanco == null)
                return NotFound();

            vendaBanco.Status = status;

            _context.SaveChanges();
            return Ok(vendaBanco);

        }

    }
}