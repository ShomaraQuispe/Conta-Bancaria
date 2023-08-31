using ContaBancaria.Model;

namespace ContaBancaria
{
    public class Program
    {
        private static ConsoleKeyInfo consoleKeyInfo;
        static void Main(string[] args)
        {
            // Teste da Classe Conta
            Conta c1 = new Conta(1, 123, 1, "Shomara", 10000.0M);
            c1.Visualizar();
            c1.Sacar(12000.0M);
            c1.Visualizar();
            c1.Depositar(5000.0M);
            c1.Visualizar();

            int opcao;

            while (true)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("*********************************************");
                Console.WriteLine("                                             ");
                Console.WriteLine("            BANCO DO BRAZIL COM Z            ");
                Console.WriteLine("                                             ");
                Console.WriteLine("*********************************************");
                Console.WriteLine("                                             ");
                Console.WriteLine("         1 - Criar Conta                     ");
                Console.WriteLine("         2 - Lista todas as Contas           ");
                Console.WriteLine("         3 - Buscar Conta por Numero         ");
                Console.WriteLine("         4 - Atalizar Dados da conta         ");
                Console.WriteLine("         5 - Apagar Conta                    ");
                Console.WriteLine("         6 - Sacar                           ");
                Console.WriteLine("         7 - Depositar                       ");
                Console.WriteLine("         8 - Transferir valores entre Contas ");
                Console.WriteLine("         9 - Sair                            ");
                Console.WriteLine("                                             ");
                Console.WriteLine("*********************************************");
                Console.WriteLine("                                             ");
                Console.WriteLine("Entre com a opção desejada:                  ");
                Console.WriteLine("                                             ");
                Console.ResetColor();
                opcao = Convert.ToInt32(Console.ReadLine());

                if (opcao == 9)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nBanco do Brazil com Z - O seu Futuro começa aqui!");
                    Sobre();
                    Console.ResetColor();
                    System.Environment.Exit(0);
                }

                switch (opcao)
                {
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Criar conta\n\n");
                        Console.ResetColor();

                        Keypress();
                        break;

                    case 2:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Lista todas as contas");
                        Console.ResetColor();
                        Keypress();
                        break;

                    case 3:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Buscar Conta por Numero");
                        Console.ResetColor();
                        
                        Keypress();
                        break;

                    case 4:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Atalizar Dados da conta");
                        Console.ResetColor();
                        
                        Keypress();
                        break;

                    case 5:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Apagar conta");
                        Console.ResetColor();
                        
                        Keypress();
                        break;

                    case 6:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Sacar");
                        Console.ResetColor();
                        
                        Keypress();
                        break;

                    case 7:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Depositar");
                        Console.ResetColor();
                        
                        Keypress();
                        break;

                    case 8:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Transferir valores entre Contas");
                        Console.ResetColor();
                        
                        Keypress();
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nOpção Inválida!\n");
                        Console.ResetColor();
                        
                        Keypress();
                        break;
                }

                static void Sobre()
                {
                    Console.WriteLine("\n******************************************");
                    Console.WriteLine("                                            ");
                    Console.WriteLine("Projeto desenvolvido por: Shomara Quispe");
                    Console.WriteLine("shomaraclaudia@gmail.com");
                    Console.WriteLine("github.com/ShomaraQuispe");
                    Console.WriteLine("                                            ");
                    Console.WriteLine("********************************************");
                }

                static void Keypress ()
                {
                    do
                    {
                        Console.Write("\nPressione Enter para continuar");
                        consoleKeyInfo = Console.ReadKey();
                    } while (consoleKeyInfo.Key != ConsoleKey.Enter);
                }
            }
        }
    }
}