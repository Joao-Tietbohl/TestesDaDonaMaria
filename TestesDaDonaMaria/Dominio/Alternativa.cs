using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestesDaDonaMaria.Dominio
{
    public class Alternativa
    {
        public bool Correta { get; set; }
        public string Descricao { get; set; }
        public string Letra { get; set; }

        public Alternativa(bool correta, string descricao, string letra)
        {
            this.Descricao = descricao;
            this.Correta = correta;
            this.Letra = letra;
        }


        public override string ToString()
        {
            return $"{Letra}) {Descricao} ";
        }
    }
}
