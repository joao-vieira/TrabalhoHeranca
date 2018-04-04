using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoHeranca {
    class System {
        // Cria os arrays para armazenar Alunos e Funcionários
        List<CPessoal> ListaPessoas;
        List<CAluno> ListaAlunos;
        List<CFuncionario> ListaFuncionarios;

        // Método para cadastro de novo aluno
        public void newAluno() {
            String nome, cpf, curso, turma;
            int idade, matricula, ano;
            DateTime dataNasc;

            Program.infoColor();
            Console.WriteLine();
            Console.WriteLine("            ==> Agora vamos inserir um novo aluno. Por favor, preencha as informações corretamente! <== ");
            Console.WriteLine();
            Program.resetColor();

            Console.Write("Qual é o nome do aluno? ");
            nome = Console.ReadLine();
            Console.Write("Qual é a data de nascimento do aluno (dd/mm/yyyy) ? ");
            dataNasc = Convert.ToDateTime(Console.ReadLine());

            DateTime bDay = new DateTime(dataNasc.Year, dataNasc.Month, dataNasc.Day);
            int now = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
            int dob = int.Parse(bDay.ToString("yyyyMMdd"));
            idade = (now - dob) / 10000;

            Console.Write("Qual é o CPF do aluno? ");
            cpf = Console.ReadLine();
            Console.Write("Qual é o curso do aluno? ");
            curso = Console.ReadLine();
            Console.Write("Qual é a turma do aluno? ");
            turma = Console.ReadLine();
            Console.Write("Qual é a matrícula do aluno? ");
            matricula = Convert.ToInt32(Console.ReadLine());
            Console.Write("Qual é o ano de ingresso do aluno no curso? ");
            ano = Convert.ToInt32(Console.ReadLine());
            
            Tools tools = new Tools();
            tools.store(nome, cpf, dataNasc, idade, matricula, ano, curso, turma, "", "", "");

            Program.successColor();
            Console.WriteLine();
            Console.WriteLine("Aluno cadastrado com sucesso!");
            Console.WriteLine();
        }

        // Método para cadastro de novo funcionário
        public void newFuncionario() {
            String nome, cpf, setor, turno, funcao;
            int idade;
            DateTime dataNasc;

            Program.infoColor();
            Console.WriteLine();
            Console.WriteLine("            ==> Agora vamos inserir um novo funcionário. Por favor, preencha as informações corretamente! <== ");
            Console.WriteLine();
            Program.resetColor();

            Console.Write("Qual é o nome do funcionário? ");
            nome = Console.ReadLine();
            Console.Write("Qual é a data de nascimento do funcionário (dd/mm/yyyy) ? ");
            dataNasc = Convert.ToDateTime(Console.ReadLine());

            DateTime bDay = new DateTime(dataNasc.Year, dataNasc.Month, dataNasc.Day);
            int now = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
            int dob = int.Parse(bDay.ToString("yyyyMMdd"));
            idade = (now - dob) / 10000;

            Console.Write("Qual é o CPF do funcionário? ");
            cpf = Console.ReadLine();
            Console.Write("Qual é o setor do funcionário? ");
            setor = Console.ReadLine();
            Console.Write("Em que turno o funcionário trabalha? ");
            turno = Console.ReadLine();
            Console.Write("Qual é a função do funcionário? ");
            funcao = Console.ReadLine();

            Tools tools = new Tools();
            tools.store(nome, cpf, dataNasc, idade, 0, 0, "", "", setor, turno, funcao);

            Program.successColor();
            Console.WriteLine();
            Console.WriteLine("Funcionário cadastrado com sucesso!");
            Console.WriteLine();
        }

        // Método para pesquisar um aluno pelo sua matrícula
        public void selectStudentByMatriculation() {
            Tools tools = new Tools();
            int iMatricula = 0;

            Console.WriteLine();
            Console.Write("Qual é a matrícula do aluno (deve ser exatamente igual) ? ");
            iMatricula = Convert.ToInt32(Console.ReadLine());
            ListaAlunos = tools.getAllStudents();

            for (int i = ListaAlunos.Count - 1; i >= 0; i--) { 
                if(ListaAlunos[i].getMatricula() != iMatricula) {
                    ListaAlunos.RemoveAt(i);
                }
            }
            
            this.showStudent("Matrícula", Convert.ToString(iMatricula));
        }

        // Método para pesquisar um aluno pelo seu nome
        public void selectStudentByName() {
            Tools tools = new Tools();
            string strName = "";

            Console.WriteLine();
            Console.Write("Qual é o nome do aluno (pode ser uma parte do nome) ? ");
            strName = Console.ReadLine();
            ListaAlunos = tools.getAllStudents();

            for (int i = ListaAlunos.Count - 1; i >= 0; i--) {
                if (!ListaAlunos[i].getNome().Contains(strName)) {
                    ListaAlunos.RemoveAt(i);
                }
            }

            this.showStudent("Nome", strName);
        }

        // Método para mostrar todos os alunos matriculados em determinado curso
        public void selectStudentsByClass() {
            Tools tools = new Tools();
            string strClassName = "";

            Console.WriteLine();
            Console.Write("Qual é o nome do curso (pode ser somente uma parte do nome) ? ");
            strClassName = Console.ReadLine();
            ListaAlunos = tools.getAllStudents();

            for (int i = ListaAlunos.Count - 1; i >= 0; i--) {
                if (!ListaAlunos[i].getCurso().Contains(strClassName)) {
                    ListaAlunos.RemoveAt(i);
                }
            }

            this.showStudent("Curso", strClassName);
        }

        // Método para mostrar todos os funcionários
        public void selectAllFuncs() {
            Tools tools = new Tools();
            ListaFuncionarios = tools.getAllFuncs();

            for (int i = ListaFuncionarios.Count - 1; i >= 0; i--) {
                if (!ListaFuncionarios[i].getNome().EndsWith("_F")) {
                    ListaFuncionarios.RemoveAt(i);
                }
            }

            this.showFunc("Funcionários", "TODOS");
        }

        // Método para pesquisar funiconários pelo seu setor
        public void selectFuncsBySector() {
            Tools tools = new Tools();
            string strSector = "";

            Console.WriteLine();
            Console.Write("Qual é o setor do funcionário (pode ser uma parte do nome do setor) ? ");
            strSector = Console.ReadLine();
            ListaFuncionarios = tools.getAllFuncs();

            for (int i = ListaFuncionarios.Count - 1; i >= 0; i--) {
                if (!ListaFuncionarios[i].getSetor().Contains(strSector)) {
                    ListaFuncionarios.RemoveAt(i);
                }
            }

            this.showFunc("Setor", strSector);
        }

        // Método para selecionar todos os aniversariantes do mês
        public void selectAllCurrentMonthBirthdays() {
            Tools tools           = new Tools();
            DateTime now          = DateTime.Now;
            ListaPessoas          = tools.getAllPeople();

            for (int i = ListaPessoas.Count - 1; i >= 0; i--) {
                if(ListaPessoas[i].getDataNasc().Month != now.Month) {
                    ListaPessoas.RemoveAt(i);
                }
            }

            Program.infoColor();
            Console.WriteLine("                         => Aniversariantes do Mês 0" + now.Month + " <=                       ");
            Program.resetColor();
            if(ListaPessoas.Count > 0) {
                for (int i = ListaPessoas.Count - 1; i >= 0; i--) {
                    Console.WriteLine("Aniversariante:  {0}  - Data de Aniversário: {1}",  ListaPessoas[i].getNome().Remove(ListaPessoas[i].getNome().Length - 2), DateTime.Parse(ListaPessoas[i].getDataNasc().ToString("dd-MM-yyyy HH:mm:ss")).ToString("dd/MM"));
                }
            } else {
                Program.infoColor();
                Console.WriteLine("                        ==> Não há aniversariantes este mês! <==                         ");
            }
        }

        // Método para excluir um aluno
        public void removeStudent() {
            Tools tools = new Tools();
            string strNomeAluno = "";

            Console.WriteLine();
            Console.Write("Digite o nome do aluno (lembre-se que o nome deve ser exatamente igual ao que foi cadastrado): ");
            strNomeAluno = Console.ReadLine();
            bool bDeletou = tools.delete(strNomeAluno, "aluno");

            Console.WriteLine();
            if(bDeletou) {
                Program.successColor();
                Console.WriteLine("Aluno deletado com sucesso!");
            } else {
                Program.errorColor(); ; ; ; ; ;
                Console.WriteLine("Nenhum aluno encontrado com o nome '{0}'. Por favor, verifique!", strNomeAluno);
            }
            Console.WriteLine();
        }

        // Método para excluir um funcionário
        public void removeFunc() {
            Tools tools = new Tools();
            string strNomeFunc = "";

            Console.WriteLine();
            Console.Write("Digite o nome do funcionário (lembre-se que o nome deve ser exatamente igual ao que foi cadastrado): ");
            strNomeFunc = Console.ReadLine();
            bool bDeletou = tools.delete(strNomeFunc, "funcionario");

            Console.WriteLine();
            if (bDeletou) {
                Program.successColor();
                Console.WriteLine("Funcionário deletado com sucesso!");
            } else {
                Program.errorColor();
                Console.WriteLine("Nenhum funcionário encontrado com o nome '{0}'. Por favor, verifique!", strNomeFunc);
            }
            Console.WriteLine();
        }

        // Método genérico para apresentar o resultado de um filtro para alunos
        public void showStudent(string strDescFiltro, string strValorFiltro) {
            Program.infoColor();
            Console.WriteLine();
            Console.WriteLine("            ==> Agora vamos listar os alunos:  [Filtro ->  " + strDescFiltro + ": " + strValorFiltro + "] /  Qtd Resultados : (" + ListaAlunos.Count + ") <==");
            Console.WriteLine();
            Program.resetColor();
            Console.WriteLine("  Nome  |  CPF  |  Data de Nascimento  |  Matrícula  |  Curso  ");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------");
            foreach (CAluno aluno in ListaAlunos) {
                Console.WriteLine("  {0}  ;  {1}  ;  {2}  ;  {3}  ;  {4}  ", aluno.getNome().Remove(aluno.getNome().Length - 2), aluno.getCPF(), DateTime.Parse(aluno.getDataNasc().ToString("dd-MM-yyyy HH:mm:ss")).ToString("dd/MM/yyyy"), aluno.getMatricula(), aluno.getCurso());
            }

            Console.WriteLine();
        }

        // Método genérico para apresentar o resultado de um filtro utilizado em funcionários
        public void showFunc(string strDescFiltro, string strValorFiltro) {
            Program.infoColor();
            Console.WriteLine();
            Console.WriteLine("            ==> Agora vamos listar os funcionários: [Filtro ->  " + strDescFiltro + ": " + strValorFiltro + "] /  Qtd Resultados : (" + ListaFuncionarios.Count + ") <==");
            Console.WriteLine();
            Program.resetColor();
            Console.WriteLine("  Nome  |  CPF  |  Data de Nascimento  |  Setor  |  Função  ");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------");
            foreach (CFuncionario func in ListaFuncionarios) {
                Console.WriteLine("  {0}  ;  {1}  ;  {2}  ;  {3}  ;  {4}  ", func.getNome().Remove(func.getNome().Length - 2), func.getCPF(), DateTime.Parse(func.getDataNasc().ToString("dd-MM-yyyy HH:mm:ss")).ToString("dd/MM/yyyy"), func.getSetor(), func.getFuncao());
            }
            Console.WriteLine();
        }
    }
}
