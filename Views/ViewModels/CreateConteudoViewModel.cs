using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudCrt4.Views.ViewModels
{
    public class CreateConteudoViewModel
    {
        [Required(ErrorMessage = "Informe o Menu.")]
        public string Menu { get; set; }
        [Required(ErrorMessage = "Informe o Título.")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "Informe o Artigo.")]
        public string Artigo { get; set; }
        [Required(ErrorMessage = "Informe a Imagem.")]
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
