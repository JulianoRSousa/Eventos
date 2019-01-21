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
        private String CarregarDados(String user, String pass)
        {
            return "";// MyConn.Select(user,pass);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            labelNome.Text = this.CarregarDados(controller.getUser(), controller.getPass());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            controller.LogOff();
            Application.Restart();
            Environment.Exit(0);
        }
        

        
    }
}
