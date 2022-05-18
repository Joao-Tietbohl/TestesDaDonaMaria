namespace TestesDaDonaMaria.Apresentacao.ModuloDisciplina
{
    partial class MenuPrincipalForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.stripMenuPrincipal = new System.Windows.Forms.MenuStrip();
            this.cadastrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disciplinasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.materiasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.questoesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnInserir = new System.Windows.Forms.ToolStripButton();
            this.btnEditar = new System.Windows.Forms.ToolStripButton();
            this.btnExcluir = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDuplicar = new System.Windows.Forms.ToolStripButton();
            this.btnGerarPDF = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.panelRegistros = new System.Windows.Forms.Panel();
            this.stripMenuPrincipal.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // stripMenuPrincipal
            // 
            this.stripMenuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastrosToolStripMenuItem});
            this.stripMenuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.stripMenuPrincipal.Name = "stripMenuPrincipal";
            this.stripMenuPrincipal.Size = new System.Drawing.Size(550, 24);
            this.stripMenuPrincipal.TabIndex = 0;
            this.stripMenuPrincipal.Text = "menuStrip1";
            // 
            // cadastrosToolStripMenuItem
            // 
            this.cadastrosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testesToolStripMenuItem,
            this.disciplinasToolStripMenuItem,
            this.materiasToolStripMenuItem,
            this.questoesToolStripMenuItem});
            this.cadastrosToolStripMenuItem.Name = "cadastrosToolStripMenuItem";
            this.cadastrosToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.cadastrosToolStripMenuItem.Text = "Cadastros";
            // 
            // testesToolStripMenuItem
            // 
            this.testesToolStripMenuItem.Name = "testesToolStripMenuItem";
            this.testesToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.testesToolStripMenuItem.Text = "Testes";
            this.testesToolStripMenuItem.Click += new System.EventHandler(this.testesToolStripMenuItem_Click);
            // 
            // disciplinasToolStripMenuItem
            // 
            this.disciplinasToolStripMenuItem.Name = "disciplinasToolStripMenuItem";
            this.disciplinasToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.disciplinasToolStripMenuItem.Text = "Disciplinas";
            this.disciplinasToolStripMenuItem.Click += new System.EventHandler(this.DisciplinasMenuItem_Click);
            // 
            // materiasToolStripMenuItem
            // 
            this.materiasToolStripMenuItem.Name = "materiasToolStripMenuItem";
            this.materiasToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.materiasToolStripMenuItem.Text = "Materias";
            this.materiasToolStripMenuItem.Click += new System.EventHandler(this.materiasToolStripMenuItem_Click);
            // 
            // questoesToolStripMenuItem
            // 
            this.questoesToolStripMenuItem.Name = "questoesToolStripMenuItem";
            this.questoesToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.questoesToolStripMenuItem.Text = "Questoes";
            this.questoesToolStripMenuItem.Click += new System.EventHandler(this.questoesToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnInserir,
            this.btnEditar,
            this.btnExcluir,
            this.toolStripSeparator1,
            this.btnDuplicar,
            this.btnGerarPDF});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(550, 27);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnInserir
            // 
            this.btnInserir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnInserir.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnInserir.Image = global::TestesDaDonaMaria.Properties.Resources.streamline_icon_add_circle_48x48;
            this.btnInserir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnInserir.Name = "btnInserir";
            this.btnInserir.Size = new System.Drawing.Size(24, 24);
            this.btnInserir.Text = "toolStripButton1";
            this.btnInserir.Click += new System.EventHandler(this.btInserir_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEditar.Image = global::TestesDaDonaMaria.Properties.Resources.streamline_icon_pencil_2_48x48;
            this.btnEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(24, 24);
            this.btnEditar.Text = "toolStripButton2";
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnExcluir.Image = global::TestesDaDonaMaria.Properties.Resources.streamline_icon_bin_2_48x48;
            this.btnExcluir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(24, 24);
            this.btnExcluir.Text = "toolStripButton1";
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // btnDuplicar
            // 
            this.btnDuplicar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDuplicar.Image = global::TestesDaDonaMaria.Properties.Resources.streamline_icon_duplicate_file_48x48;
            this.btnDuplicar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDuplicar.Name = "btnDuplicar";
            this.btnDuplicar.Size = new System.Drawing.Size(24, 24);
            this.btnDuplicar.Text = "Duplicar";
            this.btnDuplicar.Click += new System.EventHandler(this.btnDuplicar_Click);
            // 
            // btnGerarPDF
            // 
            this.btnGerarPDF.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnGerarPDF.Image = global::TestesDaDonaMaria.Properties.Resources.streamline_icon_office_file_pdf_48x48;
            this.btnGerarPDF.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGerarPDF.Name = "btnGerarPDF";
            this.btnGerarPDF.Size = new System.Drawing.Size(24, 24);
            this.btnGerarPDF.Text = "PDF";
            this.btnGerarPDF.Click += new System.EventHandler(this.btnGerarPDF_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 437);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(550, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // panelRegistros
            // 
            this.panelRegistros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRegistros.Location = new System.Drawing.Point(0, 51);
            this.panelRegistros.Name = "panelRegistros";
            this.panelRegistros.Size = new System.Drawing.Size(550, 386);
            this.panelRegistros.TabIndex = 4;
            // 
            // MenuPrincipalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 459);
            this.Controls.Add(this.panelRegistros);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.stripMenuPrincipal);
            this.MainMenuStrip = this.stripMenuPrincipal;
            this.Name = "MenuPrincipalForm";
            this.Text = "MenuPrincipal";
            this.stripMenuPrincipal.ResumeLayout(false);
            this.stripMenuPrincipal.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip stripMenuPrincipal;
        private System.Windows.Forms.ToolStripMenuItem cadastrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disciplinasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem materiasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem questoesToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnInserir;
        private System.Windows.Forms.ToolStripButton btnEditar;
        private System.Windows.Forms.ToolStripButton btnExcluir;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel panelRegistros;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnDuplicar;
        private System.Windows.Forms.ToolStripButton btnGerarPDF;
    }
}