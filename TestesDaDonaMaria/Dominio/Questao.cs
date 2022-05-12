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
        public List<string> alternativas { get; set; }
        public string Bimestre { get; set; }
        public Materia Materia { get; set; }

        public override void Atualizar(Questao registro)
        {
            
        }

       
       

    }
}
