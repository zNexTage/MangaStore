using MangaStore.Util;
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
        public long FkEditora { get; set; }
        public long FkGenero { get; set; }
        public long FkIdioma { get; set; }
        public double? Preco { get; set; }
        public int? QtdPaginas { get; set; }
        public DateTime DataPublicacao { get; set; }
        private string baseImage;
        public byte[] CapaLivro { get; set; }
        public int? QuantidadeLivros { get; set; }
        public string Descricao { get; set; }
        public string BaseImage { get => baseImage; set => SetValueImage(value); }
        public long? FkUsuario { get; set; }

        /// <summary>
        /// Valida se foi recebido o base64 para assim converter em array de bytes.
        /// </summary>
        /// <param name="Value"></param>
        public void SetValueImage(string Value)
        {
            this.baseImage = Value;
            this.CapaLivro = null;

            //Verifica se há algum valor retornado
            if (!string.IsNullOrEmpty(this.baseImage))
            {
                //Converte o base64 da capa do livro em bytearray
                this.CapaLivro = Convert.FromBase64String(baseImage);
            }
            else
            {
                this.CapaLivro = new byte[0];
            }
        }
    }
}