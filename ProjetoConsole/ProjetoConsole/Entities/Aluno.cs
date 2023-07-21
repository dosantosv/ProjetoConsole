using System;
using System.Globalization;

namespace ProjetoConsole.Entities
{
    public class Aluno : Pessoa
    {
        public int RA { get; private set; }
        public DateTime DataNascimento { get; set; }
        public string Turma { get; set; }
        public decimal Media { get; set; }
        public string Materia { get; set; }
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
