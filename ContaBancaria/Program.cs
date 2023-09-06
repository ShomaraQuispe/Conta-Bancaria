using ContaBancaria.Controller;
using ContaBancaria.Model;

namespace ContaBancaria
{
    public class Program
    {
        private static ConsoleKeyInfo consoleKeyInfo;
        static void Main(string[] args)
        {

            int opcao, agencia, tipo, aniversario, numero;
            string? titular;
            decimal saldo, limite;

            ContaController contas = new();

            ContaCorrente cc1 = new ContaCorrente(contas.GerarNumero(), 123, 1, "Samantha", 100000000.00M, 1000.00M);
            contas.Cadastrar(cc1);

            ContaPoupanca cp1 = new ContaPoupanca(contas.GerarNumero(), 123, 2, "Sabrina", 1000.00M, 10);
            contas.Cadastrar(cp1);

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
                Console.WriteLine("         4 - Atualizar Dados da conta        ");
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

                //tratamento de exceção para impedir a digitação de strings
                try
                {
                    opcao = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nDigite um valor inteiro entre 1 e 9");
                    opcao = 0;
                    Console.ResetColor();
                }

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

                        Console.WriteLine("Digite o Número da Agência: ");
                        agencia = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Digite o Nome do Titular: ");
                        titular = Console.ReadLine();

                        titular ??= string.Empty;

                        do
                        {
                            Console.WriteLine("Digite o Tipo da Conta: ");
                            tipo = Convert.ToInt32(Console.ReadLine());
                        } while (tipo != 1 && tipo != 2);

                        Console.WriteLine("Digite o Saldo da Conta: ");
                        saldo = Convert.ToDecimal(Console.ReadLine());

                        switch (tipo)
                        {
                            case 1:
                                Console.WriteLine("Digite o Limite da Conta: ");
                                limite = Convert.ToDecimal(Console.ReadLine());

                                contas.Cadastrar(new ContaCorrente(contas.GerarNumero(), agencia, tipo, titular, saldo, limite));
                                break;
                            case 2:
                                Console.WriteLine("Digite o dia do Aniversário da Conta: ");
                                aniversario = Convert.ToInt32(Console.ReadLine());

                                contas.Cadastrar(new ContaPoupanca(contas.GerarNumero(), agencia, tipo, titular, saldo, aniversario));
                                break;
                        }


                        Keypress();
                        break;

                    case 2:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Lista todas as contas");
                        Console.ResetColor();

                        contas.ListarTodas();

                        Keypress();
                        break;

                    case 3:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Consultar dados da Conta - por número\n\n");
                        Console.ResetColor();

                        Console.WriteLine("Digite o número da Conta: ");
                        numero = Convert.ToInt32(Console.ReadLine());

                        contas.ProcurarPorNumero(numero);
                        
                        Keypress();
                        break;

                    case 4:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Atalizar Dados da conta");
                        Console.ResetColor();

                        Console.WriteLine("Digite o número da conta: ");
                        numero = Convert.ToInt32(Console.ReadLine());

                        var conta = contas.BuscarNumeroCollection(numero);

                        if(conta is not null)
                        {
                            Console.WriteLine("Digite o Número da Agência: ");
                            agencia = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Digite o Nome do Titular: ");
                            titular = Console.ReadLine();

                            titular ??= string.Empty;

                            Console.WriteLine("Digite o Saldo da Conta: ");
                            saldo = Convert.ToDecimal(Console.ReadLine());

                            tipo = conta.GetTipo();

                            switch (tipo)
                            {
                                case 1:
                                    Console.WriteLine("Digite o Limite da Conta: ");
                                    limite = Convert.ToDecimal(Console.ReadLine());

                                    contas.Atualizar(new ContaCorrente(numero, agencia, tipo, titular, saldo, limite));
                                    break;

                                case 2:
                                    Console.WriteLine("Digite o dia do Aniversário da Conta: ");
                                    aniversario = Convert.ToInt32(Console.ReadLine());

                                    contas.Atualizar(new ContaPoupanca(numero, agencia, tipo, titular, saldo, aniversario));
                                    break;
                            }

                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"A Conta do número {numero} não foi encontrada!");
                            Console.ResetColor();
                        }
                        
                        Keypress();
                        break;

                    case 5:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Apagar conta");
                        Console.ResetColor();

                        Console.WriteLine("Digite a conta que deseja apagar: ");
                        numero = Convert.ToInt32(Console.ReadLine());

                        contas.Deletar(numero);

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
                        Console.ForegroundColor = ConsoleColor.Red;
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