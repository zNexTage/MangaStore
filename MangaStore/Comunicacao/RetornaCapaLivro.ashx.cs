using MangaStore.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MangaStore.Comunicacao
{
    /// <summary>
    /// Descrição resumida de RetornaCapaLivro
    /// </summary>
    public class RetornaCapaLivro : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            LivroBLL livroBll = null;
            long lCdLivro = 0;
            byte[] bCapaLivro = null;

            //Recebe o codigo (id) do livro
            lCdLivro = Convert.ToInt64(context.Request.QueryString["CD_LIVRO"]);

            livroBll = new LivroBLL();

            //Chama o metodo para retornar a capa do livro
            bCapaLivro = livroBll.RetornaCapaLivro(lCdLivro);

            //Devolve como respota a capa do livro
            context.Response.BinaryWrite(bCapaLivro);

            //Define o MIME do HTTP como imagem
            context.Response.ContentType = "image/jpg";

            context.Response.Flush();            
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}