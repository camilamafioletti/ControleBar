using ControleDeBar.ConsoleApp.Compartilhado;
using System.Collections;

namespace ControleDeBar.ConsoleApp.ModuloProduto
{
    public class Produto : EntidadeBase
    {
        public string nome;
        public double valor;

        public Produto(int id, string nome, double valor)
        {
            this.id = id;
            this.nome = nome;
            this.valor = valor;
        }

        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            Produto produto = (Produto)registroAtualizado;

            nome = produto.nome;
            valor = produto.valor;
        }

        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (string.IsNullOrEmpty(nome.Trim()))
                erros.Add("O campo \"nome\" é obrigatório");

            if (valor <= 0 || valor == null)
            {
                erros.Add("O campo \"valor\" é obrigatório");
            }

            return erros;
        }
    }
}
