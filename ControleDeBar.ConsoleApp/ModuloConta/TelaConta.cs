using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.ModuloGarcom;
using ControleDeBar.ConsoleApp.ModuloMesa;
using ControleDeBar.ConsoleApp.ModuloProduto;
using ControleDeMedicamentos.ConsoleApp;
using System.Collections;

namespace ControleDeBar.ConsoleApp.ModuloConta
{
    public class TelaConta : TelaBase
    {
        private RepositorioConta repositorioConta = null;
        private RepositorioMesa repositorioMesa = null;
        private RepositorioGarcom repositorioGarcom = null;
        private RepositorioProduto repositorioProduto = null;
        private TelaMesa telaMesa = null;
        private TelaGarcom telaGarcom = null;

        public TelaConta(TelaMesa telaMesa, TelaGarcom telaGarcom, RepositorioConta repositorioConta, RepositorioGarcom repositorioGarcom, RepositorioMesa repositorioMesa, RepositorioProduto repositorioProduto)
        {
            repositorio = repositorioConta;
            this.telaMesa = telaMesa;
            this.telaGarcom = telaGarcom;
            this.repositorioGarcom = repositorioGarcom;
            this.repositorioMesa = repositorioMesa;
            this.repositorioConta = repositorioConta;
            this.repositorioProduto = repositorioProduto;
        }

        public override string ApresentarMenu()
        {
            Console.Clear();

            Console.WriteLine($"(1) Abrir conta");
            Console.WriteLine($"(2) Registrar pedidos");
            Console.WriteLine($"(3) Fechar conta");
            Console.WriteLine($"(4) Visualizar contas");
            Console.WriteLine($"(5) Visualizar contas em aberto");
            Console.WriteLine($"(6) Visualizar fatura do dia");
            Console.WriteLine($"(7) Visualizar pedidos");
            Console.WriteLine("(V) Voltar ao menu ");
            Console.Write("\nOpção:  ");

            string opcaoMenu = Console.ReadLine();

            return opcaoMenu;
        }

        public override void InserirNovoRegistro()
        {
            bool temMesa = repositorioMesa.TemRegistros();

            if (temMesa == false)
            {
                Mensagem("Cadastre ao menos uma mesa para criar uma conta ", ConsoleColor.Red);
                return;
            }

            bool temGarcom = repositorioGarcom.TemRegistros();

            if (temGarcom == false)
            {
                Mensagem("Cadastre ao menos um garçom para criar uma conta ", ConsoleColor.Red);
                return;
            }

            base.InserirNovoRegistro();
        }

        protected override void MostrarTabela(ArrayList listaContas)
        {
            Console.Clear();
            Console.WriteLine("Contas abertas:");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("|ID |Numero  |Mesa    |Garçom   |Status |");
            Console.WriteLine("-----------------------------------------");
            Console.ResetColor();

            foreach (Conta conta in listaContas)
            {
                Console.WriteLine("|{0,-3}|{1,-8}|{2,-8}|{3,-9}|{4,-7}|", conta.id, conta.numero, conta.mesa.numero, conta.garcom.nome, conta.status);
            }

            Console.ReadKey();
        }

        public void MostrarEmAberto()
        {
            Console.Clear();
            Console.WriteLine("Contas abertas:");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("|ID |Numero  |Mesa    |Garçom   |Status |");
            Console.WriteLine("-----------------------------------------");
            Console.ResetColor();

            foreach (Conta conta in repositorioConta.listaRegistros)
            {
                if (conta.status == "Aberto")
                {
                    Console.WriteLine("|{0,-3}|{1,-8}|{2,-8}|{3,-9}|{4,-7}|", conta.id, conta.numero, conta.mesa.numero, conta.garcom.nome, conta.status);
                }
            }

            Console.ReadKey();
        }

        public void MostrarTabelaDePedidos()
        {
            Console.Clear();

            MostrarTabela(repositorioConta.listaRegistros);

            Console.Write("\nDigite o id da conta que deseja mostrar os pedidos: ");
            int id = int.Parse(Console.ReadLine());

            Conta conta = repositorioConta.SelecionarId(id);

            Console.WriteLine("Pedidos abertos:");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("|Produto   |Quantidade |Total   ");
            Console.WriteLine("--------------------------------");
            Console.ResetColor();

            foreach (Pedido pedido in conta.listaPedidos)
            {
                Console.WriteLine("|{0,-10}|{1,-11}|{2,-9}", pedido.produto.nome, pedido.quantidade, pedido.CalcularValor());
            }

            Console.ReadKey();
        }

        protected override EntidadeBase ObterRegistro()
        {
            Console.Write("Informe o numero da conta: ");
            string numero = Console.ReadLine();

            telaMesa.VisualizarRegistros();

            Console.Write("\nDigite o ID da Mesa que será feito o pedido: ");
            int mesaPedido = int.Parse(Console.ReadLine());

            telaGarcom.VisualizarRegistros();

            Console.Write("\nDigite o ID do garçom que irá fazer o pedido: ");
            int garcomPedido = int.Parse(Console.ReadLine());

            Mesa mesa = (Mesa)repositorioMesa.SelecionarId(mesaPedido);
            Garcom garcom = (Garcom)repositorioGarcom.SelecionarId(garcomPedido);

            Conta conta = new Conta(repositorioConta.contadorId, numero, mesa, garcom);

            return conta;
        }

        public void ObterRegistroDePedidos()
        {
            Produto produtoEscolhido = null;

            MostrarTabela(repositorioConta.listaRegistros);

            Console.Write("Informe o id da conta: ");
            int idConta = int.Parse(Console.ReadLine());

            Conta conta = repositorioConta.SelecionarId(idConta);

            Console.Write("Digite o Produto: ");
            string nomeProduto = Console.ReadLine();

            Console.Write("Digite a quantidade de produtos: ");
            int qtdProdutos = int.Parse(Console.ReadLine());

            foreach (Produto produto in repositorioProduto.SelecionarTodos())
            {
                if (produto.nome == nomeProduto)
                {
                    produtoEscolhido = produto;
                    break;
                }
            }

            Pedido pedido = new Pedido(qtdProdutos, produtoEscolhido);
            conta.listaPedidos.Add(pedido);

        }

        public void FecharConta()
        {
            MostrarTabela(repositorioConta.listaRegistros);

            Console.Write("Digite o ID da conta que será fechada: ");
            int id = int.Parse(Console.ReadLine());

            Conta conta = repositorioConta.SelecionarId(id);

            conta.status = "Fechado";

            Mensagem("Sucesso! ", ConsoleColor.Green);
        }

        public void MostrarFaturas()
        {
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Total Faturado: \n");
                Console.ResetColor();
                Console.WriteLine($"Total dos pedidos: R${repositorioConta.Total()}");

                Console.ReadKey();
            }

        }
    }
}
