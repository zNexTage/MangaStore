using MangaStore.BLL;
using MangaStore.Model;
using MangaStore.Util;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Web;

namespace MangaStore.Comunicacao
{
    /// <summary>
    /// Descrição resumida de cadastranovolivro
    /// </summary>
    public class cadastranovolivro : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            //TODO:  Inserir o id do usuario
            LivroBLL livroBll = null;
            Livro livro = null;
            string format = "dd/MM/yyyy HH:mm:ss"; // define o formato do datetime  
            string sMensagem = "";

            try
            {            
                //Define o datetimeconverter, pois como é passados data como parametros é necessário converter
                IsoDateTimeConverter dateTimeConverter = new IsoDateTimeConverter { DateTimeFormat = format };                

                //Recebe os dados e desserializa eles no objeto Livro
                livro = JsonConvert.DeserializeObject<Livro>(Apoio.StringFromStreamReader(context.Request.InputStream), dateTimeConverter);

                //Instancia um novo objeto LivroBLL
                livroBll = new LivroBLL();

                //Realiza a validação se as propriedades foram preenchidas corretamente (campos de texto, combobox e etc...)
                sMensagem = livroBll.ValidateFields(livro);

                //Verifica se foi retornado alguma mensagem
                if (!string.IsNullOrEmpty(sMensagem))
                {
                    //Se houver retornado um mensagem significa que há algum campo que foi não foi preenchido.
                    //Demonstra um mensagem alertando o usuário o campo não foi preenchido
                    context.Response.Write(Apoio.ConvertStringToJson(sMensagem, Messages.Erro));
                }
                else
                {
                    //Se todos os campos foram preenchidos de forma corrreta.
                    //Realiza a inserção dos dados
                    livroBll.MakeInsert(livro);

                    //Demonstra um mensagem alertando que houve exito no cadastro dos livros
                    context.Response.Write(Apoio.ConvertStringToJson("Livro cadastrado com sucesso", Messages.Ok));
                }
            }
            catch (Exception err)
            {
                //Demonstra uma mensagem de erro.
                context.Response.Write(Apoio.ConvertStringToJson(err.Message, Messages.Erro));
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