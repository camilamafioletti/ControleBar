using ControleDeBar.ConsoleApp.ModuloGarcom;
using ControleDeMedicamentos.ConsoleApp;
using System.Collections;

namespace ControleDeBar.ConsoleApp.ModuloProduto
{
    public class RepositorioProduto : RepositorioBase
    {
        public RepositorioProduto(ArrayList listaProduto)
        {
            this.listaRegistros = listaProduto;
        }

        public override Produto SelecionarId(int id)
        {
            return (Produto)base.SelecionarId(id);
        }


    }
}
