using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.ModuloGarcom;
using ControleDeBar.ConsoleApp.ModuloMesa;
using System.Collections;

namespace ControleDeBar.ConsoleApp.ModuloConta
{
    public class Conta : EntidadeBase
    {

        public string numero;
        public Mesa mesa;
        public Garcom garcom;

        public double total;
        public DateTime dataPedido;

        public string status;
        public ArrayList listaPedidos = new ArrayList();

        public Conta(int id, string numero, Mesa mesa, Garcom garcom)
        {
            this.id = id;
            this.mesa = mesa;
            this.garcom = garcom;
            this.numero = numero;
            dataPedido = DateTime.Now.Date;  
            status = "Aberto";

        }

        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            Conta conta = (Conta)registroAtualizado;

            numero = conta.numero;
            mesa = conta.mesa;
            garcom = conta.garcom;

        }

        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (numero.Length == null)
                erros.Add("O campo \"numero\" não pode ser nulo.");

            if (mesa == null)
                erros.Add("O campo \"mesa\" é obrigatório");

            if (garcom == null)
                erros.Add("O campo \"garçom\" é obrigatório");

            return erros;
        }

        public double SomarTotal()
        {
            total = 0;
            foreach (Pedido pedido in listaPedidos)
            {
                total += pedido.CalcularValor();
            }
            return total;
        }

    }
}
