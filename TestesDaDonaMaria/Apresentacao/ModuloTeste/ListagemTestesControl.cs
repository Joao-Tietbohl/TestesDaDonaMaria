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

namespace TestesDaDonaMaria.Apresentacao.ModuloTeste
{
    public partial class ListagemTestesControl : UserControl
    {
        public ListagemTestesControl()
        {
            InitializeComponent();
        }


        public Teste ObtemTesteSelecionado()
        {
            return (Teste)listTestes.SelectedItem;
        }

        public void AtualizarRegistros(List<Teste> lista)
        {
            listTestes.Items.Clear();


            foreach (Teste t in lista)
            {
                listTestes.Items.Add(t);
            }
        }
    }
}
