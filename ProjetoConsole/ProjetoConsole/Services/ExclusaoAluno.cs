using ProjetoConsole.Data;
using ProjetoConsole.Entities;
using ProjetoConsole.Viewer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoConsole.Services
{
    public class ExclusaoAluno
    {
        Menu m = new Menu();
        public void ExcluirAluno()
        {
            try
            {
                Console.Clear();

                if (Repository.list.Any())
                {
                    foreach (Aluno obj in Repository.list)
                    {
                        Console.WriteLine(obj);
                    }
                    Console.WriteLine();

                    int searchRa = 0;
                    bool valorValido = false;

                    while (!valorValido)
                    {
                        Console.Write("Informe o RA do Aluno que será excluído: ");

                        valorValido = int.TryParse(Console.ReadLine(), out searchRa);

                        if (!valorValido)
                        {
                            Console.WriteLine("Valor inválido. Por favor, digite um número inteiro válido.");
                        }
                    }

                    List<Aluno> alunosEncontrados = Repository.list.FindAll(x => x.RA == searchRa);

                    if (alunosEncontrados.Count == 0)
                    {
                        Console.WriteLine("Nenhum Aluno com esse RA foi encontrado!");
                        Console.ReadLine();
                        ExcluirAluno();
                    }

                    foreach (Aluno aluno in alunosEncontrados)
                    {
                        Repository.list.Remove(aluno);
                        Console.WriteLine("Aluno removido com sucesso!");
                    }

                    m.RetornarMenu();
                }
                else
                {
                    Console.WriteLine("Nenhum aluno cadastrado!");
                    m.RetornarMenu();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Código executado inadequadamente! " + ex.Message);
                m.RetornarMenu();
            }

        }
    }
}
