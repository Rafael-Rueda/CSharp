using System.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace editora {
    internal class Program {
        static void Main(string[] args) {

            int opcao = 0;
            int subopcao = 0;

            // Controle de editoras, autores e livros

            string caminhoBanco = ConfigurationManager.AppSettings["caminhoBanco"];
            string nomeBancoEditoras = ConfigurationManager.AppSettings["nomeBancoEditoras"];
            string nomeBancoAutores = ConfigurationManager.AppSettings["nomeBancoAutores"];
            string nomeBancoLivros = ConfigurationManager.AppSettings["nomeBancoLivros"];

            string caminhoEditora = caminhoBanco + nomeBancoEditoras;
            string caminhoAutor = caminhoBanco + nomeBancoAutores;
            string caminhoLivro = caminhoBanco + nomeBancoLivros;

            Editora.Sincronizar(caminhoEditora);
            Livro.Sincronizar(caminhoLivro);
            Autor.Sincronizar(caminhoAutor);

            while (opcao != 9) {
                Console.Clear();
                Console.WriteLine("=-=-=-= EDITORA =-=-=-=");
                Console.WriteLine("1 - Editoras");
                Console.WriteLine("2 - Livros");
                Console.WriteLine("3 - Autores");
                Console.WriteLine("9 - Sair");
                Console.WriteLine("Digite a opcao: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao) {
                    case 1:
                        // PUBLISHER
                        subopcao = 0;
                        while (subopcao != 9) {
                            Console.Clear();
                            Console.WriteLine("=-=-=-= EDITORAS =-=-=-=");
                            Console.WriteLine("1 - Criar");
                            Console.WriteLine("2 - Pesquisar");
                            Console.WriteLine("3 - Atualizar");
                            Console.WriteLine("4 - Excluir");
                            Console.WriteLine("9 - Voltar");
                            Console.WriteLine("Digite a opcao: ");
                            subopcao = int.Parse(Console.ReadLine());

                            switch (subopcao) {
                                case 1:
                                    new Editora();
                                    Editora.SalvarCSV(Editora.GetEditoras(), caminhoEditora, (editora) => $"{editora.id};{editora.nome};{editora.sigla};{editora.observacoes}");
                                    break;
                                case 2:
                                    Editora.Pesquisar();
                                    break;
                                case 3:
                                    Editora.Atualizar();
                                    Editora.SalvarCSV(Editora.GetEditoras(), caminhoEditora, (editora) => $"{editora.id};{editora.nome};{editora.sigla};{editora.observacoes}");
                                    break;
                                case 4:
                                    Editora.Excluir();
                                    Editora.SalvarCSV(Editora.GetEditoras(), caminhoEditora, (editora) => $"{editora.id};{editora.nome};{editora.sigla};{editora.observacoes}");
                                    break;
                            }
                        }

                        break;

                    case 2:
                        // BOOKS
                        subopcao = 0;
                        while (subopcao != 9) {
                            Console.Clear();
                            Console.WriteLine("=-=-=-= LIVROS =-=-=-=");
                            Console.WriteLine("1 - Criar");
                            Console.WriteLine("2 - Pesquisar");
                            Console.WriteLine("3 - Atualizar");
                            Console.WriteLine("4 - Excluir");
                            Console.WriteLine("9 - Voltar");
                            Console.WriteLine("Digite a opcao: ");
                            subopcao = int.Parse(Console.ReadLine());

                            switch (subopcao)
                            {
                                case 1:
                                    new Livro();
                                    Livro.SalvarCSV(Livro.GetLivros(), caminhoLivro, (livro) => $"{livro.id};{livro.nome};{livro.anopublicacao};{livro.isbn};{livro.observacoes}");
                                    break;
                                case 2:
                                    Livro.Pesquisar();
                                    break;
                                case 3:
                                    Livro.Atualizar();
                                    Livro.SalvarCSV(Livro.GetLivros(), caminhoLivro, (livro) => $"{livro.id};{livro.nome};{livro.anopublicacao};{livro.isbn};{livro.observacoes}");
                                    break;
                                case 4:
                                    Livro.Excluir();
                                    Livro.SalvarCSV(Livro.GetLivros(), caminhoLivro, (livro) => $"{livro.id};{livro.nome};{livro.anopublicacao};{livro.isbn};{livro.observacoes}");
                                    break;
                            }
                        }
                        break;
                    case 3:
                        // AUTHORS
                        subopcao = 0;
                        while (subopcao != 9) {
                            Console.Clear();
                            Console.WriteLine("=-=-=-= AUTORES =-=-=-=");
                            Console.WriteLine("1 - Criar");
                            Console.WriteLine("2 - Pesquisar");
                            Console.WriteLine("3 - Atualizar");
                            Console.WriteLine("4 - Excluir");
                            Console.WriteLine("9 - Voltar");
                            Console.WriteLine("Digite a opcao: ");
                            subopcao = int.Parse(Console.ReadLine());

                            switch (subopcao)
                            {
                                case 1:
                                    new Autor();
                                    Autor.SalvarCSV(Autor.GetAutores(), caminhoAutor, (autor) => $"{autor.id};{autor.nome};{autor.pseudonimo};{autor.observacoes}");
                                    break;
                                case 2:
                                    Autor.Pesquisar();
                                    break;
                                case 3:
                                    Autor.Atualizar();
                                    Autor.SalvarCSV(Autor.GetAutores(), caminhoAutor, (autor) => $"{autor.id};{autor.nome};{autor.pseudonimo};{autor.observacoes}");
                                    break;
                                case 4:
                                    Autor.Excluir();
                                    Autor.SalvarCSV(Autor.GetAutores(), caminhoAutor, (autor) => $"{autor.id};{autor.nome};{autor.pseudonimo};{autor.observacoes}");
                                    break;
                            }
                        }
                        break;
                    case 9:
                        break;
                    default:
                        Console.WriteLine("Nenhuma opcao encontrada");
                        break;
                }
            }

            Editora.SalvarCSV(Editora.GetEditoras(), caminhoEditora, (editora) => $"{editora.id};{editora.nome};{editora.sigla};{editora.observacoes}");
            Autor.SalvarCSV(Autor.GetAutores(), caminhoAutor, (autor) => $"{autor.id};{autor.nome};{autor.pseudonimo};{autor.observacoes}");
            Livro.SalvarCSV(Livro.GetLivros(), caminhoLivro, (livro) => $"{livro.id};{livro.nome};{livro.anopublicacao};{livro.isbn};{livro.observacoes}");
        }
    }
}
