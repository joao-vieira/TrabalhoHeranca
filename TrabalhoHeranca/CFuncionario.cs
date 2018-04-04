using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoHeranca {
    
    // Definição da classe derivada CFuncionario que herda da classe BASE CPessoal
    class CFuncionario : CPessoal {
        private string setor;
        private string turno;
        private string funcao;

        // Construtor padrão da classe CFuncionario
        public CFuncionario() {
            this.setor  = "";
            this.turno  = "";
            this.funcao = "";
        }

        // Construtor da classe CFuncionario
        public CFuncionario(string _nome, string _cpf, DateTime _dataNasc, int _idade, string _setor, string _turno, string _funcao) {
            base.nome       = _nome;
            base.cpf        = _cpf;
            base.dataNasc   = _dataNasc;
            base.idade      = _idade;

            this.setor      = _setor;
            this.turno      = _turno;
            this.funcao     = _funcao;
        }


        // Seta o setor do funcionário
        public void setSetor(string _setor) {
            this.setor = _setor;
        }

        // Seta o turno de trabalho
        public void setTurno(string _turno) {
            this.turno = _turno;
        }

        // Seta a função do funcionário
        public void setFuncao(string _funcao) {
            this.funcao = _funcao;
        }


        // Retorna o setor do funcionário
        public string getSetor() {
            return this.setor;
        }

        // Seta o turno de trabalho
        public string getTurno() {
            return this.turno;
        }

        // Seta a função do funcionário
        public string getFuncao() {
            return this.funcao;
        }
    }
}
