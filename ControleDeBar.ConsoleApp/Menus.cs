
using ControleDeBar.ConsoleApp.ModuloConta;
using ControleDeBar.ConsoleApp.ModuloGarcom;
using ControleDeBar.ConsoleApp.ModuloMesa;
using ControleDeBar.ConsoleApp.ModuloProduto;

namespace ControleDeMedicamentos.ConsoleApp
{
    public class Menus
    {
        private TelaGarcom telaGarcom = null;
        private TelaMesa telaMesa = null;
        private TelaProduto telaProduto = null;
        private TelaConta telaConta = null;

        public Menus(TelaGarcom telaGarcom, TelaMesa telaMesa, TelaProduto telaProduto, TelaConta telaConta)
        {
            this.telaGarcom = telaGarcom;
            this.telaMesa = telaMesa;
            this.telaProduto = telaProduto;
            this.telaConta = telaConta;
        }

        public void MenuPrincipal()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("\n═══ BAR DA GALERA ═══\n");
                Console.WriteLine("(1) Gerenciar Garçons");
                Console.WriteLine("(2) Gerenciar Mesas");
                Console.WriteLine("(3) Gerenciar Produtos");
                Console.WriteLine("(4) Gerenciar Contas");
                Console.WriteLine("(S) Sair ");
                Console.Write("\nOpção:  ");

                string opcaoMenu = Console.ReadLine();


                if (opcaoMenu.ToUpper() == "S")
                {
                    Console.WriteLine("Saindo...");
                    break;
                }
                switch (opcaoMenu.ToUpper())
                {
                    case "1":MenuGarcom(); break;
                    case "2":MenuMesas(); break;
                    case "3":MenuProdutos(); break;
                    case "4":MenuContas(); break;

                    default: TelaBase.Mensagem("\nopção inválida \n", ConsoleColor.Red); break;
                }
            }
        }

        public void MenuGarcom()
        {
            while (true)
            {
                string opcaoMenu = telaGarcom.ApresentarMenu();

                if (opcaoMenu.ToUpper() == "V")
                {
                    Console.WriteLine("Voltando...");
                    break;
                }

                switch (opcaoMenu.ToUpper())
                {
                    case "1": telaGarcom.InserirNovoRegistro(); break;
                    case "2": telaGarcom.EditarRegistro(); break;
                    case "3": telaGarcom.VisualizarRegistros(); break;
                    case "4": telaGarcom.DeletarRegistro(); break;

                    default: TelaBase.Mensagem("\nopção inválida \n", ConsoleColor.Red); break;
                }
            }
        }

        public void MenuMesas()
        {
            while (true)
            {
                string opcaoMenu = telaMesa.ApresentarMenu();

                if (opcaoMenu.ToUpper() == "V")
                {
                    Console.WriteLine("Voltando...");
                    break;
                }

                switch (opcaoMenu.ToUpper())
                {
                    case "1": telaMesa.InserirNovoRegistro(); break;
                    case "2": telaMesa.VisualizarRegistros(); break;
                    case "3": telaMesa.EditarRegistro(); break;
                    case "4": telaMesa.DeletarRegistro(); break;

                    default: TelaBase.Mensagem("\nopção inválida \n", ConsoleColor.Red); break;
                }
            }
        }

        public void MenuContas()
        {
            while (true)
            {
                string opcaoMenu = telaConta.ApresentarMenu();

                if (opcaoMenu.ToUpper() == "V")
                {
                    Console.WriteLine("Voltando...");
                    break;
                }

                switch (opcaoMenu.ToUpper())
                {

                    case "1": telaConta.InserirNovoRegistro(); break;
                    case "2": telaConta.ObterRegistroDePedidos(); break;
                    case "3": telaConta.FecharConta(); break;
                    case "4": telaConta.VisualizarRegistros(); break;
                    case "5": telaConta.MostrarEmAberto(); break;
                    case "6": telaConta.MostrarFaturas(); break;
                    case "7": telaConta.MostrarTabelaDePedidos(); break;

                    default: TelaBase.Mensagem("\nopção inválida \n", ConsoleColor.Red); break;
                }
            }
        }

        public void MenuProdutos()
        {
            while (true)
            {
                string opcaoMenu = telaProduto.ApresentarMenu();

                if (opcaoMenu.ToUpper() == "V")
                {
                    Console.WriteLine("Voltando...");
                    break;
                }

                switch (opcaoMenu.ToUpper())
                {
                    case "1": telaProduto.InserirNovoRegistro(); break;
                    case "2": telaProduto.EditarRegistro(); break;
                    case "3": telaProduto.VisualizarRegistros(); break;
                    case "4": telaProduto.DeletarRegistro(); break;

                    default: TelaBase.Mensagem("\nopção inválida \n", ConsoleColor.Red); break;
                }
            }
        }
    }
}


