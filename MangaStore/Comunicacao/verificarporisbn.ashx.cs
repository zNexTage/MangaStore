using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MangaStore.Comunicacao
{
    /// <summary>
    /// Descrição resumida de verificarporisbn
    /// </summary>
    public class verificarporisbn : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Olá, Mundo");
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