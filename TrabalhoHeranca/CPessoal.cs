using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoHeranca {

    // Classe BASE com as definições comuns para Alunos e Funcionários
    class CPessoal {
        protected string nome;
        protected string cpf;
        protected DateTime dataNasc;
        protected int idade;
        public static int countPessoa = 0;

        /* Construtor padrão.
        *  Se a classe Derivada não invocar explicitamente o construtor da classe BASE, o construtor padrão é chamado implicitamente.
        *  A classe BASE deve ter sempre um construtor padrão
        */
        public CPessoal() {
            this.nome     = "";
            this.cpf      = "";
            this.dataNasc = DateTime.Now;
            this.idade    = 0;
        }


        // Seta o nome do membro da escola
        public void setNome(string _nome) {
            this.nome = _nome;
        }

        // Seta o CPF do membro da escola
        public void setCPF(string _cpf) {
            this.cpf = _cpf;
        }

        // Seta a data de nascimento do membro da escola
        public void setDataNasc(DateTime _dataNasc) {
            this.dataNasc = _dataNasc;
        }

        // Seta a idade do membro da escola
        public void setIdade(int _idade) {
            this.idade= _idade;
        }


        // Retorna o nome do membro da escola
        public string getNome() {
            return this.nome;
        }

        // Retorna o CPF do membro da escola
        public string getCPF() {
            return this.cpf;
        }

        // Retorna a data de nascimento do membro da escola
        public DateTime getDataNasc() {
            return this.dataNasc;
        }

        // Retorna a idade do membro da escola
        public int getIdade() {
            return this.idade;
        }

    }
}
