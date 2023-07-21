using ProjetoConsole.Data;
using ProjetoConsole.Entities;
using ProjetoConsole.Viewer;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjetoConsole.Services
{
    public class CalcularMedia
    {
        
        public void Calcular()
        {
            Menu m = new Menu();
            


            Console.Clear();
            Console.WriteLine("Aperte ESC para retornar ao MENU");
            while (Console.ReadKey().Key == ConsoleKey.Escape)
            {
                m.Show();
            }

            try
            {
                double media;
                double nota;
                double notas;
                double soma = 0;
                Console.Write("Informe o ID do Professor que calculará as médias do aluno: ");
                int searchId = int.Parse(Console.ReadLine());
                Professor professor = Repository.listP.Find(x => x.Id == searchId);
                Aluno aluno = null;
                if (professor == null)
                {
                    Console.WriteLine("Esse ID não existe!");
                    Calcular();
                }
                else
                {
                    Console.Write("Informe o RA do Aluno que terá as médias calculadas: ");
                    int searchRa = int.Parse(Console.ReadLine());
                    aluno = Repository.list.Find(x => x.RA == searchRa && x.Materias.Contains(professor.Materia));
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
                    Console.WriteLine($"Digite a nota {notas}");
                    while (!double.TryParse(Console.ReadLine(), out nota))
                    {
                        Console.WriteLine($"O valor deve ser um número!");
                    }
                    soma += nota;
                }

                media = soma / qtdeNotas;
                aluno.Media = media;
                ImprimeResultado(media);
                Console.WriteLine();
                Console.WriteLine("Aperte ENTER para retornar ao MENU");
                Console.ReadKey();
                m.Show();
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Código executado inadequadamente! " + ex.Message);
                Console.ReadLine();
            }
        }
        public double ImprimeResultado(double media)
        {
            if (media >= 7 && media <= 10)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($" Você foi APROVADO");
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine($"A média foi {media}");
                Console.WriteLine();
                foreach (Aluno obj in Repository.list)
                {
                    Console.WriteLine(obj);
                }
            }
            else if (media >= 0 && media <= 6)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Você foi REPROVADO");
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine($"A sua média foi {media}");
                Console.WriteLine();
                foreach (Aluno obj in Repository.list)
                {
                    Console.WriteLine(obj);
                }
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
            Menu m = new Menu();

            var resultado = from aluno in Repository.list
                            join professor in Repository.listP
                            on aluno.Turma equals professor.Turma
                            select new { aluno.Name, NomeProfessor = professor.Name, professor.Turma, aluno.RA, professor.Id, aluno.Media };

            if (resultado != null && resultado.Any())
            {
                Console.Clear();
                foreach (var item in resultado)
                {
                    Console.WriteLine($"O aluno: {item.Name}, com o RA: {item.RA} vai estudar na turma {item.Turma}, com o professor {item.NomeProfessor}, ID: {item.Id} e sua nota foi: {item.Media}");
                }
                Console.WriteLine();
                Console.WriteLine("Aperte ENTER para retornar ao MENU");
                while (Console.ReadKey().Key != ConsoleKey.Enter) { }
                m.Show();
                Console.ReadLine();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Nenhum aluno encontrado.");
                Console.WriteLine("Aperte ENTER para retornar ao MENU");
                while (Console.ReadKey().Key != ConsoleKey.Enter) { }

                m.Show();
                Console.Clear();    
            }
        }
    }
}
