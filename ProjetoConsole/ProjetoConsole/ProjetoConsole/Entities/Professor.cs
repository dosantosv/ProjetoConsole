using ProjetoConsole.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoConsole.Entities;
using ProjetoConsole.Viewer;
using System.Globalization;

namespace ProjetoConsole.Entities
{
    public class Professor : Pessoa
    {

        public string Materia { get; set; }
        public string Turma { get; set; }
        public int Id { get; set; }
        public List<Aluno> Alunos { get; set; }
        public Professor()
        {
        }
        public Professor(string name, char sexo, int id, string materia, string turma)
        {
            Name = name;
            Sexo = sexo;
            Id = id;
            Materia = materia;
            Turma = turma;
        }

        public Professor(string name, char sexo, string materia, int id, string turma)
        {
            Name = name;
            Sexo = sexo;
            Materia = materia;
            Id = id;
            Turma = turma;
        }
        public override string ToString()
        {
            return "ID: "
            + Id
            + ", Nome: "
            + Name
            + ", Sexo: "
            + Sexo
            + ", Materia: "
            + Materia
            + ", Turma: "
            + Turma;
        }
    }
}
