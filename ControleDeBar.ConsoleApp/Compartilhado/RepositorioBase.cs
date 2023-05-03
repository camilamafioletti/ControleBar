using ControleDeBar.ConsoleApp.Compartilhado;
using System.Collections;

namespace ControleDeMedicamentos.ConsoleApp
{
    public class RepositorioBase
    {
        public int contadorId = 4;
        public ArrayList listaRegistros = new ArrayList();

        public void IncrementarId()
        {
            contadorId++;
        }

        public void Cadastrar(EntidadeBase entidade)
        {
            listaRegistros.Add(entidade);
        }

        public void Criar(EntidadeBase entidade)
        {
            Cadastrar(entidade);
            IncrementarId();
        }

        public void Editar(int idEditar, EntidadeBase entidadeEditada)
        {
            EntidadeBase entidade = SelecionarId(idEditar);
            entidade.AtualizarInformacoes(entidadeEditada);
        }

        public void Deletar(int id)
        {
            EntidadeBase entidade = SelecionarId(id);
            listaRegistros.Remove(entidade);
        }

        public ArrayList SelecionarTodos()
        {
            return listaRegistros;
        }

        public virtual EntidadeBase SelecionarId(int id)
        {
            EntidadeBase entidade = null;

            foreach (EntidadeBase a in listaRegistros)
            {
                if (a.id == id)
                {
                    entidade = a;
                    break;
                }
            }
            return entidade;
        }

        public bool TemRegistros()
        {
            return listaRegistros.Count > 0;
        }
    }
}
