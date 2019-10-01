using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MangaStore.Model
{
    public class Livro
    {
        public long CdLivro { get; set; }
        public string Isbn { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public long CdEditora { get; set; }
        public long CdGenero { get; set; }
        public long CdIdioma { get; set; }
        public decimal Preco { get; set; }
        public int QtdPaginas { get; set; }
        public DateTime DataPublicacao { get; set; }
        public string GetData { get; set; }
        public string BaseImage { get; set; }
        public byte[] ByteImage { get; set; }
        public int QuantidadeLivros { get; set; }

        public string Descricao { get; set; }
    }
}