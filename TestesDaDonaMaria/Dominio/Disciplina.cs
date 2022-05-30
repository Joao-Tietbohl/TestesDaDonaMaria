using System;
using System.Collections.Generic;

namespace TestesDaDonaMaria.Dominio
{
    public class Disciplina : EntidadeBase<Disciplina>
    {
       
        private List<Materia> materias = new List<Materia>();


        public string Nome { get; set; }
        public List<Materia> Materias { get { return materias; } }

        public override void Atualizar(Disciplina registro)
        {
            
        }

        public override string ToString()
        {
            string materiasToString = "";
            
            if (Materias != null)
            {
                foreach (var materia in Materias)
                    materiasToString += materia.Nome + ", ";
            }
            
            
            return $"Número: {Numero}, Nome: {Nome}";
        }

        internal Disciplina Clonar()
        {
            return MemberwiseClone() as Disciplina;
        }
    }
}