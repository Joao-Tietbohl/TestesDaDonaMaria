using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestesDaDonaMaria.Dominio;

namespace TestesDaDonaMaria.Apresentacao.ModuloQuestao
{
    public partial class ListagemQuestoesControl : UserControl
    {
        public ListagemQuestoesControl()
        {
            InitializeComponent();
        }

        public Questao ObtemQuestaoSelecionada()
        {
            return (Questao)listQuestoes.SelectedItem;
        }

        public void AtualizarRegistros(List<Questao> lista)
        {
            listQuestoes.Items.Clear();


            foreach (Questao q in lista)
            {
                listQuestoes.Items.Add(q);
            }
        }
    }
}
