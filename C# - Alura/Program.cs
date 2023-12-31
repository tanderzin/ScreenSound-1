﻿// Screen Sound
string mensagemDeBoasVindas = "Boas Vindas ao Screen Sound";
//List<string> listaDasBandas = new List<string> { "U2", "The Beatles", "Calypso" };

Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>();
bandasRegistradas.Add("Linkin Park", new List<int> { 10, 8, 6 });
bandasRegistradas.Add("The Beatles", new List<int>());

void ExibirLogo()
{
    Console.WriteLine(@"
░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░"
    );
    Console.WriteLine(mensagemDeBoasVindas);
}

void ExibirOpcoesDoMenu()
{
    ExibirLogo();
    Console.WriteLine("\nDigite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para mostrar todas as bandas");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 para exibir a média de uma banda");
    Console.WriteLine("Digite -1 para sair");

    Console.Write("\nDigite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

    switch (opcaoEscolhidaNumerica)
    {
        case 1:
            RegistrarBanda();
            break;
        case 2:
            MostrarBandasRegistradas();
            break;
        case 3:
            AvaliarUmaBanda();
            break;
        case 4:
            MediaDaBanda();
            break;
        case -1:
            Console.WriteLine("Tchau tchau :)");
            break;
        default:
            Console.WriteLine("Opção Invalida");
            break;
    }

}

void RegistrarBanda()
{
    LimpaTela();
    ExibirTituloDaOpcao("Registro de bandas");
    Console.Write("Digite o nome da banda que deseja registrar: ");
    string nomeDaBanda = Console.ReadLine()!;
    Console.WriteLine($"\nA banda {nomeDaBanda} foi registrada com sucesso!");
    bandasRegistradas.Add(nomeDaBanda, new List<int>());
    Thread.Sleep(1000);
    LimpaTela();
    ExibirOpcoesDoMenu();
}

void MostrarBandasRegistradas()
{
    LimpaTela();
    ExibirTituloDaOpcao("Exibindo todas as bandas registradas");

    /*for (int i = 0; i < listaDasBandas.Count; i++)
    {
        Console.WriteLine($"Banda: {listaDasBandas[i]}");
    }*/

    foreach (string banda in bandasRegistradas.Keys)
    {
        Console.WriteLine($"Banda: {banda}");
    }

    Console.WriteLine("\nPressione uma tecla para voltar ao menu principal");
    Console.ReadKey();
    LimpaTela();
    ExibirOpcoesDoMenu();

}

void LimpaTela()
{
    Console.Clear();
}

void ExibirTituloDaOpcao(string titulo)
{
    int quantidadeDeLetras = titulo.Length;
    string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*');
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos + "\n");
}

void AvaliarUmaBanda()
{
    //Digite qual banda deseja avaliar
    //Se a banda existir no dicionario >> atribuir uma nota
    //Senão, volta ao menu principal

    LimpaTela();
    ExibirTituloDaOpcao("Avaliar banda");
    Console.Write("Digite qual banda deseja avaliar: ");
    string nomeDaBanda = Console.ReadLine()!;
    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        Console.Write($"Qual a nota que a banda {nomeDaBanda} merece: ");
        int nota = int.Parse(Console.ReadLine()!);
        bandasRegistradas[nomeDaBanda].Add(nota);
        Console.WriteLine($"\nA nota {nota} foi registrada com sucesso para a banda {nomeDaBanda}!");
        Thread.Sleep(3000);
        LimpaTela();
        ExibirOpcoesDoMenu();
    }
    else
    {
        Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada!");
        Console.WriteLine("Digite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        LimpaTela();
        ExibirOpcoesDoMenu();
    }

}

void MediaDaBanda()
{
    LimpaTela();
    ExibirTituloDaOpcao("Média Da Banda");
    Console.Write("Digite qual banda deseja ver a média: ");
    string nomeDaBanda = Console.ReadLine()!; 
    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        List<int> notasDaBanda = bandasRegistradas[nomeDaBanda];
        LimpaTela();
        Console.WriteLine($"\nA média da banda {nomeDaBanda} é {notasDaBanda.Average()}.");

        Console.WriteLine("\nDigite uma tecla para voltar ao menu principal.");
        Console.ReadKey();
        LimpaTela();
        ExibirOpcoesDoMenu();
    }
    else
    {
        LimpaTela();
        Console.WriteLine($"\nA Banda {nomeDaBanda} não foi encontrada!");
        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu principal");
        Console.ReadKey();
        LimpaTela();
        ExibirOpcoesDoMenu();
    }
}

ExibirOpcoesDoMenu();