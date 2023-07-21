namespace ProjetoConsole.Entities
{
    public class Professor : Pessoa
    {

        public string Materia { get; set; }
        public string Turma { get; set; }
        public int Id { get; set; }
        public Professor()
        {
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
