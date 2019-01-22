using Eventos.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eventos
{
    public partial class Eventos : Form
    {
        LoginController controller = new LoginController();
        EventosController EventosController = new EventosController();
        private MySqlClassConnection MyConn = new MySqlClassConnection();
        int yFeed = 0;
        int y = 1;

        public Eventos()
        {
            InitializeComponent();
            this.Reconectar();
        }
        
        private void Reconectar()
        {
            if (!controller.Reconectar())
            {
                this.Visible = false;
                Login login = new Login();
                login.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            controller.LogOff();
            Application.Restart();
            Environment.Exit(0);
        }

        private void Eventos_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            adicionarFeed();
        }

        private int adicionarFeed()
        {
            criarFeed(yFeed);
            yFeed = y * 260;
            y++;
            return yFeed;
        }

        public void criarFeed(int valory)
        {
            Panel panelFeed = new Panel();
            Label labelFeedTitulo = new Label();
            PictureBox pictureBoxFeedCapa = new PictureBox();
            Label labelFeedDescricao = new Label();

            // 
            // labelFeedTitulo
            // 
            labelFeedTitulo.Font = new Font("Comic Sans MS", 15.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            labelFeedTitulo.Location = new Point(10, 10);
            labelFeedTitulo.Margin = new Padding(0);
            labelFeedTitulo.MaximumSize = new Size(450, 35);
            labelFeedTitulo.MinimumSize = new Size(90, 7);
            labelFeedTitulo.Name = "labelFeedTitulo";
            labelFeedTitulo.Size = new Size(450, 50);
            labelFeedTitulo.TabIndex = 0;
            labelFeedTitulo.Text = "Titulo do evento";
            // 
            // labelFeedDescricao
            // 
            labelFeedDescricao.Font = new Font("HoloLens MDL2 Assets", 15.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            labelFeedDescricao.Location = new Point(45, 45);
            labelFeedDescricao.MaximumSize = new Size(415, 160);
            labelFeedDescricao.MinimumSize = new Size(83, 32);
            labelFeedDescricao.Name = "labelFeedDescricao";
            labelFeedDescricao.Size = new Size(415, 160);
            labelFeedDescricao.TabIndex = 0;
            labelFeedDescricao.Text = "label1";
            // 
            // pictureBoxFeedCapa
            // 
            pictureBoxFeedCapa.Location = new Point(0, 30);
            pictureBoxFeedCapa.Margin = new Padding(0);
            pictureBoxFeedCapa.Name = "pictureBoxFeedCapa";
            pictureBoxFeedCapa.Size = new Size(460, 190);
            pictureBoxFeedCapa.TabIndex = 0;
            pictureBoxFeedCapa.TabStop = false;
            // 
            // panelFeed
            // 

            panelFeed.Controls.Add(labelFeedTitulo);
            panelFeed.Controls.Add(labelFeedDescricao);
            panelFeed.Controls.Add(pictureBoxFeedCapa);
            panelFeed.Location = new Point(5, yFeed);
            panelFeed.Margin = new Padding(0);
            panelFeed.MaximumSize = new Size(600, 250);
            panelFeed.MinimumSize = new Size(120, 50);
            panelFeed.Name = "panelFeed";
            panelFeed.Size = new Size(600, 250);
            panelFeed.TabIndex = 0;
            panelFeed.BackColor = SystemColors.ActiveCaption;

            this.Controls.Add(panelFeed);
        }
    }
}
