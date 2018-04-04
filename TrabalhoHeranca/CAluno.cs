using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoHeranca {

    // Definição da classe derivada CAluno que herda da classe BASE CPessoal
    class CAluno : CPessoal {
        private int matricula;
        private int ano;
        private string curso;
        private string turma;

        // Construtor padrão da classe CAluno
        public CAluno() {
            this.matricula  = 0;
            this.ano        = DateTime.Now.Year;
            this.curso      = "";
            this.turma      = "";
        }

        // Construtor da classe CAluno
        public CAluno(string _nome, string _cpf, DateTime _dataNasc, int _idade, int _matricula, int _ano, string _curso, string _turma) {
            base.nome       = _nome;
            base.cpf        = _cpf;
            base.dataNasc   = _dataNasc;
            base.idade      = _idade;

            this.matricula  = _matricula;
            this.ano        = _ano;
            this.curso      = _curso;
            this.turma      = _turma;
        }
        

        // Seta o número de matrícula do aluno
        public void setMatricula(int _matricula) {
            this.matricula = _matricula;
        }

        // Seta o ano em que o aluno ingressou no curso
        public void setAno(int _ano) {
            this.ano = _ano;
        }
        
        // Seta o nome do curso em que o aluno está matriculado
        public void setCurso(string _curso) {
            this.curso = _curso;
        }

        // Seta a turma em que o aluno está frequentando
        public void setTurma(string _turma) {
            this.turma = _turma;
        }


        // Retorna o número de matrícula do aluno
        public int getMatricula() {
            return this.matricula;
        }

        // Retorna o ano em que o aluno ingressou na instituição
        public int getAno() {
            return this.ano;
        }

        // Retorna o nome do curso em que o aluno está matriculado
        public string getCurso() {
            return this.curso;
        }

        // Retorna a turma em que o aluno está frequentando
        public string getTurma() {
            return this.turma;
        }
    }
}
