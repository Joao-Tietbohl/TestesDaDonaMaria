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

namespace TestesDaDonaMaria.Apresentacao.ModuloDisciplina
{
    public partial class ListagemDisciplinasControl : UserControl
    {
        public ListagemDisciplinasControl()
        {
            InitializeComponent();
        }

        public Disciplina ObtemDisciplinaSelecionada()
        {
            return (Disciplina)listDisciplinas.SelectedItem;
        }

        public void AtualizarRegistros(List<Disciplina> lista)
        {
            listDisciplinas.Items.Clear();

            foreach(Disciplina d in lista)
            {
                listDisciplinas.Items.Add(d);
            }
        }
    }
}
