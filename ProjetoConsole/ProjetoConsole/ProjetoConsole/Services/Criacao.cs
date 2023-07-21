using ProjetoConsole.Data;
using ProjetoConsole.Viewer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoConsole.Entities
{
    public class Criacao
    {
        public void CriarProfessor()
        {
            Menu m = new Menu();

            Console.Clear();
            Console.WriteLine("Aperte ESC para retornar ao MENU");
            Console.WriteLine();
            while (Console.ReadKey().Key == ConsoleKey.Escape)
            {
                m.Show();
            }

            int n = 0;
            bool inputIsValid = false;

            while (!inputIsValid)
            {
                Console.Write("Quantos professores serão criados? ");

                inputIsValid = int.TryParse(Console.ReadLine(), out n);

                if (!inputIsValid)
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
                    "História",
                    "Inglês",
                    "Português"
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
                    materia = Console.ReadLine();

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
                Repository.listP.Add(new Professor(nome, sexo, materia, id, turma));
                Console.WriteLine();
                Console.WriteLine("Lista de professores criados: ");
            }
            foreach (Professor obj in Repository.listP)
            {
                Console.WriteLine(obj);
            }

            Console.WriteLine();
            Console.WriteLine("Aperte ENTER para retornar ao MENU");
            Console.ReadKey();
            m.Show();


        }
        public void CriarAluno()
        {
            Menu m = new Menu();

            Console.Clear();
            Console.WriteLine("Aperte ESC para retornar ao MENU");
            Console.WriteLine();
            while (Console.ReadKey().Key == ConsoleKey.Escape)
            {
                m.Show();
            }
            Console.Write("Quantos alunos serão criados? ");
            int n = int.Parse(Console.ReadLine());
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

                Console.Write("Data de nascimento (dd/mm/aaaa): ");
                DateTime dataNascimento = DateTime.Parse(Console.ReadLine());

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

                Professor professor = new Professor();
                Console.WriteLine();
                Repository.list.Add(new Aluno(nome, sexo, ra, turma, dataNascimento));

                Console.WriteLine();
                Console.WriteLine("Lista de alunos criados: ");
            }
            foreach (Aluno obj in Repository.list)
            {
                Console.WriteLine(obj);
            }
            Console.WriteLine("aperte ENTER para retornar ao MENU");
            Console.ReadKey();
            m.Show();
        }

    }
}


