using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesDaDonaMaria.Apresentacao.Compartilhado;

namespace TestesDaDonaMaria.Apresentacao.ModuloQuestao
{
    public class ConfiguracaoToolboxQuestao : ConfiguracaoToolBoxBase
    {
        public override string TooltipInserir { get { return "Inserir uma nova questão"; } }

        public override string TooltipEditar { get { return "Editar uma questão existente"; } }

        public override string TooltipExcluir { get { return "Excluir uma questão existente"; } }

        public override bool DuplicarHabilitado => false;

        public override bool GerarPDFHabilitado => false;
    }
}

