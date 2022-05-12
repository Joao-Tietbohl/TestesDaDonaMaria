using System.Collections.Generic;

namespace TestesDaDonaMaria.Dominio
{
    public class Disciplina : EntidadeBase<Disciplina>
    {
        public string Nome { get; set; }
        private List<Materia> Materias { get; }

        public override void Atualizar(Disciplina registro)
        {
            
        }

        public override string ToString()
        {
            string materiasToString = "";
            
            if (Materias != null)
            {
                foreach (var materia in Materias)
                    materiasToString += materia.Titulo + ", ";
            }
            
            
            return $"Número: {Numero}, Nome: {Nome}";
        }
    }
}