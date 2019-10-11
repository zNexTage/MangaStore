using MangaStore.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using MangaStore.Util;
using MangaStore.BLL;

namespace MangaStore.Comunicacao
{
    /// <summary>
    /// Descrição resumida de verificarporisbn
    /// </summary>
    public class verificarporisbn : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string ISBN = "";
            Livro livro = null;
            LivroBLL livroBll = null; ;

            //Recebe o ISBN do livro
            livro = JsonConvert.DeserializeObject<Livro>(Apoio.StringFromStreamReader(context.Request.InputStream));

            livroBll = new LivroBLL();
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