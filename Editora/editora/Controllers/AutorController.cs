using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace editora.Controllers
{
    internal class AutorController
    {
        public static void Criar()
        {
            int idCriar = 0;
            Autor autorCriar = new Autor();

            while (true)
            {
                Console.WriteLine("ID único: ");
                idCriar = int.Parse(Console.ReadLine());
                if (!Gerenciador<Autor>.GetInstancias().Any(autor => autor.id == idCriar)) break;
                Console.WriteLine("ID já existente. Tente outro.");
            }


            autorCriar.id = idCriar;
            Console.WriteLine("Nome: ");
            autorCriar.nome = Console.ReadLine();
            Console.WriteLine("Sigla: ");
            autorCriar.pseudonimo = Console.ReadLine();
            Console.WriteLine("Observações: ");
            autorCriar.observacoes = Console.ReadLine();

            Console.WriteLine("Autor adiciona com sucesso.");

            Console.WriteLine("Pressione Enter para continuar.");
            Console.ReadLine();

            Gerenciador<Autor>.AdicionarInstancia(autorCriar);
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

        public static void Sincronizar()
        {
            Gerenciador<Autor>.LimparInstancias();

            string[] linhas = File.ReadAllLines(Autor.caminho);

            foreach (string linha in linhas)
            {
                string[] colunas = linha.Split(';');

                Autor autor = new Autor();

                if (Gerenciador<Autor>.GetInstancias().Any(e => e.id == int.Parse(colunas[0])))
                {
                    Console.WriteLine("[!] O autor de nome: " + colunas[1] + "Não foi carregado com êxito pois contém ID duplicado.");
                    continue;
                }
                autor.id = int.Parse(colunas[0]);
                autor.nome = colunas[1];
                autor.pseudonimo = colunas[2];
                autor.observacoes = colunas[3];

                Gerenciador<Autor>.AdicionarInstancia(autor);
            }
        }

        private static string WriteAutor(Autor autor)
        {
            return autor.id.ToString() + " - " + autor.nome.ToString() + " - " + autor.pseudonimo.ToString();
        }

        public static List<Autor> GetAutores()
        {
            return Gerenciador<Autor>.GetInstancias();
        }
    }
}
