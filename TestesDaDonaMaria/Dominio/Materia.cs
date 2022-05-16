using System.Collections.Generic;

namespace TestesDaDonaMaria.Dominio
{
    public class Materia : EntidadeBase<Materia>
    {
        public string Titulo { get; set; }
        public Serie? Serie { get; set; }
        public Disciplina Disciplina { get; set; }
        public List<Questao> Questoes { get; set; }

        public override void Atualizar(Materia registro)
        {
            
        }

        public override string ToString()
        {
            return $"Disciplina: {Disciplina.Nome},  Título: {Titulo}, Série: {Serie}";
        }
    }

    public enum Serie
    {
        Primeira, Segunda
    }

}
