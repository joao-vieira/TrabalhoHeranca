using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoHeranca {
  
    class Program {
        static void Main(string[] args) {
            Console.Title = "Trabalho de Herança ==> https://github.com/joao-vieira";
            int iMenuOp   = -1;
            Program.showMenu();

            Console.Write("Digite o número da opção desejada: ");
            try {
                iMenuOp = Convert.ToInt32(Console.ReadLine());
                if(iMenuOp < 0 || iMenuOp > 10) {
                    Program.errorColor();
                    Console.WriteLine("Por favor, digite apenas números entre 0 e 10 para selecionar a opção de menu!");
                    Program.startApp(iMenuOp);
                } else {
                    Program.startApp(iMenuOp);
                }
            } catch(Exception e) {
                Program.errorColor();
                Console.WriteLine("Por favor, digite apenas números para selecionar a opção de menu!");
                Program.startApp(iMenuOp);
            }
        }

        public static void startApp(int _iMenuOp) {
            Program.resetColor();
            while (_iMenuOp != 0) {
                // Executa a ação
                _iMenuOp = Program.runAction(_iMenuOp);

                // Pede a opção novamente para seguir com o laço
                Program.showMenu();
                Console.Write("Digite o número da opção desejada: ");
                try {
                    _iMenuOp = Convert.ToInt32(Console.ReadLine());
                    if (_iMenuOp < 0 || _iMenuOp > 10) {
                        Program.errorColor();
                        Console.WriteLine("Por favor, digite apenas números entre 0 e 10 para selecionar a opção de menu!");
                    }
                } catch (Exception e) {
                    _iMenuOp = -1;
                    Program.errorColor();
                    Console.WriteLine("Por favor, digite apenas números entre 0 e 10 para selecionar a opção de menu!");
                }
            }
        }

        public static void showMenu() {
            Program.resetColor();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("|-----------------------------------------------------------|");
            Console.WriteLine("|                      Menu de Opções                       |");
            Console.WriteLine("|-----------------------------------------------------------|");
            Console.WriteLine("   1  -  Cadastrar Novo Aluno");
            Console.WriteLine("   2  -  Cadastrar Novo Funcionário");
            Console.WriteLine("   3  -  Consultar aluno por matrícula");
            Console.WriteLine("   4  -  Consultar aluno por nome");
            Console.WriteLine("   5  -  Consultar funcionários por setor");
            Console.WriteLine("   6  -  Excluir Aluno");
            Console.WriteLine("   7  -  Excluir Funcionário");
            Console.WriteLine("   8  -  Imprimir todos os Alunos do curso especificado");
            Console.WriteLine("   9  -  Imprimir todos os aniversariantes do mês");
            Console.WriteLine("   10 -  Imprimir todos os Funcionários");
            Console.WriteLine("   0  -  Sair do Sistema");

            Console.WriteLine();
        }

        public static int runAction(int option) {
            System sys   = new System();
            Tools tools  = new Tools();
            bool success = false;
            int r        = 0;

            while(!success) {
                Program.resetColor();
                switch (option) {
                    case 1:
                        try {
                            sys.newAluno();
                            r = 1;
                            success = true;
                        } catch(Exception e) {
                            Program.errorColor();
                            Console.WriteLine("Por favor, preencha todas as informações seguindo o valor lógico e o formato, quando demonstrado!");
                        }
                        break;
                    case 2:
                        try {
                            sys.newFuncionario();
                            r = 2;
                            success = true;
                        } catch(Exception e) {
                            Program.errorColor();
                            Console.WriteLine("Por favor, preencha todas as informações seguindo o valor lógico e o formato, quando demonstrado!");
                        }
                        break;
                    case 3:
                        try {
                            sys.selectStudentByMatriculation();
                            r = 3;
                            success = true;
                        } catch (Exception e) {
                            Program.errorColor();
                            Console.WriteLine("Por favor, preencha todas as informações seguindo o valor lógico e o formato, quando demonstrado!");
                        }
                        break;
                    case 4:
                        try {
                            sys.selectStudentByName();
                            r = 4;
                            success = true;
                        } catch (Exception e) {
                            Program.errorColor();
                            Console.WriteLine("Por favor, preencha todas as informações seguindo o valor lógico e o formato, quando demonstrado!");
                        }
                        break;
                    case 5:
                        try { 
                            sys.selectFuncsBySector();
                            r = 5;
                            success = true;
                        } catch (Exception e) {
                            Program.errorColor();
                            Console.WriteLine("Por favor, preencha todas as informações seguindo o valor lógico e o formato, quando demonstrado!");
                        }
                        break;
                    case 6:
                        try { 
                            sys.removeStudent();
                            r = 6;
                            success = true;
                        } catch (Exception e) {
                            Program.errorColor();
                            Console.WriteLine("Por favor, preencha todas as informações seguindo o valor lógico e o formato, quando demonstrado!");
                        }
                        break;
                    case 7:
                        try { 
                            sys.removeFunc();
                            r = 7;
                            success = true;
                        } catch (Exception e) {
                            Program.errorColor();
                            Console.WriteLine("Por favor, preencha todas as informações seguindo o valor lógico e o formato, quando demonstrado!");
                        }   
                        break;
                    case 8:
                        try { 
                            sys.selectStudentsByClass();
                            r = 8;
                            success = true;
                        } catch (Exception e) {
                            Program.errorColor();
                            Console.WriteLine("Por favor, preencha todas as informações seguindo o valor lógico e o formato, quando demonstrado!");
                        }
                        break;
                    case 9:
                        try { 
                            sys.selectAllCurrentMonthBirthdays();
                            r = 9;
                            success = true;
                        } catch (Exception e) {
                            Program.errorColor();
                            Console.WriteLine("Por favor, preencha todas as informações seguindo o valor lógico e o formato, quando demonstrado!");
                        }
                        break;
                    case 10:
                        try { 
                            sys.selectAllFuncs();
                            r = 10;
                            success = true;
                        } catch (Exception e) {
                            Program.errorColor();
                            Console.WriteLine("Por favor, preencha todas as informações seguindo o valor lógico e o formato, quando demonstrado!");
                        }
                        break;
                    default:
                        r = 0;
                        success = true;
                        break;
                }
            }

            return r;
        }

        public static void errorColor() {
            Console.BackgroundColor = ConsoleColor.DarkRed;
        }

        public static void successColor() {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
        }

        public static void infoColor() {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
        }

        public static void resetColor() {
            Console.ResetColor();
        }
    }

}
