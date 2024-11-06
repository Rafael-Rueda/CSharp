using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace editora.Controllers
{
    internal class EditoraController
    {
        public static void Criar()
        {
            int idCriar = 0;
            Editora editoraCriar = new Editora();

            while (true)
            {
                Console.WriteLine("ID único: ");
                idCriar = int.Parse(Console.ReadLine());
                if (!Gerenciador<Editora>.GetInstancias().Any(editora => editora.id == idCriar)) break;
                Console.WriteLine("ID já existente. Tente outro.");
            }


            editoraCriar.id = idCriar;
            Console.WriteLine("Nome: ");
            editoraCriar.nome = Console.ReadLine();
            Console.WriteLine("Sigla: ");
            editoraCriar.sigla = Console.ReadLine();
            Console.WriteLine("Observações: ");
            editoraCriar.observacoes = Console.ReadLine();

            Console.WriteLine("Editora adiciona com sucesso.");

            Console.WriteLine("Pressione Enter para continuar.");
            Console.ReadLine();

            Gerenciador<Editora>.AdicionarInstancia(editoraCriar);


            Console.WriteLine("Editora adicionada com sucesso!");
        }

        public static void Pesquisar()
        {
            foreach (Editora editora in Gerenciador<Editora>.GetInstancias())
            {
                Console.WriteLine(WriteEditora(editora));
            }
            Console.WriteLine("Pressione Enter para continuar.");
            Console.ReadLine();
        }

        public static void Atualizar()
        {
            Console.WriteLine("ID único: ");
            int idAtualizar = int.Parse(Console.ReadLine());

            List<Editora> editoras = Gerenciador<Editora>.GetInstancias();
            Editora editora = editoras.FirstOrDefault(e => e.id == idAtualizar);

            if (editora != null)
            {
                Console.WriteLine("Nome: ");
                editora.nome = Console.ReadLine();
                Console.WriteLine("Sigla: ");
                editora.sigla = Console.ReadLine();
                Console.WriteLine("Observações: ");
                editora.observacoes = Console.ReadLine();

                Gerenciador<Editora>.SobrescreverInstancias(editoras);

                Console.WriteLine("Atualizado com sucesso.");
            }
            else
            {
                Console.WriteLine("Editora não encontrada.");
            }

            Console.WriteLine("Pressione Enter para continuar.");
            Console.ReadLine();
        }

        public static void Excluir()
        {
            Console.WriteLine("ID único: ");
            int idExcluir = int.Parse(Console.ReadLine());
            List<Editora> editoras = Gerenciador<Editora>.GetInstancias();
            Editora editora = editoras.FirstOrDefault(e => e.id == idExcluir);

            if (editora != null)
            {
                editoras.Remove(editora);
                Console.WriteLine("Removido com sucesso.");

                Gerenciador<Editora>.SobrescreverInstancias(editoras);
            }
            else
            {
                Console.WriteLine("Editora não encontrada.");
            }

            Console.WriteLine("Pressione Enter para continuar.");
            Console.ReadLine();
        }

        public static void Sincronizar()
        {
            Gerenciador<Editora>.LimparInstancias();

            string[] linhas = File.ReadAllLines(Editora.caminho);

            foreach (string linha in linhas)
            {
                string[] colunas = linha.Split(';');

                Editora editora = new Editora();

                if (Gerenciador<Editora>.GetInstancias().Any(e => e.id == int.Parse(colunas[0]))) 
                { 
                    Console.WriteLine("[!] A editora de nome: " + colunas[1] + "Não foi carregada com êxito pois contém ID duplicado."); 
                    continue; 
                }
                editora.id = int.Parse(colunas[0]);
                editora.nome = colunas[1];
                editora.sigla = colunas[2];
                editora.observacoes = colunas[3];

                Gerenciador<Editora>.AdicionarInstancia(editora);
            }
        }

        public static List<Editora> GetEditoras()
        {
            return Gerenciador<Editora>.GetInstancias();
        }

        private static string WriteEditora(Editora editora)
        {
            return editora.id.ToString() + " - " + editora.sigla.ToString() + " - " + editora.nome.ToString();
        }
    }
}
