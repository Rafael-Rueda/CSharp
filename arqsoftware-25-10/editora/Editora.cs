using System;
using System.Collections.Generic;
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

        public Editora()
        {
            int idCriar = 0;

            while (true)
            {
                Console.WriteLine("ID único: ");
                idCriar = int.Parse(Console.ReadLine());
                if (!Gerenciador<Editora>.GetInstancias().Any(editora => editora.id == idCriar)) break;
                Console.WriteLine("ID já existente. Tente outro.");
            }


            this.id = idCriar;
            Console.WriteLine("Nome: ");
            this.nome = Console.ReadLine();
            Console.WriteLine("Sigla: ");
            this.sigla = Console.ReadLine();
            Console.WriteLine("Observações: ");
            this.observacoes = Console.ReadLine();

            Console.WriteLine("Editora adiciona com sucesso.");

            Console.WriteLine("Pressione Enter para continuar.");
            Console.ReadLine();

            Gerenciador<Editora>.AdicionarInstancia(this);
        }

        private Editora(int id, string nome, string sigla, string observacoes)
        {
            if (Gerenciador<Editora>.GetInstancias().Any(e => e.id == id)) throw new Exception("Nao pode com o mesmo ID");

            this.id = id;
            this.nome = nome;
            this.sigla = sigla;
            this.observacoes = observacoes;
        }

        private static string WriteEditora(Editora editora)
        {
            return editora.id.ToString() + " - " + editora.sigla.ToString() + " - " + editora.nome.ToString();
        }

        public static List<Editora> GetEditoras()
        {
            return Gerenciador<Editora>.GetInstancias();
        }

        public static void Sincronizar(string caminhoCsv)
        {
            Gerenciador<Editora>.LimparInstancias();

            string[] linhas = File.ReadAllLines(caminhoCsv);

            foreach (string linha in linhas)
            {
                string[] colunas = linha.Split(';');

                Editora editora = new Editora(id: int.Parse(colunas[0]), nome: colunas[1], sigla: colunas[2], observacoes: colunas[3]);

                Gerenciador<Editora>.AdicionarInstancia(editora);
            }
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
            } else
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
    }
}
