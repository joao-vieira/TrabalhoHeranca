using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TrabalhoHeranca {
    class Tools {
        const string strPath    = "C:\\csharp\\baseDeDados\\BaseDeDados.txt";
        const string strPathBkp = "C:\\csharp\\baseDeDados\\BaseDeDados_bkp.txt";

        public void store(string _nome, string _cpf, DateTime _dataNasc, int _idade, int _matricula, int _ano, string _curso, string _turma, string _setor, string _turno, string _funcao) {
            // Create a UTF-8 encoding.
            UTF8Encoding utf8 = new UTF8Encoding();

            try {
                // Cria o StreamWriter para abrir e escrever dados em um arquivo
                StreamWriter sw;
                using (sw = (File.Exists(strPath)) ? File.AppendText(strPath) : File.CreateText(strPath)) {
                    // Aluno
                    string strMatricula = (_matricula == 0) ? "null" : Convert.ToString(_matricula);
                    string strAno       = (_ano == 0) ? "null" : Convert.ToString(_ano);
                    _curso              = (_curso.Equals("")) ? "null" : _curso;
                    _turma              = (_turma.Equals("")) ? "null" : _turma;

                    // Funcionário
                    _setor = (_setor.Equals("")) ? "null" : _setor;
                    _turno = (_turno.Equals("")) ? "null" : _turno;
                    _funcao= (_funcao.Equals("")) ? "null" : _funcao;

                    _nome = (strMatricula.Equals("null")) ? _nome + "_F" : _nome + "_A"; // Define se é aluno ou funcionário

                    string line = CAluno.countPessoa + ";" + _nome + ";" + _cpf + ";" + _dataNasc + ";" + _idade + ";" + _matricula + ";" + _ano + ";" + _curso + ";" + _turma + ";" + _setor + ";" + _turno + ";" + _funcao + "|";
                    sw.WriteLine(line);
                }           

                // Fechando o arquivo
                sw.Close();
                CAluno.countPessoa++;
            } catch(Exception e) {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        public bool delete(string _nome, string _tpPessoa) {
            string strAcrescimo = (_tpPessoa.Equals("aluno")) ? "_A" : "_F";
            bool bDelete        = false;
            String strDadosArquivo;
            StreamWriter sw;

            try {
                StreamReader sr = new StreamReader(strPath);

                // Lê a primeira linha do arquivo de texto
                strDadosArquivo = sr.ReadLine();
                
                using (sw = (File.Exists(strPathBkp)) ? File.AppendText(strPathBkp) : File.CreateText(strPathBkp)) {

                    // Continua lendo até alcançar o final do arquivo
                    while (strDadosArquivo != null && strDadosArquivo != "") {
                        // Separa dados em um array
                        string[] dados = strDadosArquivo.Split(';');                        

                        if (!dados[1].Equals(_nome + strAcrescimo)) {
                            sw.WriteLine(strDadosArquivo);
                        } else {
                            bDelete = true;
                        }

                        // Lê a próxima linha
                        strDadosArquivo = sr.ReadLine();
                    }
                }

                // Fecha o arquivo
                sr.Close();
                sw.Close();
            } catch (Exception e) {
                Console.WriteLine("Exception: " + e.Message);
            }

            // Atualiza o Banco de Dados
            this.refreshDB();
            return bDelete;
        }

        public void refreshDB() {
            string fileContent = File.ReadAllText(strPathBkp);
            File.WriteAllText(strPath, fileContent);
            File.Delete(strPathBkp);
        }

        public List<CPessoal> getAllPeople() {
            List<CPessoal> ListaPessoasLocal = new List<CPessoal>();
            String strDadosArquivo;

            try {
                // Cria o StreamReader para abrir e ler dados de um arquivo
                StreamReader sr = new StreamReader(strPath);

                // Lê a primeira linha do arquivo de texto
                strDadosArquivo = sr.ReadLine();

                // Continua lendo até alcançar o final do arquivo
                while (strDadosArquivo != null && strDadosArquivo != "") {
                    // Separa dados em um array
                    string[] dados = strDadosArquivo.Split(';');

                    // Cria um novo aluno
                    CPessoal pessoa = new CPessoal();
                    pessoa.setNome(dados[1]);
                    pessoa.setCPF(dados[2]);
                    pessoa.setDataNasc(Convert.ToDateTime(dados[3]));
                    pessoa.setIdade(Convert.ToInt32(dados[4]));
                    ListaPessoasLocal.Add(pessoa);

                    // Lê a próxima linha
                    strDadosArquivo = sr.ReadLine();
                }

                // Fecha o arquivo
                sr.Close();
            } catch (Exception e) {
                Console.WriteLine("Exception: " + e.Message);
            }

            return ListaPessoasLocal;
        }

        public List<CAluno> getAllStudents() {
            List<CAluno> ListaAlunosLocal = new List<CAluno>();
            String strDadosArquivo;

            try {
                // Cria o StreamReader para abrir e ler dados de um arquivo
                StreamReader sr = new StreamReader(strPath);

                // Lê a primeira linha do arquivo de texto
                strDadosArquivo = sr.ReadLine();

                // Continua lendo até alcançar o final do arquivo
                while(strDadosArquivo != null && strDadosArquivo != "") {
                    // Separa dados em um array
                    string[] dados = strDadosArquivo.Split(';');

                    // Cria um novo aluno
                    if(!dados[5].Equals("0")) {
                        CAluno aluno = new CAluno(dados[1], dados[2], Convert.ToDateTime(dados[3]), Convert.ToInt32(dados[4]), Convert.ToInt32(dados[5]), Convert.ToInt32(dados[6]), dados[7], dados[8]);
                        ListaAlunosLocal.Add(aluno);
                    }

                    // Lê a próxima linha
                    strDadosArquivo =  sr.ReadLine();
                }

                // Fecha o arquivo
                sr.Close();
            } catch(Exception e) {
                Console.WriteLine("Exception: " + e.Message);
            }

            return ListaAlunosLocal;
        }

        public List<CFuncionario> getAllFuncs() {
            List<CFuncionario> ListaFuncsLocal = new List<CFuncionario>();
            String strDadosArquivo;

            try {
                // Cria o StreamReader para abrir e ler dados de um arquivo
                StreamReader sr = new StreamReader(strPath);

                // Lê a primeira linha do arquivo de texto
                strDadosArquivo = sr.ReadLine();

                // Continua lendo até alcançar o final do arquivo
                while (strDadosArquivo != null && strDadosArquivo != "") {
                    // Separa dados em um array
                    string[] dados = strDadosArquivo.Split(';');

                    // Cria um novo funcionário
                    if (!dados[11].Equals("null")) {
                        CFuncionario func = new CFuncionario(dados[1], dados[2], Convert.ToDateTime(dados[3]), Convert.ToInt32(dados[4]), dados[9], dados[10], dados[11].Remove(dados[11].Length - 1));
                        ListaFuncsLocal.Add(func);
                    }

                    // Lê a próxima linha
                    strDadosArquivo = sr.ReadLine();
                }

                // Fecha o arquivo
                sr.Close();
            } catch (Exception e) {
                Console.WriteLine("Exception: " + e.Message);
            }

            return ListaFuncsLocal;
        }
    }
}
