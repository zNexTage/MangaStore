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
        public string Editora { get; set; }        
        public string Genero { get; set; }
        public string Idioma { get; set; }
        public decimal? Preco { get; set; }
        public string PrecoConvertido { get; set; }
        public int? QtdPaginas { get; set; }
        public DateTime DataPublicacao { get; set; }
        private string baseImage;
        public byte[] CapaLivro { get; set; }
        public int? Quantidade { get; set; }
        public string Descricao { get; set; }
        public string BaseImage { get => baseImage; set => SetValueImage(value); }
        public long? FkUsuario { get; set; }
        public short Status { get; set; }
        public int iPaginacaoLivro { get; set; }

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

    /// <summary>
    /// Simboliza os status do livro
    /// </summary>
    public enum StatusLivro 
    {
        Disponivel = 0,
    }
}