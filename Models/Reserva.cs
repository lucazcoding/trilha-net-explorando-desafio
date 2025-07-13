namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        List<Pessoa> Hospedes { get; set; } = new List<Pessoa>();
        public Suite Suite { get; set; }

        public int DiasReservados { get; set; }

        public Reserva(Suite suite, int diasReservados)
        {
            Suite = suite;
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            if (hospedes.Count > Suite.Capacidade)
            {
                throw new Exception("Quantidade de hospedes maior que a capacidade da suite.");
            }

            Hospedes = hospedes;
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }


        public int ObterQuantidadeHospedes()
        {
            return Hospedes.Count;
        }

        public decimal CalcularValorDiaria()
        {
            if (DiasReservados <= 0)
            {
                throw new Exception("Quantidade de dias reservados deve ser maior que zero.");
            }

            return DiasReservados * Suite.ValorDiaria;
        }

        public string ObterNomeHospedes()
        {
            return string.Join("",Hospedes.Select(h => $" \n-->{h.Nome} {h.Sobrenome} \n"));
        }
    }
}
