using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace editora.Controllers
{
    internal class LivroController
    {
        public static void Criar()
        {
            Livro livroCriar = new Livro();
            int idCriar = 0;

            while (true)
            {
                Console.WriteLine("ID único: ");
                idCriar = int.Parse(Console.ReadLine());
                if (!Gerenciador<Livro>.GetInstancias().Any(livro => livro.id == idCriar)) break;
                Console.WriteLine("ID já existente. Tente outro.");
            }


            livroCriar.id = idCriar;
            Console.WriteLine("Nome: ");
            livroCriar.nome = Console.ReadLine();
            Console.WriteLine("Ano de publicação: ");
            livroCriar.anopublicacao = int.Parse(Console.ReadLine());
            Console.WriteLine("ISBN: ");
            livroCriar.isbn = float.Parse(Console.ReadLine());
            Console.WriteLine("Observações: ");
            livroCriar.observacoes = Console.ReadLine();

            Console.WriteLine("Livro adiciona com sucesso.");

            Console.WriteLine("Pressione Enter para continuar.");
            Console.ReadLine();

            Gerenciador<Livro>.AdicionarInstancia(livroCriar);
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

        public static void Sincronizar()
        {
            Gerenciador<Livro>.LimparInstancias();

            string[] linhas = File.ReadAllLines(Livro.caminho);

            foreach (string linha in linhas)
            {
                Livro livro = new Livro();
                string[] colunas = linha.Split(';');

                if (Gerenciador<Livro>.GetInstancias().Any(e => e.id == int.Parse(colunas[0])))
                {
                    Console.WriteLine("[!] O livro de nome: " + colunas[1] + "Não foi carregado com êxito pois contém ID duplicado.");
                    continue;
                }

                livro.id = int.Parse(colunas[0]);
                livro.nome = colunas[1];
                livro.anopublicacao = int.Parse(colunas[2]);
                livro.isbn = float.Parse(colunas[3]);
                livro.observacoes = colunas[4];

                Gerenciador<Livro>.AdicionarInstancia(livro);
            }
        }

        private static string WriteLivro(Livro livro)
        {
            return livro.id.ToString() + " - " + livro.nome.ToString() + " - " + livro.anopublicacao.ToString() + " - " + livro.isbn.ToString();
        }

        public static List<Livro> GetLivros()
        {
            return Gerenciador<Livro>.GetInstancias();
        }
    }
}
