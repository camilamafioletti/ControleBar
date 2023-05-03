using ControleDeBar.ConsoleApp.Compartilhado;
using System.Collections;

namespace ControleDeBar.ConsoleApp.ModuloGarcom
{
    public class Garcom : EntidadeBase
    {
        public string nome;
        public string login;
        public string senha;

        public Garcom(int id, string nome, string login, string senha)
        {
            this.id = id; 
            this.nome = nome;
            this.login = login;
            this.senha = senha;
        }

        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            Garcom garcom = (Garcom)registroAtualizado;

            nome = garcom.nome;
            login = garcom.login;
            senha = garcom.senha;
        }

        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (string.IsNullOrEmpty(nome.Trim()))
                erros.Add("O campo \"nome\" é obrigatório");

            if (nome.Length <= 3)
                erros.Add("O campo \"login\" precisa ter mais que 3 letras");


            return erros;
        }
    }
}
