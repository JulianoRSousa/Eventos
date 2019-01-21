using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos
{
    class ModelUsuario
    {
        readonly int idusuario;
        string email;
        string nome;
        string sobrenome;
        int qtavaliacao;
        int avaliacao;

        public int Idusuario { get => idusuario; }
        public string Email { get => email; set => email = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Sobrenome { get => sobrenome; set => sobrenome = value; }
        public int Qtavaliacao { get => qtavaliacao; set => qtavaliacao = value; }
        public int Avaliacao { get => avaliacao; set => avaliacao = value; }

        public ModelUsuario(int idusuario, string email, string nome, string sobrenome, int qtavaliacao, int avaliacao)
        {
            this.email = email;
            this.nome = nome;
            this.sobrenome = sobrenome;
            this.qtavaliacao = qtavaliacao;
            this.avaliacao = avaliacao;
        }
        public ModelUsuario()
        {
        }

    }
}
