using ProjetoConsole.Data;
using ProjetoConsole.Entities;
using ProjetoConsole.Viewer;
using System;
using System.Globalization;
using System.Linq;

namespace ProjetoConsole.Services
{
    public class CalcularMedia
    {
        Aluno aluno = null;
        Menu m = new Menu();
        public void Calcular()
        {
            try
            {
                if (Repository.list.Any())
                {
                    Console.Clear();
                    Lista();
                    Console.ResetColor();
                    Console.WriteLine();

                    decimal media;
                    decimal notas;
                    decimal soma = 0;

                    Console.Write("Informe o ID do Professor que calculará as médias do aluno: ");
                    int searchId = int.Parse(Console.ReadLine());
                    Professor professor = Repository.listP.Find(x => x.Id == searchId);
                    if (professor == null)
                    {
                        Console.WriteLine("Esse ID não existe!");
                        Calcular();
                    }
                    else
                    {
                        Console.Write("Informe o RA do Aluno que terá as médias calculadas: ");
                        int searchRa = int.Parse(Console.ReadLine());
                        aluno = Repository.list.Find(x => x.RA == searchRa && x.Turma.Contains(professor.Turma));
                        if (aluno == null)
                        {
                            Console.WriteLine("Esse RA não existe!");
                            Calcular();
                        }
                    }
                    Console.Write("Informe quantas notas serão calculadas por favor: ");
                    int qtdeNotas = int.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);


                    for (notas = 1; notas <= qtdeNotas; notas++)
                    {
                        bool valorValido = false;
                        while (!valorValido)
                        {
                            Console.WriteLine($"Digite a nota #{notas} (0 a 10)");
                            decimal nota = decimal.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                            if (nota.ToString().Length <= 4 && nota <= 10 && nota >= 0)
                            {
                                valorValido = true;
                                soma += nota;
                            }
                            else
                            {
                                valorValido = false;
                                Console.WriteLine($"O valor deve ser número com até 2 casas decimais de 0 a 10");
                            }

                        }
                    }

                    media = soma / qtdeNotas;
                    aluno.Media = media;
                    ImprimeResultado(media);
                    m.RetornarMenu();

                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Nenhum ALUNO cadastrado!");
                    m.RetornarMenu();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Código executado inadequadamente! " + ex.Message);
                m.RetornarMenu();
            }
        }
        public decimal ImprimeResultado(decimal media)
        {
            if (media >= 7 && media <= 10)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"APROVADO");
                Console.ResetColor();
                Console.WriteLine($"MÉDIA: " + media.ToString("F2", CultureInfo.InvariantCulture));
            }
            else if (media >= 0 && media <= 6)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("REPROVADO");
                Console.ResetColor();
                Console.WriteLine($"MÉDIA: " + media.ToString("F2", CultureInfo.InvariantCulture));
            }
            else
            {
                Console.WriteLine("Erro, o valor das médias só pode ser de 0 a 10.");
                Calcular();
            }
            Console.ReadKey();
            return media;
        }
        public void ListarAlunos()
        {
            if (Repository.list.Any())
            {
                Console.Clear();
                Lista();
                Console.WriteLine();
                m.RetornarMenu();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Nenhum ALUNO cadastrado!");
                m.RetornarMenu();
            }
        }
        public void Lista()
        {
            var resultado = from aluno in Repository.list
                            join professor in Repository.listP
                            on aluno.Turma equals professor.Turma
                            orderby aluno.Name, professor.Name
                            select new { aluno.Name, NomeProfessor = professor.Name, professor.Turma, aluno.RA, professor.Id, aluno.Media, aluno.Materia };

            if (resultado.Any())
            {
                Console.Clear();
                foreach (var item in resultado)
                {
                    if (item.Media >= 7 && item.Media <= 10)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }

                    Console.WriteLine($"O aluno: {item.Name}, RA: {item.RA}, Turma: {item.Turma}, Professor: {item.NomeProfessor}, ID: {item.Id}, MEDIA: " + item.Media.ToString("F2"), CultureInfo.InvariantCulture);
                    Console.ResetColor();
                    Console.WriteLine("-------------------------------------------------------------------");
                }
            }
            else if (Repository.list.Any())
            {
                Console.ReadLine();
                Console.WriteLine("Nenhum ALUNO cadastrado!");
                m.AposMenu();
            }
            else
            {
                Console.ReadLine();
                Console.WriteLine("Nenhum ALUNO cadastrado!");
                m.AposMenu();
            }
        }

    }
}

