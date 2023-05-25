// Funções:

using System;

Dictionary<string, double> veiculos = new Dictionary<string, double>();
double valorHora = 0.0;

void Iniciar()
{
    Console.WriteLine("Bem vindo!");
    Console.Write("Digite valor dá hora do estacioanemnto: R$ ");
    string valor = Console.ReadLine()!;
    valorHora = Double.Parse(valor);
    Console.Clear();
}

void ExibirLogo()
{
    string logo = @"
░██████╗░█████╗░███████╗███████╗  ███████╗░█████╗░███╗░░██╗███████╗
██╔════╝██╔══██╗██╔════╝██╔════╝  ╚════██║██╔══██╗████╗░██║██╔════╝
╚█████╗░███████║█████╗░░█████╗░░  ░░███╔═╝██║░░██║██╔██╗██║█████╗░░
░╚═══██╗██╔══██║██╔══╝░░██╔══╝░░  ██╔══╝░░██║░░██║██║╚████║██╔══╝░░
██████╔╝██║░░██║██║░░░░░███████╗  ███████╗╚█████╔╝██║░╚███║███████╗
╚═════╝░╚═╝░░╚═╝╚═╝░░░░░╚══════╝  ╚══════╝░╚════╝░╚═╝░░╚══╝╚══════╝";
    Console.WriteLine(logo);
}

void ExibirMenu()
{
    Console.WriteLine("\n1 - Estacionar veículo.");
    Console.WriteLine("2 - Baixar veículo.");
    Console.WriteLine("3 - Listar veiculos.");
    Console.WriteLine("4 - Encerrar o expediente.");

    Console.Write("\nDigite a opção: ");
    string opcaoS = Console.ReadLine()!;
    int opcao = int.Parse(opcaoS);

    switch (opcao)
    {
        case 1:
            entradaVeiculo(); ;
            break;
        case 2:
            BaixaVeiculo();
            break;
        case 3:
            listarVeiculos();
            break;
        case 4:
            encerrar();
            break;
        default:
            Console.WriteLine("Opção invalida, tente novamente!");
            Console.Write("\npressione qualquer tecla para voltar.");
            Console.ReadKey();
            Console.Clear();
            ExibirLogo();
            ExibirMenu();
            break;
    }
}

void entradaVeiculo()
{
    Console.Clear();
    ExibirLogo();
    Console.Write("\nDigite a placa: ");
    string placa = Console.ReadLine()!;
    veiculos.Add(placa, 0);
    Console.WriteLine("Veiculo cadastrado com sucesso!");
    Console.Write("\npressione qualquer tecla para voltar.");
    Console.ReadKey();
    Console.Clear();
    ExibirLogo();
    ExibirMenu();
}

void BaixaVeiculo()
{
    Console.Clear();
    ExibirLogo();
    Console.Write("\nDigite a placa do veículo: ");
    string placa = Console.ReadLine()!;

    if (veiculos.ContainsKey(placa))
    {
        Console.Write("Quantas horas o veículo ficou: ");
        string horasS = Console.ReadLine()!;
        int horas = int.Parse(horasS);
        double valorTotal = valorHora * horas;
        veiculos[placa] = valorTotal;
        Console.WriteLine($"Total a pagar: R$ {valorTotal}");
        Console.WriteLine("Baixa feita com sucesso!");
        Console.Write("\npressione qualquer tecla para voltar.");
        Console.ReadKey();
        Console.Clear();
        ExibirLogo();
        ExibirMenu();
    } else
    {
        Console.WriteLine("Veículo invalido, tente novamente!");
        Console.Write("\npressione qualquer tecla para voltar.");
        Console.ReadKey();
        Console.Clear();
        ExibirLogo();
        ExibirMenu();
    }
}

void listarVeiculos()
{
    Console.Clear();
    ExibirLogo();
    Console.WriteLine("\nVeículos estacioandos:\n");

    foreach (string veiculo in veiculos.Keys)
    {
        Console.WriteLine($" Placa: {veiculo}");
    }

    Console.Write("\npressione qualquer tecla para voltar.");
    Console.ReadKey();
    Console.Clear();
    ExibirLogo();
    ExibirMenu();
}


void encerrar()
{
    Console.Clear();
    ExibirLogo();
    double valoDia = veiculos.Values.Sum();
    Console.WriteLine("\n**********");
    Console.WriteLine("Relatório do dia");
    Console.WriteLine("**********\n");

    foreach (KeyValuePair<string, double> veiculo in veiculos)
    {
        Console.WriteLine($" Placa: {veiculo.Key} valor: R$ {veiculo.Value}");
    }

    Console.WriteLine($"\nTtotal: R$ {valoDia}");
}

// Main da aplicação: 

Iniciar();
ExibirLogo();
ExibirMenu();