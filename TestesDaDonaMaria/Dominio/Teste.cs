using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestesDaDonaMaria.Dominio
{
    public class Teste : EntidadeBase<Teste>
    {
        public string Titulo { get; set; }
        public DateTime DataGeracao { get; set; }
        public int QuantidadeQuestoes { get; set; }
        public Disciplina Disciplina { get; set; }
        public Gabarito Gabarito { get; set; }
        public Materia Materia { get; set; }
        public List<Questao> listaQuestoes { get; set; }

        public override void Atualizar(Teste registro)
        {
            
        }

        public override string ToString()
        {
            return $"Título: {Titulo}, Disciplina: {Disciplina}, Matéria: {Materia}, Qtd questões: {QuantidadeQuestoes}";
        }

    }

   
}
