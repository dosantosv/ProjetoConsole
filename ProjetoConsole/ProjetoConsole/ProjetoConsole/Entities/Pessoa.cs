using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoConsole.Entities
{
    public class Pessoa
    {
        public string Name { get; set; }

        public char Sexo { get; set; }
        public Pessoa()
        {

        }
        public Pessoa (string name, char sexo)
        {
            Name = name;
            Sexo = sexo;
        }
    }
}
