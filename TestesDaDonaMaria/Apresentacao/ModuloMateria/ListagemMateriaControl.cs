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

namespace TestesDaDonaMaria.Apresentacao.ModuloMateria
{
    public partial class ListagemMateriaControl : UserControl
    {
        public ListagemMateriaControl()
        {
            InitializeComponent();
        }

        public Materia ObtemMateriaSelecionada()
        {
            return (Materia)listMaterias.SelectedItem;
        }

        public void AtualizarRegistros(List<Materia> lista)
        {
            listMaterias.Items.Clear();

            List<Materia> listaOrdemAlfabetica = lista;
            
            listaOrdemAlfabetica.Sort((x, y) => string.Compare(x.Nome, y.Nome));
            
            foreach (Materia m in listaOrdemAlfabetica)
            {
                listMaterias.Items.Add(m);
            }
        }
    }
}
