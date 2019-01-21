using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using Eventos;

namespace Eventos.Controller
{
    

    public class LoginController
    {

        int chave1 = 11;
        String chave2 = "a!b!c!d!e!f!g!h!i!j!k!l!m!n!o!p!q!r!s!t!u!v!w!x!y!z!1!2!3!4!5!@!.!ç!Ç!_!+!-!6!7!8!9!0!A!B!C!D!E!F!G!H!I!J!K!L!M!N!O!P!Q!R!S!T!U!V!W!X!Y!Z!" + "a!b!c!d!e!f!g!h!i!j!k!l!m!n!o!p!q!r!s!t!u!v!w!x!y!z!1!2!3!4!5!6!7!8!9!0!A!B!C!D!E!F!G!H!I!J!K!L!M!N!O!P!Q!R!S!T!U!V!W!X!Y!Z!"+ "a!b!c!d!e!f!g!h!i!j!k!l!m!n!o!p!q!r!s!t!u!v!w!x!y!z!1!2!3!4!5!6!7!8!9!0!A!B!C!D!E!F!G!H!I!J!K!L!M!N!O!P!Q!R!S!T!U!V!W!X!Y!Z!";
        String[] chave3;
        String user;
        String pass;

        private Gerenciador Gerenciador = new Gerenciador();
        private MySqlClassConnection MyConn = new MySqlClassConnection();


        //Função Reconectar usuário
        public bool Reconectar()
        {
            try
            {
                using (FileStream fileStream =
                File.OpenRead(@Application.UserAppDataPath + "\\appData.txt"))
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    user = this.DesencriptarValue(reader.ReadLine());
                    pass = this.DesencriptarValue(reader.ReadLine());
                }
                return this.Entrar(user, pass);
            }
            catch (Exception)
            {
                return false;
            }
        }

        //Função LogOff
        public bool LogOff()
        {
            setUser("");
            setPass("");

            if(File.Exists(@Application.UserAppDataPath + "\\appData.txt"))
            {
                File.Delete(@Application.UserAppDataPath + "\\appData.txt");
                return true;
            }
            return false;
        }

        //Função Get user
        public String getUser()
        {
            return user;
        }

        //Função Get pass
        public String getPass()
        {
            return pass;
        }

        //Função Set user
        public void setUser(String user) => this.user = user;

        //Função Set pass
        public void setPass(String pass) => this.pass = pass;

        //Função de Login
        public bool Entrar(String user, String pass)
        {

            this.user = user;
            this.pass = pass;

            string comand = "SELECT * FROM "+ Gerenciador.DatabaseLogin + "."+ Gerenciador.TableUsuariosLogin + " WHERE usuario='" + user + "' and senha='" + pass+ "';";

            if (MyConn.SelectComand(comand))
            {
                EventosController EventosController = new EventosController();
                EventosController.Iniciar(user, pass);
                return true;
            }
            return false;
        }
        
        //Função Conferir se o email está cadastrado
        public bool ConfirmarDados(string email)
        {
            String comand = "SELECT * FROM "+Gerenciador.DatabaseLogin+"."+Gerenciador.TableUsuariosLogin+" WHERE usuario='" + email +"';";
            return MyConn.SelectComand(comand);
        }

        //Função Conferir se o email e a senha estão cadastrados
        private bool ConfirmarDados(String email, String senha)
        {
            String comand = "SELECT * FROM " + Gerenciador.DatabaseLogin + "." + Gerenciador.TableUsuariosLogin + " WHERE usuario='" + email + "' AND senha='" + senha + "';";
            return MyConn.SelectComand(comand);
        }

        //Criar novo usuário
        public bool CriarConta(String nome, String sobrenome, String email, String senha)
        {
            if (ConfirmarDados(email))
            {
                return false;
            }
            else
            {
                String comand = "INSERT INTO "+Gerenciador.DatabaseLogin+"."+Gerenciador.TableUsuariosLogin+" (usuario, senha) VALUES('" + email + "', '" + senha + "');";
                MyConn.InsertComand(comand);
                SalvarCache(email, senha);
                return true;
            }
        }

        //Salva os dados de login em Application.UserAppDataPath
        public void SalvarCache(String email, String pass)
        {
            String Arquivo = @Application.UserAppDataPath+"\\appData.txt";
            this.user = email;
            this.pass = pass;

            if (File.Exists(Arquivo))
            {
                try
                {
                    File.Delete(Arquivo);
                    using (FileStream fileStream = File.Create(Arquivo))
                    using (StreamWriter writer = new StreamWriter(fileStream))
                    {
                        writer.WriteLine(this.EncriptarValue(email));
                        writer.WriteLine(this.EncriptarValue(pass));
                    }
                    File.SetAttributes(Arquivo, FileAttributes.Encrypted | FileAttributes.Hidden | FileAttributes.NotContentIndexed);
                }
                catch (Exception Ex)
                {
                    Console.Write(Ex.Message);
                }
            }
            else
            {
                try
                {
                    using (FileStream fileStream = File.Create(Arquivo))
                    using (StreamWriter writer = new StreamWriter(fileStream))
                    {
                        writer.WriteLine(this.EncriptarValue(email));
                        writer.WriteLine(this.EncriptarValue(pass));
                    }
                    File.SetAttributes(Arquivo, FileAttributes.Encrypted | FileAttributes.Hidden | FileAttributes.NotContentIndexed);
                }
                catch(Exception ex)
                {
                    MessageBox.Show("An error occurred while attempting to show the application." +
                                "The error is:" + ex.ToString());
                }
            }
        }


        //Encripta os dados
        private String EncriptarValue(String value)
        {
            String encriptado = "";
            chave3 = chave2.Split('!');

            try
            {
                for (int i = 0; i < value.Length; i++)
                {
                    for (int j = 0; j < chave3.Length; j++)
                    {
                        if (chave3[j] == value.Substring(i, 1))
                        {
                            encriptado = encriptado + chave3[j + chave1];
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while attempting to show the application." +
                                "The error is:" + ex.ToString());
            }
            return encriptado;
        }

        //Retira a encriptação
        private String DesencriptarValue(String value)
        {
            String desencriptado = "";
            chave3 = chave2.Split('!');
            try
            {
                for (int i = 0; i < value.Length; i++)
                {
                    for (int j = 0; j < chave3.Length; j++)
                    {
                        if (chave3[j] == value.Substring(i, 1))
                        {
                            desencriptado = desencriptado + chave3[j - chave1];
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while attempting to show the application." +
                                   "The error is:" + ex.ToString());
            }
            return desencriptado;
        }
        
        
    }
}
