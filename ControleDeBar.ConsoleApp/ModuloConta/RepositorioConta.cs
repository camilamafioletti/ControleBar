using ControleDeBar.ConsoleApp.ModuloGarcom;
using ControleDeMedicamentos.ConsoleApp;
using System.Collections;

namespace ControleDeBar.ConsoleApp.ModuloConta
{
    public class RepositorioConta : RepositorioBase
    {
        public RepositorioConta(ArrayList listaConta)
        {
            this.listaRegistros = listaConta;
        }

        public override Conta SelecionarId(int id)
        {
            return (Conta)base.SelecionarId(id);
        }
        public double Total()
        {
            double totalContas = 0;

            foreach (Conta conta in listaRegistros)
            {
                if (conta.dataPedido == DateTime.Now.Date)
                {
                    conta.SomarTotal();
                    totalContas += conta.SomarTotal();
                }
            }
            return totalContas;
        }
    }
}
