using ControleDeBar.ConsoleApp.ModuloConta;
using ControleDeBar.ConsoleApp.ModuloGarcom;
using ControleDeBar.ConsoleApp.ModuloMesa;
using ControleDeBar.ConsoleApp.ModuloProduto;
using ControleDeMedicamentos.ConsoleApp;
using System.Collections;

namespace ControleDeBar.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RepositorioGarcom repositorioGarcom = new RepositorioGarcom(new ArrayList());
            RepositorioMesa repositorioMesa = new RepositorioMesa(new ArrayList());
            RepositorioProduto repositorioProduto = new RepositorioProduto(new ArrayList());
            RepositorioConta repositorioConta = new RepositorioConta(new ArrayList());

            TelaGarcom telaGarcom = new TelaGarcom(repositorioGarcom);
            TelaMesa telaMesa = new TelaMesa(repositorioMesa);
            TelaProduto telaProduto = new TelaProduto(repositorioProduto);
            TelaConta telaConta = new TelaConta(telaMesa, telaGarcom, repositorioConta, repositorioGarcom, repositorioMesa, repositorioProduto);

            Menus menus = new Menus(telaGarcom, telaMesa, telaProduto, telaConta);

            #region

            Garcom garcom1 = new Garcom(0, "Vanessa", "vane", "123456");
            Garcom garcom2 = new Garcom(1, "Lara", "lata", "123456");
            Garcom garcom3 = new Garcom(2, "Carlos", "carlos", "123456");
            Garcom garcom4 = new Garcom(3, "Mario", "mario", "123456");

            repositorioGarcom.listaRegistros.Add(garcom1);
            repositorioGarcom.listaRegistros.Add(garcom2);
            repositorioGarcom.listaRegistros.Add(garcom3);
            repositorioGarcom.listaRegistros.Add(garcom4);

            Mesa mesa1 = new Mesa(0, "1", "leste");
            Mesa mesa2 = new Mesa(1, "2", "centro");
            Mesa mesa3 = new Mesa(2, "3", "oeste");
            Mesa mesa4 = new Mesa(3, "4", "leste");

            repositorioMesa.listaRegistros.Add(mesa1);
            repositorioMesa.listaRegistros.Add(mesa2);
            repositorioMesa.listaRegistros.Add(mesa3);
            repositorioMesa.listaRegistros.Add(mesa4);

            Produto produto1 = new Produto(0, "Fritas", 25);
            Produto produto2 = new Produto(1, "Xis", 15);
            Produto produto3 = new Produto(2, "Carne", 40);
            Produto produto4 = new Produto(3, "Batata", 70);

            repositorioProduto.listaRegistros.Add(produto1);
            repositorioProduto.listaRegistros.Add(produto2);
            repositorioProduto.listaRegistros.Add(produto3);
            repositorioProduto.listaRegistros.Add(produto4);

            Conta conta1 = new Conta(0, "01", mesa1, garcom1);
            Conta conta2 = new Conta(1, "02", mesa2, garcom2);
            Conta conta3 = new Conta(2, "10", mesa3, garcom3);
            Conta conta4 = new Conta(3, "10", mesa4, garcom4);

            repositorioConta.listaRegistros.Add(conta1);
            repositorioConta.listaRegistros.Add(conta2);
            repositorioConta.listaRegistros.Add(conta3);
            repositorioConta.listaRegistros.Add(conta4);

            Pedido pedido1 = new Pedido(2, produto1);
            Pedido pedido2 = new Pedido(5, produto2);
            Pedido pedido3 = new Pedido(3, produto3);
            Pedido pedido4 = new Pedido(4, produto4);

            conta1.listaPedidos.Add(pedido1);
            conta2.listaPedidos.Add(pedido2);
            conta3.listaPedidos.Add(pedido3);
            conta4.listaPedidos.Add(pedido4);

            #endregion

            menus.MenuPrincipal();

        }
    }
}