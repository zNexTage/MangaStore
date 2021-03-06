﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using MangaStore.BLL;
using MangaStore.Model;

namespace MangaStore
{
    public partial class CadastrarManga : System.Web.UI.Page
    {        
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //Preenche o combo com os meses
                PreencheComboMes();

                //Preenche o combo com os anos
                PreencheComboAno();
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }

        /// <summary>
        /// Preenche o combo com os meses do ano
        /// </summary>
        private void PreencheComboMes() 
        {
            string sKey;
            string sValue;
            string[] sGetMes;

            //Atribui ao array os meses, junto com sua representação numérica
            string[] sMeses = new string[]
            {
                "01:Janeiro",
                "02:Fevereiro",
                "03:Março",
                "04:Abril",
                "05:Maio",
                "06:Junho",
                "07:Julho",
                "08:Agosto",
                "09:Setembro",
                "10:Outubro",
                "11:Novembro",
                "12:Dezembro"
            };

            //Limpa o combo para evitar duplicação
            cboMes.Items.Clear();

            //Define um primeiro valor do combo
            cboMes.Items.Add(new ListItem("Mês", "-1"));

            //Realiza um laço pelo array de meses e adiciona ao combox Mes
            foreach (string sMes in sMeses)
            {
                //Splita o nome do mes e o seu valor numerico no array
                sGetMes = sMes.Split(':');

                //Atribui o valor numerico
                sKey = sGetMes[0];

                //Atribui o mes
                sValue = sGetMes[1];

                //Adiciona ao combox
                cboMes.Items.Add(new ListItem(sValue, sKey));
            }
        }

        /// <summary>
        /// Preenche o combo com os anos
        /// </summary>
        private void PreencheComboAno()
        {
            int iDiferencaAnos;
            int iAnoReferencia = 1950;
            int iContador = 0;
            int iAnoAtual = DateTime.Now.Year;

            //Calcula a diferença entre o ano atual e o ano de referencia
            iDiferencaAnos = iAnoAtual - iAnoReferencia;

            //Limpa o combo
            cboAno.Items.Clear();

            //Define o primeiro valor do combo
            cboAno.Items.Add(new ListItem("Ano", "-1"));

            //Faz um laço para poder preencher o combo com os meses de forma decrescente
            for (; iContador <= iDiferencaAnos; iContador++)
            {
                //Adiciona os meses no combo
                cboAno.Items.Add(new ListItem(iAnoAtual.ToString(), iAnoAtual.ToString()));

                //Decrementa o ano para poder ficar de forma decrescente
                iAnoAtual--;
            }
        }

        [WebMethod]
        public static string ConverteImageToBase64(object strImagem) 
        {            
            return "";
        }
    }
}