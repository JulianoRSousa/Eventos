using Eventos.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eventos
{
    public partial class Login : Form
    {
        private LoginController Controller = new LoginController();
        private int X = 0;
        private int Y = 0;

        //Inicio
        public Login()
        {
            InitializeComponent();
            ConfigurarTelaLogin("CriarConta");
            Reconectar();
        }

        //Reconectar usuário
        private void Reconectar()
        {
            if (Controller.Reconectar())
                ConfigurarTelaLogin("Inicio");
            else
                ConfigurarTelaLogin("Criar Conta");
        }
        
        //controle layout
        private void panelRightLogin_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            X = this.Left - MousePosition.X;
            Y = this.Top - MousePosition.Y;
        }

        //controle layout
        private void panelRightLogin_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            this.Left = X + MousePosition.X;
            this.Top = Y + MousePosition.Y;
        }

        //controle layout
        private void panelLogin_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            X = this.Left - MousePosition.X;
            Y = this.Top - MousePosition.Y;
        }

        //controle layout
        private void panelLogin_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            this.Left = X + MousePosition.X;
            this.Top = Y + MousePosition.Y;
        }

        //botão Fechar
        private void buttonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Minimizar
        private void buttonMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        //Configurar tela
        private void ConfigurarTelaLogin(String tela)
        {
            switch (tela)
            {
                case "Criar Conta":
                    panelCriarConta.Show();
                    panelCriarConta.BringToFront();
                    panelLogin.Hide();
                    panelTermos.Hide();
                    break;
                case "Login":
                    panelCriarConta.Show();
                    panelLogin.Show();
                    panelLogin.BringToFront();
                    panelTermos.Hide();
                    break;
                case "Termos de privacidade":
                    panelCriarConta.Show();
                    panelLogin.Hide();
                    panelTermos.Show();
                    panelTermos.BringToFront();
                    break;
                case "Erro Login":
                    panelCriarConta.Show();
                    panelLogin.Show();
                    panelLogin.BringToFront();
                    panelTermos.Hide();
                    labelEmailSenhaInvalida.Show();
                    labelLoginEmail.ForeColor = System.Drawing.Color.Tomato;
                    labelLoginSenha.ForeColor = System.Drawing.Color.Tomato;
                    break;
                case "Erro Cadastro":
                    panelCriarConta.Show();
                    panelLogin.Hide();
                    panelTermos.Hide();
                    labelCadastroContaInvalida.Show();
                    labelEmail.ForeColor = System.Drawing.Color.Tomato;
                    labelSenha.ForeColor = System.Drawing.Color.Tomato;
                    labelNome.ForeColor = System.Drawing.Color.Tomato;
                    labelSobrenome.ForeColor = System.Drawing.Color.Tomato;
                    break;
                case "Inicio":
                    this.Close();
                    break;
            }
        }

        //Fechar
        public void Fechar()
        {
            for (int intIndex = Application.OpenForms.Count - 1; intIndex >= 0; intIndex--)
            {
                if (Application.OpenForms[intIndex] != this)
                    Application.OpenForms[intIndex].Close();
            }
            this.Close();
        }

        //tela login
        private void labelEntre_MouseClick(object sender, MouseEventArgs e)
        {
            ConfigurarTelaLogin("Login");
        }

        //tela criar conta
        private void labelCriarAgora_Click(object sender, EventArgs e)
        {
            ConfigurarTelaLogin("Criar Conta");
        }

        //Login com Facebook
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        //Termos de Privacidade
        private void labelTermosDePrivacidade_MouseClick(object sender, MouseEventArgs e)
        {
            ConfigurarTelaLogin("Termos de privacidade");
        }

        //botão voltar
        private void buttonTermosVoltar_Click(object sender, EventArgs e)
        {
            ConfigurarTelaLogin("Criar Conta");
        }
        
        //Login
        private void buttonEntrar_Click(object sender, EventArgs e)
        {
            String vazio = "";

            if ((textBoxEmailLogin.Text != vazio) && (textBoxSenhaLogin.Text != vazio) && Controller.Entrar(textBoxEmailLogin.Text, textBoxSenhaLogin.Text))
            {
                ConfigurarTelaLogin("Inicio");
                Controller.SalvarDados(textBoxEmailLogin.Text, textBoxSenhaLogin.Text);
            }
            else
            {
                if ((textBoxEmailLogin.Text != vazio) || (textBoxSenhaLogin.Text != vazio))
                {
                    MessageBox.Show("Informe todos os campos");
                }
                ConfigurarTelaLogin("Erro Login");
            }

        }

        //Criar Conta
        private void buttonCriarConta_Click(object sender, EventArgs e)
        {
            String vazio = "";

            if ((textBoxNomeCadastro.Text != vazio) && (textBoxSobrenomeCadastro.Text != vazio) && (textBoxEmailCadastro.Text != vazio) && (textBoxSenhaCadastro.Text != vazio) && Controller.CriarConta(textBoxNomeCadastro.Text, textBoxSobrenomeCadastro.Text, textBoxEmailCadastro.Text, textBoxSenhaCadastro.Text))
            {
                
                Controller.SalvarDados(textBoxEmailCadastro.Text, textBoxSenhaCadastro.Text);
                MessageBox.Show("Conta Criada Com Sucesso!");
                ConfigurarTelaLogin("Inicio");
            }
            else
            {
                if((textBoxNomeCadastro.Text == vazio) || (textBoxSobrenomeCadastro.Text == vazio) || (textBoxEmailCadastro.Text == vazio) || (textBoxSenhaCadastro.Text == vazio))
                MessageBox.Show("Informe todos os campos");
                ConfigurarTelaLogin("Erro Cadastro");
            }
        }
    }
}
