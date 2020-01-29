using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudCrt4.Models
{
    public class Conteudo
    {
        public int Id { get; set; }
        public string Menu { get; set; }
        public string Titulo { get; set; }
        public string Artigo { get; set; }
        public string Imagem { get; set; }
        public string Upload { get; set; }

        public Conteudo()
        {

        }
        
        public Conteudo(string menu, string titulo, string artigo, string imagem, string upload)
        {
            Menu = menu;
            Titulo = titulo;
            Artigo = artigo;
            Imagem = imagem;
            Upload = upload;
        }
    }
}
