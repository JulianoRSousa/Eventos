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
    }
}
