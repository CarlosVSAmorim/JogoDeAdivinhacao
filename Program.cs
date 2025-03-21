while(true)
{
    Console.Clear();
    Console.WriteLine("----------------------------------------");
    Console.WriteLine("Jogo de Adivinhação");
    Console.WriteLine("----------------------------------------");

    // Escolha de dificuldade
    Console.WriteLine("Escolha um nível de dificuldade:");
    Console.WriteLine("----------------------------------------");
    Console.WriteLine("1 - Fácil (10 tentativas)");
    Console.WriteLine("2 - Médio (5 tentativas)");
    Console.WriteLine("3 - Difícil (3 tentativas)");
    Console.WriteLine("----------------------------------------");

    int totalDeTentativas = 0;

    Console.Write("Digite sua escolha: ");
    string entrada = Console.ReadLine();

    if (entrada == "1")
        totalDeTentativas = 10;
    else if (entrada == "2")
        totalDeTentativas = 5;
    else if (entrada == "3")
        totalDeTentativas = 3;

    // Geração de número secreto
    Random geradorDeNumeros = new Random();

    int numeroSecreto = geradorDeNumeros.Next(1, 21);

    // Loop de tentativas do jogo
    for (int tentativa = 1; tentativa <= totalDeTentativas; tentativa++)
    {
        Console.Clear();
        Console.WriteLine("----------------------------------------");
        Console.WriteLine($"Tentativa {tentativa} de {totalDeTentativas}");
        Console.WriteLine("----------------------------------------");

        // Lógica do jogo
        Console.Write("Digite um número entre 1 e 20: ");
        int numeroDigitado = Convert.ToInt32(Console.ReadLine());

        if (numeroDigitado == numeroSecreto)
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Parabéns! Você acertou!");
            Console.WriteLine("----------------------------------------");

            break;
        }
        
		if (tentativa == totalDeTentativas)
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"Que pena! Você usou todas as tentativas. O número era {numeroSecreto}.");
            Console.WriteLine("----------------------------------------");

            break;
        }
    
        else if (numeroDigitado > numeroSecreto)
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("O número digitado é maior que o número secreto.");
            Console.WriteLine("----------------------------------------");
        }
        else
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("O número digitado é menor que o número secreto.");
            Console.WriteLine("----------------------------------------");
        }

        Console.WriteLine("Aperte ENTER para continuar...");
        Console.ReadLine();
    }

    Console.Write("Deseja continuar? (S/N): ");
    string opcaoContinuar = Console.ReadLine().ToUpper();

    if (opcaoContinuar != "S")
        break;
}