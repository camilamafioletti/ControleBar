using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.ModuloGarcom;
using ControleDeMedicamentos.ConsoleApp;
using System.Collections;

namespace ControleDeBar.ConsoleApp.ModuloMesa
{
    public class TelaMesa : TelaBase
    {

        private RepositorioMesa repositorioMesa = null;

        public TelaMesa(RepositorioMesa repositorioMesa)
        {
            repositorio = repositorioMesa;
            this.repositorioMesa = repositorioMesa;
            nomeEntidade = "Mesa";
        }

        protected override void MostrarTabela(ArrayList listaMesa)
        {

            Console.Clear();
            Console.WriteLine("Mesas registradas:");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("|ID |Numero    |Localização  |");
            Console.WriteLine("------------------------------");
            Console.ResetColor();

            foreach (Mesa mesa in listaMesa)
            {
                Console.WriteLine("|{0,-3}|{1,-10}|{2,-13}|", mesa.id, mesa.numero, mesa.localizacao);
            }

            Console.ReadKey();
        }

        protected override EntidadeBase ObterRegistro()
        {
            Console.Write("Informe o numero da mesa: ");
            string numero = Console.ReadLine();

            Console.Write("Informe a localização da mesa: ");
            string localizacao = Console.ReadLine();

            Mesa mesa = new Mesa(repositorioMesa.contadorId, numero, localizacao);

            return mesa;
        }


    }
}
