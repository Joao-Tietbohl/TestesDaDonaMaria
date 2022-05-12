using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestesDaDonaMaria.Apresentacao.Compartilhado
{
    public abstract class ConfiguracaoToolBoxBase
    {
       
            public abstract string TooltipInserir { get; }

            public abstract string TooltipEditar { get; }

            public abstract string TooltipExcluir { get; }

           


            public virtual bool InserirHabilitado { get { return true; } }

            public virtual bool EditarHabilitado { get { return true; } }

            public virtual bool ExcluirHabilitado { get { return true; } }

         
    }
}

