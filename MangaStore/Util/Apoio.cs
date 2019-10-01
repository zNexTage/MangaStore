using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
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
    }
}