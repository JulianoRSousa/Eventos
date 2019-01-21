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
        private Gerenciador Gerenciador = new Gerenciador();
       
        //Retorna Valor do campo especificado utilizando 2 parametros(comunmente usuario e senha)*(podendo ser outro)
        public String SelectGetString(String Campo, String Database, String Tabela, String Parametro1, String Valor1, String Parametro2, String Valor2)
        {
            String resultado = "nullString";

            try
            {
                String MyConnection = "datasource=" + Gerenciador.DbEndereço + ";port=" + Gerenciador.DbPorta + ";username=" + Gerenciador.DbAdminUserLogin + ";password=" + Gerenciador.DbAdminPassLogin + ";";
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

        //Retorna Valor do campo especificado utilizando 1 parametro(comunmente usuario)*(podendo ser outro)
        public String SelectGetString(String Campo, String Database, String Tabela, String Parametro, String Valor)
        {
            String resultado = "nullString";

            try
            {
                String MyConnection = "datasource=" + Gerenciador.DbEndereço + ";port=" + Gerenciador.DbPorta + ";username=" + Gerenciador.DbAdminUserLogin + ";password=" + Gerenciador.DbAdminPassLogin + ";";
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

        //Retorna a existencia ou não da busca no banco de dados
        public bool SelectComand(String comand)
        {
            MySqlConnection MyConn = new MySqlConnection("datasource=" + Gerenciador.DbEndereço + ";port=" + Gerenciador.DbPorta + ";username=" + Gerenciador.DbAdminUserLogin + ";password=" + Gerenciador.DbAdminPassLogin + ";");
            MySqlDataReader MyReader;
            MySqlCommand SelectCommand = new MySqlCommand(comand, MyConn);
            try
            {
                int count = 0;
                MyConn.Open();
                MyReader = SelectCommand.ExecuteReader();
                while (MyReader.Read())
                {
                    count = count + 1;
                }
                if (count != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                MyConn.Close();
            }
        }
        
        //Inserir no Banco de dados
        public bool InsertComand(String comand)
        {
            string MyConnection = "datasource=" + Gerenciador.DbEndereço + ";port=" + Gerenciador.DbPorta + ";username=" + Gerenciador.DbAdminUserLogin + ";password=" + Gerenciador.DbAdminPassLogin + ";";
            MySqlConnection MyConn = new MySqlConnection(MyConnection);

            try
            {
                MyConn.Open();
                MySqlCommand SelectCommand = new MySqlCommand(comand, MyConn);
                MySqlDataReader MyReader = SelectCommand.ExecuteReader();
                if (MyReader.HasRows)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return false ;
            }
            finally
            {
                MyConn.Close();
            }
        }
    }    
}
