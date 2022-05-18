using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesDaDonaMaria.Apresentacao.Compartilhado;

namespace TestesDaDonaMaria.Apresentacao.ModuloTeste
{
    public class ConfiguracaoToolBoxTestes : ConfiguracaoToolBoxBase
    {
        public override string TooltipInserir { get { return "Inserir um nova teste"; } }

        public override string TooltipEditar { get { return "Editar um teste existente"; } }

        public override string TooltipExcluir { get { return "Excluir um teste existente"; } }

        public override bool DuplicarHabilitado => true;

        public override bool GerarPDFHabilitado => true;
    }
}
