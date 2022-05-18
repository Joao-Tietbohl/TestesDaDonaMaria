using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesDaDonaMaria.Apresentacao.Compartilhado;

namespace TestesDaDonaMaria.Apresentacao.ModuloDisciplina
{
    public class ConfiguracaoToolBoxDisciplina : ConfiguracaoToolBoxBase
    {
        public override string TooltipInserir { get { return "Inserir uma nova disciplina"; } }

        public override string TooltipEditar { get { return "Editar uma disciplina existente"; } }

        public override string TooltipExcluir { get { return "Excluir uma disciplina existente"; } }

        public override bool DuplicarHabilitado => false;

        public override bool GerarPDFHabilitado => false;

    }
}
