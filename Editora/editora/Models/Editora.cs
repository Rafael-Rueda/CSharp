using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace editora {
    internal class Editora : Registravel
    {
        public int id;
        public string nome;
        public string sigla;
        public string observacoes;
        public static string caminho = ConfigurationManager.AppSettings["caminhoBanco"] + ConfigurationManager.AppSettings["nomeBancoEditoras"];

        public Editora()
        {
            
        }
    }
}
