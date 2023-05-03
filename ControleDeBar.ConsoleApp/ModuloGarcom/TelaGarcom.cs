using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp;
using System.Collections;

namespace ControleDeBar.ConsoleApp.ModuloGarcom
{
    public class TelaGarcom : TelaBase
    {

        private RepositorioGarcom repositorioGarcom = null;

        public TelaGarcom(RepositorioGarcom repositorioGarcom)
        {
            repositorio = repositorioGarcom;
            this.repositorioGarcom = repositorioGarcom;
            nomeEntidade = "Garçom";
        }

        protected override void MostrarTabela(ArrayList listaGarcom)
        {

            Console.Clear();
            Console.WriteLine("Garçons registrados:");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("|ID |Nome       |Login     |");
            Console.WriteLine("----------------------------");
            Console.ResetColor();

            foreach (Garcom garcom in listaGarcom)
            {
                Console.WriteLine("|{0,-3}|{1,-11}|{2,-10}|", garcom.id, garcom.nome, garcom.login);
            }

            Console.ReadKey();
        }

        protected override EntidadeBase ObterRegistro()
        {
            Console.Write("Informe o nome do garçom: ");
            string nome = Console.ReadLine();

            Console.Write("Informe o login do garçom: ");
            string login = Console.ReadLine();

            Console.Write("Informe a senha do garçom: ");
            string senha = Console.ReadLine();

            Garcom garcom = new Garcom(repositorioGarcom.contadorId ,nome, login, senha);

            return garcom;
        }

    }
}
