using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eventos.Controller
{
    class EventosController
    {
        private LoginController LoginController = new LoginController();
        private MySqlClassConnection MyConn = new MySqlClassConnection();

        public bool Iniciar(string user, string pass)
        {
            ModelUsuario dadosUsuario = MyConn.ObterDados(user, pass);
            return false;
        }

        public ModelUsuario ObterDados(string email, string senha)
        {

            /*
            String Dados = "Ainda não tem valor";
            MessageBox.Show(email);
            Dados = MyConn.SelectGetString("nome", "test", "usuario", "email", email);
            return Dados;
            */
            return MyConn.ObterDados(email, senha);
        }
        
    }
}
