using ProjetoConsole.Data;
using ProjetoConsole.Entities;
using ProjetoConsole.Viewer;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace ProjetoConsole.Services
{
    public class CriacaoAluno
    {
        Menu m = new Menu();
        public void CriarAluno()
        {
            try
            {
                Console.Clear();
                int n = 0;
                bool valorValido = false;

                while (!valorValido)
                {
                    Console.Write("Quantos alunos serão criados? ");

                    valorValido = int.TryParse(Console.ReadLine(), out n);

                    if (!valorValido)
                    {
                        Console.WriteLine("Valor inválido. Por favor, digite um número inteiro válido.");
                    }
                }
                for (int i = 1; i <= n; i++)
                {
                    Console.WriteLine($"Aluno #{i}:");

                    Console.Write("RA: ");
                    Random random = new Random();
                    int ra = random.Next(2000, 2100);
                    Console.WriteLine(ra);

                    Console.Write("Nome: ");
                    string nome = Console.ReadLine();

                    char sexo;
                    do
                    {
                        Console.Write("Sexo (M/F): ");
                        sexo = char.Parse(Console.ReadLine());

                        if (sexo != 'M' && sexo != 'F')
                        {
                            Console.WriteLine("O valor digitado precisa ser M ou F");
                        }
                    } while (sexo != 'M' && sexo != 'F');

                    DateTime dataNascimento;
                    string formatoData = "dd/MM/yyyy";

                    do
                    {
                        Console.Write($"Data de nascimento ({formatoData}): ");
                        string input = Console.ReadLine();

                        if (DateTime.TryParseExact(input, formatoData, CultureInfo.InvariantCulture, DateTimeStyles.None, out dataNascimento))
                        {
                            int idade = DateTime.Now.Year - dataNascimento.Year;

                            if (DateTime.Now < dataNascimento.AddYears(idade))
                            {
                                idade--;
                            }

                            if (idade < 15)
                            {
                                Console.WriteLine("O aluno deve ter 15 anos.");
                            }
                            else
                            {
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Data de nascimento inválida. Digite da forma correta {formatoData}.");
                        }
                    } while (true);


                    string turma;

                    HashSet<string> turmasValidas = new HashSet<string>
                    {
                        "1A", "2A", "3A",
                        "1B", "2B", "3B",
                        "1C", "2C", "3C"
                    };

                    do
                    {
                        Console.Write("Digite a turma em que o professor será cadastrado da seguinte forma (1A, 2B, 3C): ");
                        turma = Console.ReadLine().ToUpper();

                        if (turma.Length == 2 && char.IsDigit(turma[0]) && char.IsLetter(turma[1]))
                        {
                            int.Parse(turma[0].ToString());
                        }
                        else
                        {
                            Console.WriteLine("Entrada inválida. Digite a turma no formato correto (1A, 2B, 3C).");
                        }

                    } while (!turmasValidas.Contains(turma));
                    Console.WriteLine();
                    Repository.list.Add(new Aluno(nome, sexo, ra, turma, dataNascimento));

                    Console.WriteLine();

                }
                foreach (Aluno obj in Repository.list)
                {
                    Console.WriteLine(obj);
                }
                m.RetornarMenu();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Código executado inadequadamente! " + ex.Message);
                m.RetornarMenu();
            }
        }
    }
}
