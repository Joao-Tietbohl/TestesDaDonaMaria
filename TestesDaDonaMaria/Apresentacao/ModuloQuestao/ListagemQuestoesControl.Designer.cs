namespace TestesDaDonaMaria.Apresentacao.ModuloQuestao
{
    partial class ListagemQuestoesControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listQuestoes = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listQuestoes
            // 
            this.listQuestoes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listQuestoes.FormattingEnabled = true;
            this.listQuestoes.ItemHeight = 15;
            this.listQuestoes.Location = new System.Drawing.Point(0, 0);
            this.listQuestoes.Name = "listQuestoes";
            this.listQuestoes.Size = new System.Drawing.Size(363, 309);
            this.listQuestoes.TabIndex = 2;
            // 
            // ListagemQuestoesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listQuestoes);
            this.Name = "ListagemQuestoesControl";
            this.Size = new System.Drawing.Size(363, 309);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listQuestoes;
    }
}
