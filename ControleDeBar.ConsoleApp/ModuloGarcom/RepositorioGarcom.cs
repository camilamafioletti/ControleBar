using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp;
using System.Collections;

namespace ControleDeBar.ConsoleApp.ModuloGarcom
{
    public class RepositorioGarcom : RepositorioBase
    {
        public RepositorioGarcom(ArrayList listaGarcom)
        {
            this.listaRegistros = listaGarcom;
        }

        public override Garcom SelecionarId(int id)
        {
            return (Garcom)base.SelecionarId(id);
        }


    }
}
