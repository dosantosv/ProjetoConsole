using ProjetoConsole.Data;
using ProjetoConsole.Entities;
using ProjetoConsole.Viewer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoConsole.Services
{
    public class ExclusaoProfessor
    {
        Menu m = new Menu();
        public void ExcluirProfessor()
        {
            try
            {
                Console.Clear();
                if (Repository.listP.Any())
                {

                    foreach (Professor obj in Repository.listP)
                    {
                        Console.WriteLine(obj);
                    }
                    Console.WriteLine();

                    int searchId = 0;
                    bool valorValido = false;

                    while (!valorValido)
                    {
                        Console.Write("Informe o ID do professor que será excluído: ");

                        valorValido = int.TryParse(Console.ReadLine(), out searchId);

                        if (!valorValido)
                        {
                            Console.WriteLine("Valor inválido. Por favor, digite um número inteiro válido.");
                        }
                    }

                    List<Professor> professoresEncontrados = Repository.listP.FindAll(x => x.Id == searchId);

                    if (professoresEncontrados.Count == 0)
                    {
                        Console.WriteLine("Nenhum professor com esse ID foi encontrado!");
                        Console.ReadLine();
                        ExcluirProfessor();
                    }

                    foreach (Professor professor in professoresEncontrados)
                    {
                        Repository.listP.Remove(professor);
                        Console.WriteLine("Professor removido com sucesso!");
                    }

                    m.RetornarMenu();
                }
                else
                {
                    Console.WriteLine("Nenhum professor cadastrado!");
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


