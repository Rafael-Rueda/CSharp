using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace editora
{
    internal static class Gerenciador<T> where T : class
    {
        private static readonly List<T> instancias = new List<T>();

        public static List<T> GetInstancias()
        {
            return new List<T>(instancias);
        }

        public static void AdicionarInstancia(T obj)
        {
            instancias.Add(obj);
        }

        public static void LimparInstancias()
        {
            instancias.Clear();
        }

        public static void SobrescreverInstancias(List<T> lista)
        {
            instancias.Clear();
            instancias.AddRange(lista);
        }
        
    }
}
