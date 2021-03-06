﻿using Eventos.Controller;
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
        private LoginController LoginController = new LoginController();
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
            if (LoginController.Reconectar())
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

        //Minimizar
        private void buttonMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        //botão voltar
        private void buttonTermosVoltar_Click(object sender, EventArgs e)
        {
            ConfigurarTelaLogin("Criar Conta");
        }
        
        //Configurar tela
        public void ConfigurarTelaLogin(string tela)
        {
            switch (tela)
            {
                case "Criar Conta":
                    panelCriarConta.Show();
                    panelCriarConta.BringToFront();
                    panelLogin.Hide();
                    panelTermos.Hide();
                    labelNome.ForeColor = System.Drawing.SystemColors.ButtonShadow;
                    labelSobrenome.ForeColor = System.Drawing.SystemColors.ButtonShadow;
                    labelEmailCadastro.ForeColor = System.Drawing.SystemColors.ButtonShadow;
                    labelSenhaCadastro.ForeColor = System.Drawing.SystemColors.ButtonShadow;
                    labelCadastroContaInvalida.Hide();
                    textBoxEmailCadastro.Text = "";
                    textBoxSenhaCadastro.Text = "";
                    textBoxNomeCadastro.Text = "";
                    textBoxSobrenomeCadastro.Text = "";
                    break;
                case "Login":
                    panelCriarConta.Show();
                    panelLogin.Show();
                    panelLogin.BringToFront();
                    panelTermos.Hide();
                    labelEsqueciMinhaSenhaLogin.Hide();
                    labelEmailSenhaInvalida.Hide();
                    labelLoginEmail.ForeColor = System.Drawing.SystemColors.ButtonShadow;
                    labelLoginSenha.ForeColor = System.Drawing.SystemColors.ButtonShadow;
                    textBoxEmailLogin.Text = "";
                    textBoxSenhaLogin.Text = "";
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
                    labelEsqueciMinhaSenhaLogin.Show();
                    break;
                case "Erro Cadastro":
                    panelCriarConta.Show();
                    panelLogin.Hide();
                    panelTermos.Hide();
                    labelCadastroContaInvalida.Show();
                    labelEmailCadastro.ForeColor = System.Drawing.Color.Tomato;
                    labelSenhaCadastro.ForeColor = System.Drawing.Color.Tomato;
                    labelNome.ForeColor = System.Drawing.Color.Tomato;
                    labelSobrenome.ForeColor = System.Drawing.Color.Tomato;
                    break;
                case "Email já cadastrado":
                    panelCriarConta.Show();
                    MessageBox.Show("Email já cadastrado!");
                    panelLogin.Show();
                    panelLogin.BringToFront();
                    panelTermos.Hide();
                    labelEsqueciMinhaSenha.Show();
                    break;
                case "Inicio":
                    this.Close();
                    break;
            }
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
        
        //Login
        private void buttonEntrar_Click(object sender, EventArgs e)
        {
            String vazio = "";

            if ((textBoxEmailLogin.Text != vazio) && (textBoxSenhaLogin.Text != vazio) && LoginController.Entrar(textBoxEmailLogin.Text, textBoxSenhaLogin.Text))
            {
                ConfigurarTelaLogin("Inicio");
                LoginController.SalvarCache(textBoxEmailLogin.Text, textBoxSenhaLogin.Text);
            }
            else
            {
                if ((textBoxEmailLogin.Text == vazio) || (textBoxSenhaLogin.Text == vazio))
                {
                    MessageBox.Show("Informe todos os campos");
                    ConfigurarTelaLogin("Erro Login");
                    return;
                }
                else
                {
                    ConfigurarTelaLogin("Erro Login");
                }

                
            }

        }

        //Criar Conta
        private void buttonCriarConta_Click(object sender, EventArgs e)
        {
            String vazio = "";

            if ((textBoxNomeCadastro.Text != vazio) && (textBoxSobrenomeCadastro.Text != vazio) && (textBoxEmailCadastro.Text != vazio) && (textBoxSenhaCadastro.Text != vazio) && LoginController.CriarConta(textBoxNomeCadastro.Text, textBoxSobrenomeCadastro.Text, textBoxEmailCadastro.Text, textBoxSenhaCadastro.Text))
            {

                LoginController.SalvarCache(textBoxEmailCadastro.Text, textBoxSenhaCadastro.Text);
                MessageBox.Show("Conta Criada Com Sucesso!");
                ConfigurarTelaLogin("Inicio");
            }
            else
            {
                if ((textBoxNomeCadastro.Text == vazio) || (textBoxSobrenomeCadastro.Text == vazio) || (textBoxEmailCadastro.Text == vazio) || (textBoxSenhaCadastro.Text == vazio)) { 
                    MessageBox.Show("Informe todos os campos");
                ConfigurarTelaLogin("Erro Cadastro");
            }
                if (LoginController.ConfirmarDados(textBoxEmailCadastro.Text))
                {
                    ConfigurarTelaLogin("Esqueci minha senha");
                }
            }
        }

        private void labelEntre_Click(object sender, EventArgs e)
        {
            ConfigurarTelaLogin("Login");
        }

        private void labelEsqueciMinhaSenhaLogin_Click(object sender, EventArgs e)
        {

        }
    }
}
