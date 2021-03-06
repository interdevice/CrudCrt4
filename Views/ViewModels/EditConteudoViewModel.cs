﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudCrt4.Views.ViewModels
{
    public class EditConteudoViewModel
    {
        public int Id { get; set; }
        
        public string Menu { get; set; }
        
        public string Titulo { get; set; }

        public string Artigo { get; set; }
        
        public string Imagem { get; set; }
        
        public string Upload { get; set; }

        [NotMapped]
        public string FullUploadPath { get; set; }
        public EditConteudoViewModel()
        {

        }

        public EditConteudoViewModel(int id, string menu, string titulo, string artigo, string imagem, string upload)
        {
            Id = id;
            Menu = menu;
            Titulo = titulo;
            Artigo = artigo;
            Imagem = imagem;
            Upload = upload;
        }

    }
}
