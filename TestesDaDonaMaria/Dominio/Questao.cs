using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestesDaDonaMaria.Dominio
{
    public class Questao : EntidadeBase<Questao>
    {
        public string Enunciado { get; set; }
        public List<Alternativa> Alternativas { get; set; }     
        public Materia Materia { get; set; }

        public Questao()
        {
            Alternativas = new List<Alternativa>();
        }

        public override void Atualizar(Questao registro)
        {
            
        }


        public override string ToString()
        {
            return $"Enunciado: {Enunciado}, Materia: {Materia.Titulo}";
        }

    }
}
