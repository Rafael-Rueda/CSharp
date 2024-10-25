using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace editora
{
    internal class Livro : Registravel
    {
        public int id;
        public string nome;
        public int anopublicacao;
        public float isbn;
        public string observacoes;

        public Livro()
        {
            int idCriar = 0;

            while (true)
            {
                Console.WriteLine("ID único: ");
                idCriar = int.Parse(Console.ReadLine());
                if (!Gerenciador<Livro>.GetInstancias().Any(livro => livro.id == idCriar)) break;
                Console.WriteLine("ID já existente. Tente outro.");
            }


            this.id = idCriar;
            Console.WriteLine("Nome: ");
            this.nome = Console.ReadLine();
            Console.WriteLine("Ano de publicação: ");
            this.anopublicacao = int.Parse(Console.ReadLine());
            Console.WriteLine("ISBN: ");
            this.isbn = float.Parse(Console.ReadLine());
            Console.WriteLine("Observações: ");
            this.observacoes = Console.ReadLine();

            Console.WriteLine("Livro adiciona com sucesso.");

            Console.WriteLine("Pressione Enter para continuar.");
            Console.ReadLine();

            Gerenciador<Livro>.AdicionarInstancia(this);
        }

        private Livro(int id, string nome, int anopublicacao, float isbn, string observacoes)
        {
            if (Gerenciador<Livro>.GetInstancias().Any(e => e.id == id)) throw new Exception("Nao pode com o mesmo ID");

            this.id = id;
            this.nome = nome;
            this.anopublicacao = anopublicacao;
            this.isbn = isbn;
            this.observacoes = observacoes;
        }

        private static string WriteLivro(Livro livro)
        {
            return livro.id.ToString() + " - " + livro.nome.ToString() + " - " + livro.anopublicacao.ToString() + " - " + livro.isbn.ToString();
        }

        public static List<Livro> GetLivros()
        {
            return Gerenciador<Livro>.GetInstancias();
        }

        public static void Sincronizar(string caminhoCsv)
        {
            Gerenciador<Livro>.LimparInstancias();

            string[] linhas = File.ReadAllLines(caminhoCsv);

            foreach (string linha in linhas)
            {
                string[] colunas = linha.Split(';');

                Livro livro = new Livro(id: int.Parse(colunas[0]), nome: colunas[1], anopublicacao: int.Parse(colunas[2]), isbn: float.Parse(colunas[3]), observacoes: colunas[4]);

                Gerenciador<Livro>.AdicionarInstancia(livro);
            }
        }
        public static void Pesquisar()
        {
            foreach (Livro livro in Gerenciador<Livro>.GetInstancias())
            {
                Console.WriteLine(WriteLivro(livro));
            }
            Console.WriteLine("Pressione Enter para continuar.");
            Console.ReadLine();
        }

        public static void Atualizar()
        {
            Console.WriteLine("ID único: ");
            int idAtualizar = int.Parse(Console.ReadLine());

            List<Livro> livros = Gerenciador<Livro>.GetInstancias();
            Livro livro = livros.FirstOrDefault(e => e.id == idAtualizar);

            if (livro != null)
            {
                Console.WriteLine("Nome: ");
                livro.nome = Console.ReadLine();
                Console.WriteLine("Ano de publicação: ");
                livro.anopublicacao = int.Parse(Console.ReadLine());
                Console.WriteLine("ISBN: ");
                livro.isbn = float.Parse(Console.ReadLine());
                Console.WriteLine("Observações: ");
                livro.observacoes = Console.ReadLine();

                Gerenciador<Livro>.SobrescreverInstancias(livros);

                Console.WriteLine("Atualizado com sucesso.");
            }
            else
            {
                Console.WriteLine("Livro não encontrado.");
            }

            Console.WriteLine("Pressione Enter para continuar.");
            Console.ReadLine();
        }

        public static void Excluir()
        {
            Console.WriteLine("ID único: ");
            int idExcluir = int.Parse(Console.ReadLine());
            List<Livro> livros = Gerenciador<Livro>.GetInstancias();
            Livro livro = livros.FirstOrDefault(e => e.id == idExcluir);

            if (livro != null)
            {
                livros.Remove(livro);
                Console.WriteLine("Removido com sucesso.");

                Gerenciador<Livro>.SobrescreverInstancias(livros);
            }
            else
            {
                Console.WriteLine("Livro não encontrado.");
            }

            Console.WriteLine("Pressione Enter para continuar.");
            Console.ReadLine();
        }
    }
}
