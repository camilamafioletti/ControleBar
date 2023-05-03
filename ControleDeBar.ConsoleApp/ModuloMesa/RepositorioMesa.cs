using ControleDeMedicamentos.ConsoleApp;
using System.Collections;

namespace ControleDeBar.ConsoleApp.ModuloMesa
{
    public class RepositorioMesa : RepositorioBase
    {
        public RepositorioMesa(ArrayList listaMesa)
        {
            this.listaRegistros = listaMesa;
        }

        public override Mesa SelecionarId(int id)
        {
            return (Mesa)base.SelecionarId(id);
        }
    }
}
