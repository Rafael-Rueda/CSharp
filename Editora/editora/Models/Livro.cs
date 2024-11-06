using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;

namespace editora
{
    internal class Livro : Registravel
    {
        public int id;
        public string nome;
        public int anopublicacao;
        public float isbn;
        public string observacoes;
        public static string caminho = ConfigurationManager.AppSettings["caminhoBanco"] + ConfigurationManager.AppSettings["nomeBancoLivros"];

        public Livro()
        {
            
        }
    }
}
