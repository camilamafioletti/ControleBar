using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.ModuloGarcom;
using ControleDeMedicamentos.ConsoleApp;
using System.Collections;

namespace ControleDeBar.ConsoleApp.ModuloProduto
{
    public class TelaProduto : TelaBase
    {

        private RepositorioProduto repositorioProduto = null;

        public TelaProduto(RepositorioProduto repositorioProduto)
        {
            repositorio = repositorioProduto;
            this.repositorioProduto = repositorioProduto;
            nomeEntidade = "Produto";
        }

        protected override void MostrarTabela(ArrayList listaProduto)
        {

            Console.Clear();
            Console.WriteLine("Produtos registrados:");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("|ID |Nome       |Valor   |");
            Console.WriteLine("--------------------------");
            Console.ResetColor();

            foreach (Produto produto in listaProduto)
            {
                Console.WriteLine("|{0,-3}|{1,-11}|{2,-8}|", produto.id, produto.nome, produto.valor);
            }

            Console.ReadKey();
        }

        protected override EntidadeBase ObterRegistro()
        {
            Console.Write("Informe o nome do produto: ");
            string nome = Console.ReadLine();

            Console.Write("Informe o valor do produto: ");
            double valor = double.Parse(Console.ReadLine());

            Produto produto = new Produto(repositorioProduto.contadorId, nome, valor);

            return produto;
        }

    }
}
