using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace Eventos.Controller
{
    public class LoginController
    {

        int chave1 = 11;
        String chave2 = "a!b!c!d!e!f!g!h!i!j!k!l!m!n!o!p!q!r!s!t!u!v!w!x!y!z!1!2!3!4!5!@!.!ç!Ç!_!+!-!6!7!8!9!0!A!B!C!D!E!F!G!H!I!J!K!L!M!N!O!P!Q!R!S!T!U!V!W!X!Y!Z!" + "a!b!c!d!e!f!g!h!i!j!k!l!m!n!o!p!q!r!s!t!u!v!w!x!y!z!1!2!3!4!5!6!7!8!9!0!A!B!C!D!E!F!G!H!I!J!K!L!M!N!O!P!Q!R!S!T!U!V!W!X!Y!Z!"+ "a!b!c!d!e!f!g!h!i!j!k!l!m!n!o!p!q!r!s!t!u!v!w!x!y!z!1!2!3!4!5!6!7!8!9!0!A!B!C!D!E!F!G!H!I!J!K!L!M!N!O!P!Q!R!S!T!U!V!W!X!Y!Z!";
        String[] chave3;
        String user;
        String pass;
        

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

            String comand = "Select * from test.usuario where email='" + user + "' and senha='" + pass+ "';";

            if (MyConn.SelectComand(comand))
            {
                EventosController EventosController = new EventosController();
                EventosController.Iniciar(user, pass);
                return true;
            }
            return false;
        }

        

        
        //Função Conferir se o email está cadastrado
        private bool ConfirmarDados(String email)
        {
            String comand = "Select * from test.usuario where email='" + email +"';";
            return MyConn.SelectComand(comand);
        }

        //Função Conferir se o email e a senha estão cadastrados
        private bool ConfirmarDados(String email, String senha)
        {
            String comand = "Select * from test.usuario where email='" + email + "' and senha='" + senha + "';";
            return MyConn.SelectComand(comand);
        }

        //Criar novo usuário
        public bool CriarConta(String nome, String sobrenome, String email, String senha)
        {
            if (ConfirmarDados(email))
            {
                if (ConfirmarDados(email, senha))
                {
                    return false;
                }
                return false;
            }
            else
            {
                String comand = "INSERT INTO test.usuario (email, senha, nome, sobrenome) VALUES('" + email + "', '" + senha + "', '" + nome + "', '" + sobrenome + "');";
                MyConn.InsertComand(comand);
                SalvarDados(email, senha);
                return true;
            }
        }

        //Salva os dados de login em Application.UserAppDataPath
        public void SalvarDados(String email, String pass)
        {
            try
            {
                String Arquivo = @Application.UserAppDataPath+"\\appData.txt";
                if (!File.Exists(Arquivo))
                    using (FileStream fileStream = File.Create(Arquivo))
                    using (StreamWriter writer = new StreamWriter(fileStream))
                    {
                        writer.WriteLine(this.EncriptarValue(email));
                        writer.WriteLine(this.EncriptarValue(pass));
                    }
                if (File.Exists(Arquivo))
                {
                    try
                    {
                        FileAttributes atributos = File.GetAttributes(Arquivo);
                        File.SetAttributes(Arquivo, FileAttributes.Encrypted | FileAttributes.Hidden | FileAttributes.NotContentIndexed);
                    }
                    catch(Exception Ex)
                    {
                        Console.Write(Ex.Message);
                    }
                }
            }
            catch (IOException ex)
            {
                // Inform the user that an error occurred.
                MessageBox.Show("An error occurred while attempting to show the application." +
                                "The error is:" + ex.ToString());
            }
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
            catch (Exception)
            {
                {
                    using (FileStream fileStream = File.OpenWrite(@Application.UserAppDataPath + "\\appData.txt"))
                    using (StreamWriter writer = new StreamWriter(fileStream))
                    {
                        writer.WriteLine(this.EncriptarValue(value));
                    }
                }
            }
            return desencriptado;
        }
        
        //Encripta os dados
        private String EncriptarValue(String value)
        {
            String encriptado = "";
            chave3 = chave2.Split('!');


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
            return encriptado;
        }
        
    }
}
