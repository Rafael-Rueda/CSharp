using System.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using editora.Controllers;
using editora.Views;

namespace editora {
    internal class Program {
        static void Main(string[] args) {

            EditoraController.Sincronizar();
            LivroController.Sincronizar();
            AutorController.Sincronizar();

            ConsoleView consoleView = new ConsoleView();
            consoleView.Menu();

            Editora.SalvarCSV(EditoraController.GetEditoras(), Editora.caminho, (editora) => $"{editora.id};{editora.nome};{editora.sigla};{editora.observacoes}");
            Livro.SalvarCSV(LivroController.GetLivros(), Livro.caminho, (livro) => $"{livro.id};{livro.nome};{livro.anopublicacao};{livro.isbn};{livro.observacoes}");
            Autor.SalvarCSV(AutorController.GetAutores(), Autor.caminho, (autor) => $"{autor.id};{autor.nome};{autor.pseudonimo};{autor.observacoes}");
        }
    }
}
