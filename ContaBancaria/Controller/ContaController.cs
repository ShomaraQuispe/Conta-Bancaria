using ContaBancaria.Model;
using ContaBancaria.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaBancaria.Controller
{
    public class ContaController : IContaRepository
    {
        private readonly List<Conta> listaConta = new();
        int numero = 0;

        //Metodos CRUDS
        public void Atualizar(Conta conta)
        {
            var buscaConta = BuscarNumeroCollection(conta.GetNumero());

            if (buscaConta is not null)
            {
                var index = listaConta.IndexOf(buscaConta);

                listaConta[index] = conta;

                Console.WriteLine($"A conta numero {conta.GetNumero()} foi atualizada com sucesso!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"A conta numero {numero} não foi encontrada!");
                Console.ResetColor();
            }
        }

        public void Cadastrar(Conta conta)
        {
            listaConta.Add(conta);
            Console.WriteLine($"A conta do número {conta.GetNumero()} foi criado com sucesso!");
        }

        public void Deletar(int numero)
        {
            var conta = BuscarNumeroCollection(numero);

            if (conta is not null)
            {
                if (listaConta.Remove(conta) == true)
                    Console.WriteLine($"A Conta número {numero} foi apagada com sucesso!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"A conta numero {numero} não foi encontrada!");
                Console.ResetColor();
            }
        }
        public void ListarTodas()
        {
            foreach (var conta in listaConta)
            {
                conta.Visualizar();
            }
        }

        public void ProcurarPorNumero(int numero)
        {
            var conta = BuscarNumeroCollection(numero);
            if (conta is not null)
            {
                conta.Visualizar();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"A conta número {numero} não foi encontrada");
                Console.ResetColor();
            }

        }

        //Metodos Bancarios

        public void Depositar(int numero, decimal valor)
        {
            var conta = BuscarNumeroCollection(numero);

            if (conta is not null)
            {
                conta.Depositar(valor);
                Console.WriteLine($"O Depósito na conta numero {numero} foi efetuado com sucesso!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"A conta numero {numero} não foi encontrada!");
                Console.ResetColor();
            }
        }
    
        public void Sacar(int numero, decimal valor)
        {
            var conta = BuscarNumeroCollection(numero);

            if (conta is not null)
            {
                if (conta.Sacar(valor) == true)
                    Console.WriteLine($"O Saque na conta numero {numero} foi efetuado com sucesso!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"A conta numero {numero} não foi encontrada!");
                Console.ResetColor();
            }
        }

        public void Transferir(int numeroOrigem, int numeroDestino, decimal valor)
        {
            var contaOrigem = BuscarNumeroCollection(numeroOrigem);
            var contaDestino = BuscarNumeroCollection(numeroDestino);

            if (contaOrigem is not null && contaDestino is not null)
            {
                if (contaOrigem.Sacar(valor) == true)
                {
                    contaDestino.Depositar(valor);
                    Console.WriteLine($"A Transferência foi efetuada com sucesso!");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Conta de Origem e/ou Conta de Destino não fora encontradas!");
                Console.ResetColor();
            }
        }

        //métodos auxiliares
        public int GerarNumero()
        {
            return ++numero;
        }

        public Conta? BuscarNumeroCollection(int numero)
        {
            foreach (var conta in listaConta)
            {
                if (conta.GetNumero() == numero)
                    return conta;
            }
            return null;
        }
    }

}

