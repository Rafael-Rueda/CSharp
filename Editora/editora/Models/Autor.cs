using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;

namespace editora
{
    internal class Autor : Registravel
    {
        public int id;
        public string nome;
        public string pseudonimo;
        public string observacoes;
        public static string caminho = ConfigurationManager.AppSettings["caminhoBanco"] + ConfigurationManager.AppSettings["nomeBancoAutores"];

        public Autor()
        {
            
        }
    }
}
