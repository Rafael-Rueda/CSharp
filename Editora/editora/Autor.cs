using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace editora
{
    internal class Autor : Registravel
    {
        public int id;
        public string nome;
        public string pseudonimo;
        public string observacoes;

        public Autor()
        {
            int idCriar = 0;

            while (true)
            {
                Console.WriteLine("ID único: ");
                idCriar = int.Parse(Console.ReadLine());
                if (!Gerenciador<Autor>.GetInstancias().Any(autor => autor.id == idCriar)) break;
                Console.WriteLine("ID já existente. Tente outro.");
            }


            this.id = idCriar;
            Console.WriteLine("Nome: ");
            this.nome = Console.ReadLine();
            Console.WriteLine("Sigla: ");
            this.pseudonimo = Console.ReadLine();
            Console.WriteLine("Observações: ");
            this.observacoes = Console.ReadLine();

            Console.WriteLine("Autor adiciona com sucesso.");

            Console.WriteLine("Pressione Enter para continuar.");
            Console.ReadLine();

            Gerenciador<Autor>.AdicionarInstancia(this);
        }

        private Autor(int id, string nome, string pseudonimo, string observacoes)
        {
            if (Gerenciador<Autor>.GetInstancias().Any(e => e.id == id)) throw new Exception("Nao pode com o mesmo ID");

            this.id = id;
            this.nome = nome;
            this.pseudonimo = pseudonimo;
            this.observacoes = observacoes;
        }

        private static string WriteAutor(Autor autor)
        {
            return autor.id.ToString() + " - " + autor.nome.ToString() + " - " + autor.pseudonimo.ToString();
        }

        public static List<Autor> GetAutores()
        {
            return Gerenciador<Autor>.GetInstancias();
        }

        public static void Sincronizar(string caminhoCsv)
        {
            Gerenciador<Autor>.LimparInstancias();

            string[] linhas = File.ReadAllLines(caminhoCsv);

            foreach (string linha in linhas)
            {
                string[] colunas = linha.Split(';');

                Autor autor = new Autor(id: int.Parse(colunas[0]), nome: colunas[1], pseudonimo: colunas[2], observacoes: colunas[3]);

                Gerenciador<Autor>.AdicionarInstancia(autor);
            }
        }
        public static void Pesquisar()
        {
            foreach (Autor autor in Gerenciador<Autor>.GetInstancias())
            {
                Console.WriteLine(WriteAutor(autor));
            }
            Console.WriteLine("Pressione Enter para continuar.");
            Console.ReadLine();
        }

        public static void Atualizar()
        {
            Console.WriteLine("ID único: ");
            int idAtualizar = int.Parse(Console.ReadLine());

            List<Autor> Autores = Gerenciador<Autor>.GetInstancias();
            Autor autor = Autores.FirstOrDefault(e => e.id == idAtualizar);

            if (autor != null)
            {
                Console.WriteLine("Nome: ");
                autor.nome = Console.ReadLine();
                Console.WriteLine("Sigla: ");
                autor.pseudonimo = Console.ReadLine();
                Console.WriteLine("Observações: ");
                autor.observacoes = Console.ReadLine();

                Gerenciador<Autor>.SobrescreverInstancias(Autores);

                Console.WriteLine("Atualizado com sucesso.");
            }
            else
            {
                Console.WriteLine("Autor não encontrado.");
            }

            Console.WriteLine("Pressione Enter para continuar.");
            Console.ReadLine();
        }

        public static void Excluir()
        {
            Console.WriteLine("ID único: ");
            int idExcluir = int.Parse(Console.ReadLine());
            List<Autor> Autores = Gerenciador<Autor>.GetInstancias();
            Autor autor = Autores.FirstOrDefault(e => e.id == idExcluir);

            if (autor != null)
            {
                Autores.Remove(autor);
                Console.WriteLine("Removido com sucesso.");

                Gerenciador<Autor>.SobrescreverInstancias(Autores);
            }
            else
            {
                Console.WriteLine("Autor não encontrado.");
            }

            Console.WriteLine("Pressione Enter para continuar.");
            Console.ReadLine();
        }
    }
}
