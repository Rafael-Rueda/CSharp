using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace editora
{
    internal class Registravel {
        public Registravel() { }

        public static void SalvarCSV<T> (List<T> dados, string caminho, Func<T, string> salvar) {
            try {
                using (StreamWriter writer = new StreamWriter(caminho)) {
                    foreach (T dado in dados) {
                        writer.WriteLine(salvar(dado));
                    }
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
