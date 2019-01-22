namespace Eventos.View
{
    partial class FeedItem
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelFeedItemTitulo = new System.Windows.Forms.Label();
            this.labelFeedItemDescricao = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.labelFeedItemHorario = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelFeedItemHorario);
            this.panel1.Controls.Add(this.labelFeedItemTitulo);
            this.panel1.Controls.Add(this.labelFeedItemDescricao);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 260);
            this.panel1.TabIndex = 0;
            // 
            // labelFeedItemTitulo
            // 
            this.labelFeedItemTitulo.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFeedItemTitulo.Location = new System.Drawing.Point(3, 25);
            this.labelFeedItemTitulo.Name = "labelFeedItemTitulo";
            this.labelFeedItemTitulo.Size = new System.Drawing.Size(430, 25);
            this.labelFeedItemTitulo.TabIndex = 1;
            this.labelFeedItemTitulo.Text = "Titulo";
            // 
            // labelFeedItemDescricao
            // 
            this.labelFeedItemDescricao.Font = new System.Drawing.Font("Lucida Sans", 11.25F);
            this.labelFeedItemDescricao.Location = new System.Drawing.Point(15, 66);
            this.labelFeedItemDescricao.Margin = new System.Windows.Forms.Padding(0);
            this.labelFeedItemDescricao.Name = "labelFeedItemDescricao";
            this.labelFeedItemDescricao.Size = new System.Drawing.Size(390, 175);
            this.labelFeedItemDescricao.TabIndex = 2;
            this.labelFeedItemDescricao.Text = "Breve Descrição do evento";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 40);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(430, 220);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(430, 80);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(170, 180);
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // labelFeedItemHorario
            // 
            this.labelFeedItemHorario.Font = new System.Drawing.Font("Lucida Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFeedItemHorario.Location = new System.Drawing.Point(430, 0);
            this.labelFeedItemHorario.Name = "labelFeedItemHorario";
            this.labelFeedItemHorario.Size = new System.Drawing.Size(170, 80);
            this.labelFeedItemHorario.TabIndex = 5;
            this.labelFeedItemHorario.Text = "Horário";
            this.labelFeedItemHorario.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // FeedItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "FeedItem";
            this.Size = new System.Drawing.Size(600, 260);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelFeedItemTitulo;
        private System.Windows.Forms.Label labelFeedItemDescricao;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label labelFeedItemHorario;
    }
}
