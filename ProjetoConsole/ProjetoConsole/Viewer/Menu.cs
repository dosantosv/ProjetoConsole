using ProjetoConsole.Services;
using System;

namespace ProjetoConsole.Viewer
{
    public class Menu
    {
        public void Show()
        {
            Console.Clear();
            DrawScreen();
            WriteOption();
            HandleMenuOption();
        }
        public void DrawScreen()
        {
            Columns();
            Lines();
            Columns();
        }
        public void WriteOption()
        {
            Console.SetCursorPosition(3, 2);
            Console.WriteLine("BEM VINDO!");
            Console.SetCursorPosition(3, 3);
            Console.WriteLine("=============");
            Console.SetCursorPosition(3, 4);
            Console.WriteLine("Selecione uma opção abaixo");
            Console.SetCursorPosition(3, 6);
            Console.WriteLine("1 - Novo Aluno");
            Console.SetCursorPosition(3, 7);
            Console.WriteLine("2 - Novo Professor");
            Console.SetCursorPosition(3, 8);
            Console.WriteLine("3 - Calcular Média ");
            Console.SetCursorPosition(3, 9);
            Console.WriteLine("4 - Listar Alunos");
            Console.SetCursorPosition(3, 11);
            Console.WriteLine("5 - EXCLUIR Professor ");
            Console.SetCursorPosition(3, 12);
            Console.WriteLine("6 - EXCLUIR Alunos ");
            Console.SetCursorPosition(3, 14);
            Console.WriteLine("0 - SAIR ");
        }
        public void HandleMenuOption()
        {
            double media = 0;
            int res;

            CriacaoAluno aluno = new CriacaoAluno();
            CriacaoProfessor professor = new CriacaoProfessor();
            CalcularMedia c = new CalcularMedia();
            ExclusaoProfessor exp = new ExclusaoProfessor();
            ExclusaoAluno exal = new ExclusaoAluno();

            while (true)
            {

                // Obter a entrada do usuário sem exibir o caractere digitado
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (int.TryParse(key.KeyChar.ToString(), out res))
                {
                    switch (res)
                    {
                        case 1:
                            aluno.CriarAluno();
                            break;
                        case 2:
                            professor.CriarProfessor();
                            break;
                        case 3:
                            c.Calcular();
                            break;
                        case 4:
                            c.ListarAlunos();
                            break;
                        case 5:
                            exp.ExcluirProfessor();
                            break;
                        case 6:
                            exal.ExcluirAluno();
                            break;
                        case 0:
                            System.Environment.Exit(0);
                            break;
                        default:
                            ;
                            break;

                    }
                }
                else
                {
                    HandleMenuOption();
                }
            }

        }
        static void Columns()
        {
            Console.Write("+");
            for (int i = 0; i <= 50; i++)
            {
                Console.Write("-");
            }
            Console.Write("+");
            Console.Write("\n");
        }
        static void Lines()
        {
            for (int lines = 0; lines <= 15; lines++)
            {
                Console.Write("|");
                for (int i = 0; i <= 50; i++)
                {
                    Console.Write(" ");
                }
                Console.Write("|");
                Console.Write("\n");
            }
        }
        public void RetornarMenu()
        {
            Console.ResetColor();
            Console.WriteLine("Aperte ENTER para retornar ao MENU");
            while (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                Show();
            }
        }
        public void AposMenu()
        {
            Console.Clear();
            Console.ResetColor();
            Console.WriteLine("Aperte ESC para retornar ao MENU");
            Console.WriteLine();
            while (Console.ReadKey().Key == ConsoleKey.Escape)
            {
                Show();
            }
        }
    }
}
