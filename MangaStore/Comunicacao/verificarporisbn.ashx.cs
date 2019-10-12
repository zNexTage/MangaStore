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
            Livro livro = null;
            LivroBLL livroBll = null;

            try 
            {
                //Recebe o ISBN do livro
                livro = JsonConvert.DeserializeObject<Livro>(Apoio.StringFromStreamReader(context.Request.InputStream));

                //Inicializa a BLL 
                livroBll = new LivroBLL();

                //Realiza um select pelo isbn do livro
                livro = (Livro)livroBll.MakeSelect(livro.Isbn, DAO.DataBaseHelper.OrderBy.None);

                //Verifica se foi retornado algum dado
                if (livro != null)
                {
                    //Devolve o livro em JSON
                    context.Response.Write(Apoio.ObjectToJson(livro));
                }
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
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