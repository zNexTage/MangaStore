using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

                //Preenche o combo com os idiomas
                PreencheComboIdiomas();

                //Preenche o combo com as editoras
                PreencheComboEditoras();

                //Preenche o combo com os generos
                PreencheComboGenero();
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
            string sKey = "";
            string sValue = "";
            string[] sGetMes = null;

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
            int iDiferencaAnos = 0;
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

        /// <summary>
        /// Preenche o combo com os idiomas
        /// </summary>
        private void PreencheComboIdiomas() 
        {
            List<object> listIdiomas = null;
            IdiomaBLL idiomaBLL = null;

            //Instancial a classe de validações
            idiomaBLL = new IdiomaBLL();

            //Realiza a chamada do Select dos idiomas
            listIdiomas = idiomaBLL.MakeSelect(-1);

            //Verifica se a lista possui valores
            if (listIdiomas != null) 
            {
                //Limpa o combo antes de preenche-lo
                cboIdioma.Items.Clear();

                //Determino o primeiro valor do combo
                cboIdioma.Items.Add(new ListItem("Escolha um idioma...", "-1"));

                //Realiza um laço pela lista
                foreach (Idioma idioma in listIdiomas)
                {
                    //Preenche o combo
                    cboIdioma.Items.Add(new ListItem(idioma.sIdioma, idioma.Id.ToString()));
                }

                //Adiciona a ultima opção
                cboIdioma.Items.Add(new ListItem("Outro", "-2"));
            }
        }

        /// <summary>
        /// Preenche o combo com os dados vindos do banco de dados
        /// </summary>
        private void PreencheComboEditoras() 
        {
            EditoraBLL editoraBLL = null;
            List<object> listEditora = null;

            //Instancia um novo objeto
            editoraBLL = new EditoraBLL();

            /*Realiza o select das editoras. o -1 representa que nenhum id sera utilizado, portanto é um select geral;
             Preenche o combo com a lista retornada
             */
            listEditora = editoraBLL.MakeSelect(-1);

            //Limpa o combo
            cboEditora.Items.Clear();

            //Adiciona o primeiro item do combo
            cboEditora.Items.Add(new ListItem("Selecione Uma Editora...", "-1"));

            //Verifica se a lista retornou com valores
            if (listEditora != null)
            {
                //Realiza um laço pelos dados
                foreach (Editora editora in listEditora)
                {
                    //Preenche o combo com as editoras
                    cboEditora.Items.Add(new ListItem(editora.sEditora, editora.IdEditora.ToString()));
                }

                //Adiciona o ultimo item da lista
                cboEditora.Items.Add(new ListItem("Outro...", "0"));
            }
        }

        /// <summary>
        /// Preenche o combo de generos com os dados vindos do banco de dados
        /// </summary>
        private void PreencheComboGenero() 
        {
            GeneroBLL generoBLL = null;
            List<object> listGenero = null;

            //Cria um novo objeto
            generoBLL = new GeneroBLL();

            //Realiza o select de todos os generos
            listGenero = generoBLL.MakeSelect(-1);

            //Se a lista retornada for diferente de null
            if(listGenero != null)
            {
                //Limpa o combo 
                cboGenero.Items.Clear();

                //Preenche o combo com o primeiro valor
                cboGenero.Items.Add(new ListItem("Escolha um gênero...", "-1"));

                //Faz um laço pela lista de genero
                foreach (Genero genero in listGenero) 
                {
                    //Preenche o combo com os dados 
                    cboGenero.Items.Add(new ListItem(genero.sGenero, genero.IdGenero.ToString()));
                }

                //Preenche o combo com o ultimo valor 
                cboGenero.Items.Add(new ListItem("Outro...", "0"));
            }
        }
    }
}