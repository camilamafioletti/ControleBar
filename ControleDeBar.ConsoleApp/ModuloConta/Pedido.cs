using ControleDeBar.ConsoleApp.ModuloProduto;

namespace ControleDeBar.ConsoleApp.ModuloConta
{
    public class Pedido
    {

        public int quantidade;
        public Produto produto;

        public Pedido(int quantidade, Produto produto)
        {
            this.quantidade = quantidade;
            this.produto = produto;
        }

        public double CalcularValor()
        {
            return quantidade * produto.valor;
        }
    }
}
