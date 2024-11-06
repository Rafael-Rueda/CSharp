using editora.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace editora.Views
{
    internal class ConsoleView
    {
        int opcao = 0;
        int subopcao = 0;

        public void Menu()
        {
            while (opcao != 9)
            {
                Console.Clear();
                Console.WriteLine("=-=-=-= EDITORA =-=-=-=");
                Console.WriteLine("1 - Editoras");
                Console.WriteLine("2 - Livros");
                Console.WriteLine("3 - Autores");
                Console.WriteLine("9 - Sair");
                Console.WriteLine("Digite a opcao: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        // PUBLISHER
                        subopcao = 0;
                        while (subopcao != 9)
                        {
                            Console.Clear();
                            Console.WriteLine("=-=-=-= EDITORAS =-=-=-=");
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
                                    Editora.SalvarCSV(EditoraController.GetEditoras(), Editora.caminho, (editora) => $"{editora.id};{editora.nome};{editora.sigla};{editora.observacoes}");
                                    break;
                                case 2:
                                    EditoraController.Pesquisar();
                                    break;
                                case 3:
                                    EditoraController.Atualizar();
                                    Editora.SalvarCSV(EditoraController.GetEditoras(), Editora.caminho, (editora) => $"{editora.id};{editora.nome};{editora.sigla};{editora.observacoes}");
                                    break;
                                case 4:
                                    EditoraController.Excluir();
                                    Editora.SalvarCSV(EditoraController.GetEditoras(), Editora.caminho, (editora) => $"{editora.id};{editora.nome};{editora.sigla};{editora.observacoes}");
                                    break;
                            }
                        }

                        break;

                    case 2:
                        // BOOKS
                        subopcao = 0;
                        while (subopcao != 9)
                        {
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
                                    LivroController.Criar();
                                    Livro.SalvarCSV(LivroController.GetLivros(), Livro.caminho, (livro) => $"{livro.id};{livro.nome};{livro.anopublicacao};{livro.isbn};{livro.observacoes}");
                                    break;
                                case 2:
                                    LivroController.Pesquisar();
                                    break;
                                case 3:
                                    LivroController.Atualizar();
                                    Livro.SalvarCSV(LivroController.GetLivros(), Livro.caminho, (livro) => $"{livro.id};{livro.nome};{livro.anopublicacao};{livro.isbn};{livro.observacoes}");
                                    break;
                                case 4:
                                    LivroController.Excluir();
                                    Livro.SalvarCSV(LivroController.GetLivros(), Livro.caminho, (livro) => $"{livro.id};{livro.nome};{livro.anopublicacao};{livro.isbn};{livro.observacoes}");
                                    break;
                            }
                        }
                        break;
                    case 3:
                        // AUTHORS
                        subopcao = 0;
                        while (subopcao != 9)
                        {
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
                                    AutorController.Criar();
                                    Autor.SalvarCSV(AutorController.GetAutores(), Autor.caminho, (autor) => $"{autor.id};{autor.nome};{autor.pseudonimo};{autor.observacoes}");
                                    break;
                                case 2:
                                    AutorController.Pesquisar();
                                    break;
                                case 3:
                                    AutorController.Atualizar();
                                    Autor.SalvarCSV(AutorController.GetAutores(), Autor.caminho, (autor) => $"{autor.id};{autor.nome};{autor.pseudonimo};{autor.observacoes}");
                                    break;
                                case 4:
                                    AutorController.Excluir();
                                    Autor.SalvarCSV(AutorController.GetAutores(), Autor.caminho, (autor) => $"{autor.id};{autor.nome};{autor.pseudonimo};{autor.observacoes}");
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
        }
    }
}
