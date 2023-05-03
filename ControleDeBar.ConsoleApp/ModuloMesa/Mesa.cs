using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.ModuloGarcom;
using System.Collections;

namespace ControleDeBar.ConsoleApp.ModuloMesa
{
    public class Mesa : EntidadeBase
    {
        public string numero;
        public string localizacao;

        public Mesa(int id, string numero, string localizacao)
        {
            this.id = id;
            this.numero = numero;
            this.localizacao = localizacao;
        }

        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            Mesa mesa = (Mesa)registroAtualizado;

            numero = mesa.numero;
            localizacao = mesa.localizacao;

        }

        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (numero.Length <= 3)
                erros.Add("O campo \"localizacao\" precisa ter mais que 3 letras");


            return erros;
        }
    }
}
