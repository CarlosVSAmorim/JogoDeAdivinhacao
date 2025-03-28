class JogoAdivinhacao
{
    static void Main()
    {
        while (true)
        {  //limpa o console
            Console.Clear();
            //exibe o menu
            ExibirMenu();
            //obtém a dificuldade
            int totalDeTentativas = ObterDificuldade();
            //inicia o jogo baseado na dificuldade
            Jogar(totalDeTentativas);
            
            if (!DesejaContinuar())
                break;
        }
    }

    static void ExibirMenu()
    {   //MENU DO JOGO
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("Jogo de Adivinhação");
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("Escolha um nível de dificuldade:");
        Console.WriteLine("1 - Fácil (10 tentativas)");
        Console.WriteLine("2 - Médio (5 tentativas)");
        Console.WriteLine("3 - Difícil (3 tentativas)");
        Console.WriteLine("----------------------------------------");
    }

    //Função para escolher a dificuldade
    static int ObterDificuldade()
    {
        while (true)
        {
            Console.Write("Digite sua escolha: ");
            string entrada = Console.ReadLine();
            
            return entrada switch
            {
                "1" => 10,
                "2" => 5,
                "3" => 3,
                _ => 0
            };
        }
    }
    //Função para o jogar
    static void Jogar(int totalDeTentativas)
    {
        if (totalDeTentativas == 0)
            return;

        int numeroSecreto = new Random().Next(1, 21);
        HashSet<int> numerosTentados = new();
        int pontuacao = 1000;

        for (int tentativa = 1; tentativa <= totalDeTentativas; tentativa++)
        {
            Console.Clear();
            ExibirStatus(tentativa, totalDeTentativas, numerosTentados, pontuacao);
            int numeroDigitado = ObterNumeroUsuario(numerosTentados);
            
            if (numeroDigitado == numeroSecreto)
            {
                Console.WriteLine("Parabéns! Você acertou!");
                Console.WriteLine($"Sua pontuação final foi: {pontuacao}");
                break;
            }
            else
            {
                pontuacao -= Math.Abs(numeroDigitado - numeroSecreto) / 2;
                Console.WriteLine(numeroDigitado > numeroSecreto ? "O número digitado é maior." : "O número digitado é menor.");
            }

            if (tentativa == totalDeTentativas)
            {
                Console.WriteLine($"Que pena! O número era {numeroSecreto}.");
                Console.WriteLine($"Sua pontuação final foi: {pontuacao}");
            }

            Console.WriteLine("Aperte ENTER para continuar...");
            Console.ReadLine();
        }
    }
    //Função para exibir as tentativas restantes, a pontuação e os números que ja foram jogados
    static void ExibirStatus(int tentativa, int totalDeTentativas, HashSet<int> numerosTentados, int pontuacao)
    {
        Console.WriteLine("----------------------------------------");
        Console.WriteLine($"Tentativa {tentativa} de {totalDeTentativas}");
        Console.WriteLine("Números já tentados: " + string.Join(", ", numerosTentados));
        Console.WriteLine($"Pontuação: {pontuacao}");
        Console.WriteLine("----------------------------------------");
    }
    //Função para obter o número aleatório do jogador
    static int ObterNumeroUsuario(HashSet<int> numerosTentados)
    {
        while (true)
        {
            Console.Write("Digite um número entre 1 e 20: ");
            if (int.TryParse(Console.ReadLine(), out int numero) && numero is >= 1 and <= 20)
            {
                if (numerosTentados.Add(numero))
                    return numero;
                
                Console.WriteLine("Você já tentou esse número. Escolha outro.");
            }
            else
            {
                Console.WriteLine("Entrada inválida! Digite um número entre 1 e 20.");
            }
        }
    }
    //Função para finalizar o jogo ou continuar jogando
    static bool DesejaContinuar()
    {
        Console.Write("Deseja jogar novamente? (S/N): ");
        return Console.ReadLine().Trim().ToUpper() == "S";
    }
}