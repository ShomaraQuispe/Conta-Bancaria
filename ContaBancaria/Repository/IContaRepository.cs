using ContaBancaria.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaBancaria.Repository
{
    internal interface IContaRepository
    {
        //metodo CRUD
        public void ProcurarPorNumero();
        public void ListarTodas();
        public void Cadastrar(Conta conta);
        public void Atualizar(Conta conta);
        public void Deletar(Conta conta);

        //metodo bancarios
        public void Sacar(int numero, decimal valor);
        public void Depositar(int numero, decimal valor);
        public void Transferir(int numero, int numertoDestino, decimal valor);


    }
}
