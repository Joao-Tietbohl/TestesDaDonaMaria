using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestesDaDonaMaria.Infra;
using TestesDaDonaMaria.Apresentacao.Compartilhado;
using TestesDaDonaMaria.Apresentacao.ModuloMateria;

namespace TestesDaDonaMaria.Apresentacao.ModuloDisciplina
{
    public partial class MenuPrincipalForm : Form
    {

        private ControladorBase controlador;
        private Dictionary<string, ControladorBase> controladores;
        private DataContext contextoDados;


        public MenuPrincipalForm(DataContext contextoDados)
        {
            InitializeComponent();

            this.contextoDados = contextoDados;

            InicializarControladores();
        }

        private void InicializarControladores()
        {
            var repositorioDisciplina = new RepositorioDisciplina(contextoDados);
            var repositorioMateria = new RepositorioMateria(contextoDados);


            controladores = new Dictionary<string, ControladorBase>();
            controladores.Add("Disciplinas", new ControladorDisciplina(repositorioDisciplina));
            controladores.Add("Materias", new ControladorMateria(repositorioMateria, repositorioDisciplina));

        }

        private void DisciplinasMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarToolbox(new ConfiguracaoToolBoxDisciplina());
                         
            var opcaoSelecionada = (ToolStripMenuItem)sender;

            SelecionarControlador(opcaoSelecionada);

            CarregarListagem();
        }

        private void materiasToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ConfigurarToolbox(new ConfiguracaoToolboxMateria());

            var opcaoSelecionada = (ToolStripMenuItem)sender;

            SelecionarControlador(opcaoSelecionada);

            CarregarListagem();
        }

        private void btInserir_Click(object sender, EventArgs e)
        {
            controlador.Inserir();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            controlador.Editar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            controlador.Excluir();
        }

        private void SelecionarControlador(ToolStripMenuItem opcaoSelecionada)
        {
            var tipo = opcaoSelecionada.Text;

            controlador = controladores[tipo];
        }

        private void CarregarListagem()
        {
            var listagemControl = controlador.ObtemListagem();

            panelRegistros.Controls.Clear();

            listagemControl.Dock = DockStyle.Fill;

            panelRegistros.Controls.Add(listagemControl);
        }

        private void ConfigurarToolbox(ConfiguracaoToolBoxBase configuracao)
        {
            ConfigurandoTooltips(configuracao);

            ConfigurandoBotoes(configuracao);
        }

        private void ConfigurandoBotoes(ConfiguracaoToolBoxBase configuracao)
        {
            btnInserir.Enabled = configuracao.InserirHabilitado;
            btnEditar.Enabled = configuracao.EditarHabilitado;
            btnExcluir.Enabled = configuracao.ExcluirHabilitado;
        }

        private void ConfigurandoTooltips(ConfiguracaoToolBoxBase configuracao)
        {
            btnInserir.ToolTipText = configuracao.TooltipInserir;
            btnEditar.ToolTipText = configuracao.TooltipEditar;
            btnExcluir.ToolTipText = configuracao.TooltipExcluir;
            
        }

       
    }
}