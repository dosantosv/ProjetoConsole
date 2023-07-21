using ProjetoConsole.Entities;
using ProjetoConsole.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjetoConsole.Viewer
{
    public class Menu
    {
        public void Show()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
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
            Console.WriteLine("2 - Calcular Média");
            Console.SetCursorPosition(3, 8);
            Console.WriteLine("3 - Novo Professor ");
            Console.SetCursorPosition(3, 9);
            Console.WriteLine("4 - Listar Alunos ");
            Console.SetCursorPosition(3, 10);
            Console.WriteLine("0 - SAIR ");
            Console.SetCursorPosition(3, 11);
        }
        public void HandleMenuOption()
        {
            double media = 0;
            ConsoleKeyInfo key = Console.ReadKey(true);
            int res;

            Aluno a = new Aluno();
            Professor p = new Professor();
            Criacao s = new Criacao();
            CalcularMedia c = new CalcularMedia();

            if (int.TryParse(key.KeyChar.ToString(), out res))
            {
                switch (res)
                {
                    case 1: s.CriarAluno(); ; break;
                    case 2: c.Calcular(); break;
                    case 3: s.CriarProfessor(); break;
                    case 4: c.ListarAlunos(); break;
                    case 0: System.Environment.Exit(0); break;
                    default:; break;
                }
            }
            else
            {
                Console.WriteLine("Opção inválida! Digite um número válido.");
            }

        }
        static void Columns()
        {
            Console.Write("+");
            for (int i = 0; i <= 38; i++)
            {
                Console.Write("-");
            }
            Console.Write("+");
            Console.Write("\n");
        }
        static void Lines()
        {
            for (int lines = 0; lines <= 10; lines++)
            {
                Console.Write("|");
                for (int i = 0; i <= 38; i++)
                {
                    Console.Write(" ");
                }
                Console.Write("|");
                Console.Write("\n");
            }
        }
    }
}
