using ContaBancaria.Model;
using ContaBancaria.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaBancaria.Controller
{
    internal class ContaController : IContaRepository
    {
        private readonly List<Conta> listaConta = new();
        int numero = 0;

        //Metodos CRUDS
        public void Atualizar(Conta conta)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Conta conta)
        {
            listaConta.Add(conta);
            Console.WriteLine($"A conta do número {conta.GetNumero()} foi criado com sucesso!");
        }

        public void Deletar(Conta conta)
        {
            throw new NotImplementedException();
        }
        public void ListarTodas()
        {
            foreach(var conta in listaConta)
            {
                conta.Visualizar();
            }
        }

        public void ProcurarPorNumero()
        {
            throw new NotImplementedException();
        }

        //Metodos Bancarios

        public void Depositar(int numero, decimal valor)
        {
            throw new NotImplementedException();
        }
        public void Sacar(int numero, decimal valor)
        {
            throw new NotImplementedException();
        }

        public void Transferir(int numero, int numertoDestino, decimal valor)
        {
            throw new NotImplementedException();
        }

        //métodos auxiliares
        public int GerarNumero()
        {
            return ++numero;
        }
    }
}
