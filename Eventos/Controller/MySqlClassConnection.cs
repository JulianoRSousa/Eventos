using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Eventos
{
    public class MySqlClassConnection
    {
        String MyConnection = "datasource = localhost; port = 3306; username = root; password = root";

      /*  public ModelUsuario ObterDados(string email, string senha)
        {
            ModelUsuario dados = new ModelUsuario();
            
            try
            {
                MyConnection = "datasource = localhost; port = 3306; username = root; password = root";
                MySqlConnection MyConn = new MySqlConnection(MyConnection);
                MyConn.Open();
                MySqlCommand SelectCommand = new MySqlCommand("SELECT * FROM teste.usuario WHERE email='" + email + "' AND senha='" + senha + "';", MyConn);
                MySqlDataReader MyReader = SelectCommand.ExecuteReader();
                if (MyReader.HasRows)
                {
                    while (MyReader.Read())
                    {
                    }
                }
                MyConn.Close();
                return dados;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return dados;
            }
        }
        */

        //Retorna Valor do campo especificado utilizando 2 parametros
        public String SelectGetString(String Campo, String Database, String Tabela, String Parametro1, String Valor1, String Parametro2, String Valor2)
        {
            String resultado = "nullString";

            try
            {
                MyConnection = "datasource = localhost; port = 3306; username = root; password = root";
                MySqlConnection MyConn = new MySqlConnection(MyConnection);
                MyConn.Open();
                MySqlCommand SelectCommand = new MySqlCommand("SELECT " + Campo + " FROM " + Database + "." + Tabela + " WHERE " + Parametro1 + "='" + Valor1 + "' AND " + Parametro2 + "='" + Valor2 + "';", MyConn);
                MySqlDataReader MyReader = SelectCommand.ExecuteReader();
                if (MyReader.HasRows)
                {
                    while (MyReader.Read())
                    {
                        resultado = MyReader.GetString(Campo);
                    }
                }
                MyConn.Close();
                return resultado;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return resultado;
            }
        }

        //Retorna Valor do campo especificado utilizando 1 parametro
        public String SelectGetString(String Campo, String Database, String Tabela, String Parametro, String Valor)
        {
            String resultado = "nullString";

            try
            {
                MySqlConnection MyConn = new MySqlConnection(MyConnection);
                MyConn.Open();
                MySqlCommand SelectCommand = new MySqlCommand("SELECT " + Campo + " FROM " + Database + "." + Tabela + " WHERE " + Parametro + "='" + Valor + "';", MyConn);
                MySqlDataReader MyReader = SelectCommand.ExecuteReader();
                if (MyReader.HasRows)
                {
                    while (MyReader.Read())
                    {
                        resultado = MyReader.GetString(Campo);
                    }
                }
                MyConn.Close();
                return resultado;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return resultado;
            }
        }

        public bool SelectComand(String comand)
        {
            try
            {
                int count = 0;
                MySqlConnection MyConn = new MySqlConnection(MyConnection);
                MyConn.Open();
                MySqlDataReader MyReader;
                MySqlCommand SelectCommand = new MySqlCommand(comand, MyConn);
                MyReader = SelectCommand.ExecuteReader();
                while (MyReader.Read())
                {
                    count = count + 1;
                }
                if (count == 1)
                {
                    MyConn.Close();
                    return true;
                }
                else
                {
                    MyConn.Close();
                    return false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        
        public bool InsertComand(String comand)
        {
            try
            {
                String MyConnection = "datasource=localhost;port=3306;username=root;password=root";
                MySqlConnection MyConn = new MySqlConnection(MyConnection);
                MyConn.Open();
                MySqlDataReader MyReader;
                MySqlCommand InsertCommand = new MySqlCommand(comand, MyConn);
                MyReader = InsertCommand.ExecuteReader();
                    MyConn.Close();
                    return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não deu "+ex.Message);
                return false;
            }
        }
    }    
}
