namespace tech_test_payment_api.Models
{
    public class Venda
    {
        public int Id { get; set; }
        public Vendedor Vendedor { get; set; }
        public Produto Produto { get; set; }
        public DateTime DataVenda { get => _DataVenda; set => _DataVenda = value; }
        public EnumStatusVenda Status { get; set; }
        private DateTime _DataVenda;

    }
}

//informação sobre o vendedor que a efetivou, data, identificador do pedido e os itens que foram vendidos;
