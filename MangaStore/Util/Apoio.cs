using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using Newtonsoft.Json;

namespace MangaStore.Util
{
    public class Apoio
    {
        /// <summary>
        /// Realiza a leitura de um stream e retorna o seu valor em uma string
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static string StringFromStreamReader(Stream stream)
        {
            //Realiza a leitura
            string Value = new StreamReader(stream).ReadToEnd();

            //Retorna o valor
            return Value;
        }

        /// <summary>
        /// Converte uma string em JSON
        /// </summary>
        /// <param name="Value"></param>
        /// <returns></returns>
        public static string ConvertStringToJson(string Value, Messages messages)
        {
            string sJson = "";

            sJson = string.Format("{0}:{1}", Value, messages);

            //Retorna o valor convertido
            return JsonConvert.SerializeObject(sJson);
        }

        /// <summary>
        /// Retorna uma mensagem alertando o campo que não foi preenchido corretamente
        /// </summary>
        /// <param name="NomeCampo"></param>
        /// <returns></returns>
        public static string RetornaMensagemCampoObrigatorio(string NomeCampo)
        {
            //Retorna a mensagem
            return string.Format("O campo {0} é obrigatório, por favor preencha corretamente.", NomeCampo);
        }

        /// <summary>
        /// Retorna uma mensagem alertando ao usuario o combo que ele não escolheu uma opção
        /// </summary>
        /// <param name="NomeCombo">Nome do combo</param>
        /// <returns></returns>
        public static string ComboBoxInvalido(string NomeCombo)
        {
            //Retorna a mensagem
            return string.Format("Por favor! Selecione um/uma {0} corretamente!", NomeCombo);
        }

        /// <summary>
        /// Converte um objeto para JSON
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ObjectToJson(object obj) 
        {            
            string Json;

            //Serializa o objeto em JSON
            Json = JsonConvert.SerializeObject(obj);

            //Retorna o JSON
            return Json;
        }

        /// <summary>
        /// Demonstra um modal com uma mensagem definida pelo parametro sMensagem
        /// </summary>
        /// <param name="control"></param>
        /// <param name="type"></param>
        public static void DialogMessage(Control control, Type type, string sCabecalho,string sMensagem) 
        {
            ScriptManager.RegisterStartupScript(control, type, "", string.Format("modalMessage(`{0}`, `{1}`)", sCabecalho, sMensagem), true);
        }
    }
}