using Eventos.Controller;
using Eventos.View;
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
        int yFeed = 50;
        int y = 1;

        public Eventos()
        {
            InitializeComponent();
            ConfigurarTela("Eventos");
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

        private void ConfigurarTela(string tela)
        {
            switch (tela)
            {
                case "Criar Evento":
                    panelCriarEvento.Show();
                    panelFeed.Hide();
                    //btCriarEvento
                    buttonCriarEvento.BackColor = Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
                    buttonCriarEvento.ForeColor = Color.Black;
                    //btEventos
                    buttonEventos.BackColor = Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(162)))), ((int)(((byte)(208)))));
                    buttonEventos.ForeColor = SystemColors.ButtonHighlight;
                    //btAmigos
                    buttonAmigos.BackColor = Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(162)))), ((int)(((byte)(208)))));
                    buttonAmigos.ForeColor = SystemColors.ButtonHighlight;
                    //btMeuPerfil
                    buttonMeuPerfil.BackColor = Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(162)))), ((int)(((byte)(208)))));
                    buttonMeuPerfil.ForeColor = SystemColors.ButtonHighlight;
                    //btConfiguracoes
                    buttonConfiguracoes.BackColor = Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(162)))), ((int)(((byte)(208)))));
                    buttonConfiguracoes.ForeColor = SystemColors.ButtonHighlight;
                    break;
                case "Eventos":
                    panelCriarEvento.Hide();
                    panelFeed.Show();
                    //btCriarEvento
                    buttonCriarEvento.BackColor = Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(162)))), ((int)(((byte)(208)))));
                    buttonCriarEvento.ForeColor = SystemColors.ButtonHighlight;
                    //btEventos
                    buttonEventos.BackColor = Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
                    buttonEventos.ForeColor = Color.Black;
                    //btAmigos
                    buttonAmigos.BackColor = Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(162)))), ((int)(((byte)(208)))));
                    buttonAmigos.ForeColor = SystemColors.ButtonHighlight;
                    //btMeuPerfil
                    buttonMeuPerfil.BackColor = Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(162)))), ((int)(((byte)(208)))));
                    buttonMeuPerfil.ForeColor = SystemColors.ButtonHighlight;
                    //btConfiguracoes
                    buttonConfiguracoes.BackColor = Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(162)))), ((int)(((byte)(208)))));
                    buttonConfiguracoes.ForeColor = SystemColors.ButtonHighlight;
                    break;
                case "Amigos":
                    panelCriarEvento.Hide();
                    panelFeed.Hide();
                    //btCriarEvento
                    buttonCriarEvento.BackColor = Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(162)))), ((int)(((byte)(208)))));
                    buttonCriarEvento.ForeColor = SystemColors.ButtonHighlight;
                    //btEventos
                    buttonEventos.BackColor = Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(162)))), ((int)(((byte)(208)))));
                    buttonEventos.ForeColor = SystemColors.ButtonHighlight;
                    //btAmigos
                    buttonAmigos.BackColor = Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
                    buttonAmigos.ForeColor = Color.Black;
                    //btMeuPerfil
                    buttonMeuPerfil.BackColor = Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(162)))), ((int)(((byte)(208)))));
                    buttonMeuPerfil.ForeColor = SystemColors.ButtonHighlight;
                    //btConfiguracoes
                    buttonConfiguracoes.BackColor = Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(162)))), ((int)(((byte)(208)))));
                    buttonConfiguracoes.ForeColor = SystemColors.ButtonHighlight;
                    break;
                case "Meu Perfil":
                    panelCriarEvento.Hide();
                    panelFeed.Hide();
                    //btCriarEvento
                    buttonCriarEvento.BackColor = Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(162)))), ((int)(((byte)(208)))));
                    buttonCriarEvento.ForeColor = SystemColors.ButtonHighlight;
                    //btEventos
                    buttonEventos.BackColor = Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(162)))), ((int)(((byte)(208)))));
                    buttonEventos.ForeColor = SystemColors.ButtonHighlight;
                    //btAmigos
                    buttonAmigos.BackColor = Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(162)))), ((int)(((byte)(208)))));
                    buttonAmigos.ForeColor = SystemColors.ButtonHighlight;
                    //btMeuPerfil
                    buttonMeuPerfil.BackColor = Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
                    buttonMeuPerfil.ForeColor = Color.Black;
                    //btConfiguracoes
                    buttonConfiguracoes.BackColor = Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(162)))), ((int)(((byte)(208)))));
                    buttonConfiguracoes.ForeColor = SystemColors.ButtonHighlight;
                    break;
                case "Configurações":
                    panelCriarEvento.Hide();
                    panelFeed.Hide();
                    //btCriarEvento
                    buttonCriarEvento.BackColor = Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(162)))), ((int)(((byte)(208)))));
                    buttonCriarEvento.ForeColor = SystemColors.ButtonHighlight;
                    //btEventos
                    buttonEventos.BackColor = Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(162)))), ((int)(((byte)(208)))));
                    buttonEventos.ForeColor = SystemColors.ButtonHighlight;
                    //btAmigos
                    buttonAmigos.BackColor = Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(162)))), ((int)(((byte)(208)))));
                    buttonAmigos.ForeColor = SystemColors.ButtonHighlight;
                    //btMeuPerfil
                    buttonMeuPerfil.BackColor = Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(162)))), ((int)(((byte)(208)))));
                    buttonMeuPerfil.ForeColor = SystemColors.ButtonHighlight;
                    //btConfiguracoes
                    buttonConfiguracoes.BackColor = Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
                    buttonConfiguracoes.ForeColor = Color.Black;
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            controller.LogOff();
            Application.Restart();
            Environment.Exit(0);
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            adicionarFeed();
        }

        private int adicionarFeed()
        {
            FeedItem feed = new FeedItem();
            feed.Location = new Point(17, yFeed);
            yFeed = (y * 235) + 50;
            y++;
            this.panelFeed.Controls.Add(feed);
            return yFeed;
        }
        
        private void buttonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            adicionarFeed();
        }

        private void buttonCriarEvento_Click(object sender, EventArgs e)
        {
            ConfigurarTela("Criar Evento");
        }
        
        private void buttonEventos_Click(object sender, EventArgs e)
        {
            ConfigurarTela("Eventos");
        }

        private void buttonAmigos_Click(object sender, EventArgs e)
        {
            ConfigurarTela("Amigos");
        }

        private void buttonMeuPerfil_Click(object sender, EventArgs e)
        {
            ConfigurarTela("Meu Perfil");
        }

        private void buttonConfiguracoes_Click(object sender, EventArgs e)
        {
            ConfigurarTela("Configurações");
        }
    }
}
