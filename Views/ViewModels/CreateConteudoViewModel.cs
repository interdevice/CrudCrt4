using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudCrt4.Views.ViewModels
{
    public class CreateConteudoViewModel
    {
        public string Menu { get; set; }
        public string Titulo { get; set; }
        public string Artigo { get; set; }
        public string Imagem { get; set; }
        [NotMapped]
        public string Upload { get; set; }

        public CreateConteudoViewModel()
        {

        }

        public CreateConteudoViewModel(string menu, string titulo, string artigo, string imagem, string upload)
        {
            Menu = menu;
            Titulo = titulo;
            Artigo = artigo;
            Imagem = imagem;
            Upload = upload;
        }
    }
}
