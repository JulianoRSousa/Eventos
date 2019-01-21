using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos
{
    class Gerenciador
    {
        string databaseLogin = "usuario";
        string databaseEventos = "evento";
        string tableUsuariosLogin = "usuario";
        string tableEventosEventos = "evento";
        string dbAdminUserLogin = "julianorodsousa";
        string dbAdminPassLogin = "julianorodsousa";
        string dbEndereço = "127.0.0.1";
        string dbPorta = "3306";

        public string DatabaseLogin { get => databaseLogin;}
        public string DatabaseEventos { get => databaseEventos;}
        public string TableUsuariosLogin { get => tableUsuariosLogin;}
        public string TableEventosEventos { get => tableEventosEventos;}
        public string DbAdminUserLogin { get => dbAdminUserLogin;}
        public string DbAdminPassLogin { get => dbAdminPassLogin;}
        public string DbEndereço { get => dbEndereço;}
        public string DbPorta { get => dbPorta;}

        public Gerenciador(string databaseLogin, string databaseEventos, string tableUsuariosLogin, string tableEventosEventos, string dbAdminUserLogin, string dbAdminPassLogin)
        {
            this.databaseLogin = databaseLogin;
            this.databaseEventos = databaseEventos;
            this.tableUsuariosLogin = tableUsuariosLogin;
            this.tableEventosEventos = tableEventosEventos;
            this.dbAdminUserLogin = dbAdminUserLogin;
            this.dbAdminPassLogin = dbAdminPassLogin;
        }

        public Gerenciador() { }


    }
}
