using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using MangaStore.Model;
using MangaStore.Util;
using Newtonsoft.Json;


namespace MangaStore.Comunicacao
{
    /// <summary>
    /// Descrição resumida de cadastranovolivro
    /// </summary>
    public class cadastranovolivro : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            Livro livro = null;

            livro = JsonConvert.DeserializeObject<Livro>(Apoio.StringFromStreamReader(context.Request.InputStream));
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