using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesDaDonaMaria.Apresentacao.Compartilhado;

namespace TestesDaDonaMaria.Apresentacao.ModuloMateria
{
    public class ConfiguracaoToolboxMateria : ConfiguracaoToolBoxBase
    {
        public override string TooltipInserir { get { return "Inserir uma nova matéria"; } }

        public override string TooltipEditar { get { return "Editar uma matéria existente"; } }

        public override string TooltipExcluir { get { return "Excluir uma matéria existente"; } }

        public override bool DuplicarHabilitado => false;

        public override bool GerarPDFHabilitado => false;

    }
}
