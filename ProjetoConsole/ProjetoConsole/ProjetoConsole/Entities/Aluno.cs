using ProjetoConsole.Data;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using ProjetoConsole.Entities;
using ProjetoConsole.Viewer;

namespace ProjetoConsole.Entities
{
    public class Aluno : Pessoa
    {
        public int RA { get; private set; }
        public DateTime DataNascimento { get; set; }
        public string Turma { get; set; }
        public double Media { get; set; }

        public List<string> Materias { get; set; }
        public Aluno()
        {
        }
        public Aluno (string name, char sexo, int ra)
        {
            Name = name;
            Sexo = sexo;
            RA = ra;
        }
        public Aluno(string name, char sexo, int ra, string turma, DateTime dataNascimento) : this(name, sexo, ra)
        {
            Turma = turma;
            DataNascimento = dataNascimento;
        }
        public Aluno (double media)
        {
            Media = media;
        }

        public override string ToString()
        {
            return "RA: "
            + RA
            + ", Nome: "
            + Name
            + ", Sexo: "
            + Sexo
            + ", Data de Nascimento: "
            + DataNascimento.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)
            + ", Turma: "
            + Turma;

        }

    }


}
