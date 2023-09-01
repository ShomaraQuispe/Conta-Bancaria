using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaBancaria.Model
{
    internal class ContaPoupanca : Conta
    {
        private int aniversario;
        public ContaPoupanca(int numero, int agencia, int tipo, string titular, decimal saldo, int aniversario) 
            : base(numero, agencia, tipo, titular, saldo)
        {
            this.aniversario = aniversario;
        }

        public int GetAniversario() { return this.aniversario; }
        public void SetAniversario(int Aniversario) { this.aniversario = Aniversario; }

        public override void Visualizar()
        {
            base.Visualizar();
            Console.WriteLine($"Aniversário da conta: {this.aniversario}");
        }
    }
}
