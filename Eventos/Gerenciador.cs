using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos
{
    class Gerenciador
    {
        string databaseLogin;
        string databaseEventos;
        string tableUsuariosLogin;
        string tableEventosEventos;
        string dbAdminUserLogin;
        string dbAdminPassLogin;

        public string DatabaseLogin { get => databaseLogin; set => databaseLogin = value; }
        public string DatabaseEventos { get => databaseEventos; set => databaseEventos = value; }
        public string TableUsuariosLogin { get => tableUsuariosLogin; set => tableUsuariosLogin = value; }
        public string TableEventosEventos { get => tableEventosEventos; set => tableEventosEventos = value; }
        public string DbAdminUserLogin { get => dbAdminUserLogin; set => dbAdminUserLogin = value; }
        public string DbAdminPassLogin { get => dbAdminPassLogin; set => dbAdminPassLogin = value; }

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
