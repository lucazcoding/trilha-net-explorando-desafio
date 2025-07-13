using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.WriteLine("Bem vindo ao Sistema de Hotelaria!");

Console.WriteLine("Digite o tipo da suíte (Simples, Luxo, Presidencial):");
string tipoSuite = Console.ReadLine() ?? "Simples";
Console.WriteLine("Digite a capacidade da suíte (1, 2, 3, 4):");
int capacidade = int.Parse(Console.ReadLine() ?? "1");
Console.WriteLine("Digite o valor da diária:");
decimal valorDiaria = decimal.Parse(Console.ReadLine() ?? "100.00");
Suite suite = new Suite(tipoSuite, capacidade, valorDiaria);


Console.WriteLine("Digite a quantidade de Pessoas:");
int quantidadeHospedes = int.Parse(Console.ReadLine() ?? "1");
List<Pessoa> hospedes = new List<Pessoa>();
for (int i = 0; i < quantidadeHospedes; i++)
{
    Console.WriteLine($"Digite o nome do hóspede:");
    string nome = Console.ReadLine() ?? "Hóspede";
    Console.WriteLine($"Digite o sobrenome do hóspede {nome}:");
    string sobrenome = Console.ReadLine() ?? "Sobrenome";
    hospedes.Add(new Pessoa(nome, sobrenome));
}

Console.WriteLine("Digite a quantidade de dias reservados:");
int diasReservados = int.Parse(Console.ReadLine() ?? "1");
Reserva reserva = new Reserva(suite, diasReservados);

Console.WriteLine("Cadastrando hóspedes...");
System.Threading.Thread.Sleep(1000); // Simula um atraso para o usuário perceber a ação
Console.Clear();
try
{
    reserva.CadastrarHospedes(hospedes);
    Console.WriteLine("Hóspedes cadastrados com sucesso!");
}
catch (Exception ex)
{
    Console.WriteLine($"Erro ao cadastrar hóspedes: {ex.Message}");
    return;
}


Console.WriteLine("Cadastrando suíte...");
System.Threading.Thread.Sleep(1000); // Simula um atraso para o usuário perceber a ação
Console.Clear();

try
{
    reserva.CadastrarSuite(suite);
    Console.WriteLine("Suíte cadastrada com sucesso!");
}
catch (Exception ex)
{
    Console.WriteLine($"Erro ao cadastrar suíte: {ex.Message}");
    return;
}

Console.Clear();
Console.WriteLine($"Suíte: {reserva.Suite.TipoSuite}");
foreach (var pessoa in hospedes)
{
    Console.WriteLine($"Hóspede: {pessoa.Nome} {pessoa.Sobrenome} reservado na suíte {reserva.Suite.TipoSuite}");
}



Console.WriteLine($"Quantidade de hóspedes: {reserva.ObterQuantidadeHospedes()}");
try
{
    decimal valorDiariaTotal = reserva.CalcularValorDiaria();
    Console.WriteLine($"Valor total da diária: {valorDiariaTotal:C}");
}
catch (Exception ex)
{
    Console.WriteLine($"Erro ao calcular valor da diária: {ex.Message}");
    return;
}

Console.ReadKey();

List<Reserva> reservas = new List<Reserva>();
reservas.Add(reserva);

Console.Clear();
System.Threading.Thread.Sleep(3000);

Console.WriteLine("Carregando inforamções finais...");

Console.Clear(); 

Console.WriteLine($"Quantidade de hóspedes: {reserva.ObterQuantidadeHospedes()}");

foreach (var r in reservas)
{
    Console.WriteLine($"Reserva: {r.Suite.TipoSuite}, \nHóspedes: {r.ObterNomeHospedes()}\nValor Total: {r.CalcularValorDiaria():C}");
}
