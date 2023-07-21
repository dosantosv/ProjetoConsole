using ProjetoConsole.Data;
using ProjetoConsole.Entities;
using ProjetoConsole.Viewer;
using System;
using System.Collections.Generic;

namespace ProjetoConsole.Services
{
    public class CriacaoProfessor
    {
        Menu m = new Menu();
        public void CriarProfessor()
        {
            try
            {
                Console.Clear();
                int n = 0;
                bool valorValido = false;

                while (!valorValido)
                {
                    Console.Write("Quantos professores serão criados? ");

                    valorValido = int.TryParse(Console.ReadLine(), out n);

                    if (!valorValido)
                    {
                        Console.WriteLine("Valor inválido. Por favor, digite um número inteiro válido.");
                    }
                }

                for (int i = 1; i <= n; i++)
                {
                    Console.WriteLine($"Professor #{i}:");

                    Console.Write("ID: ");
                    Random random = new Random();
                    int id = random.Next(1, 100);
                    Console.WriteLine(id);

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


                    var listaMateriais = new List<string>()
                    {
                        "HISTÓRIA",
                        "INGLÊS",
                        "PORTUGUÊS"
                    };

                    string materia;

                    do
                    {
                        Console.WriteLine();
                        Console.WriteLine("Escolha uma das matérias disponíveis abaixo:");
                        Console.WriteLine();
                        foreach (var item in listaMateriais)
                        {
                            Console.WriteLine(item);
                        }
                        Console.WriteLine();
                        Console.Write("Digite o nome da matéria: ");
                        materia = Console.ReadLine().ToUpper();

                        if (!listaMateriais.Contains(materia))
                        {
                            Console.WriteLine("Matéria inválida. Escolha uma das matérias listadas.");
                        }

                    } while (!listaMateriais.Contains(materia));


                    string turma;

                    HashSet<string> turmasValidas = new HashSet<string>
                    {
                        "1A", "2A", "3A",
                        "1B", "2B", "3B",
                        "1C", "2C", "3C"
                    };

                    do
                    {
                        Console.Write("Digite a turma em que o professor será cadastrado (1A, 2B, 3C): ");
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
                    Repository.listP.Add(new Professor(nome, sexo, materia, id, turma));
                    Console.WriteLine();
                }
                foreach (Professor obj in Repository.listP)
                {
                    Console.WriteLine(obj);
                }

                Console.WriteLine();
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
