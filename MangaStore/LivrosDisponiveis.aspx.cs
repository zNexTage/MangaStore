using MangaStore.BLL;
using MangaStore.Model;
using MangaStore.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MangaStore
{
    public partial class LivrosDisponiveis : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try 
            {
                //Preenche o repeater com os livros
                PreencheRepeaterLivros();
            }
            catch (Exception err) 
            {
                //Demonstra uma mensagem para o usuario sinalizando que ocorreu um erro
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", string.Format("modalMessage('{0}', '{1}')", "Atenção!!", "Ocorreu um erro!! Contate o administrador do sistema"), true);
            }
        }

        /// <summary>
        /// Realiza o preenchimento do repeater com os livros
        /// </summary>
        private void PreencheRepeaterLivros() 
        {
            LivroBLL livroBLL = null;
            List<object> listLivros = null;
            Livro livro = null;

            //Cria um novo objeto 
            livroBLL = new LivroBLL();

            //Instancia um novo objeto
            livro = new Livro();

            //Define o codigo do livro como -1, pois não iremos utilizar filtro por id
            livro.CdLivro = -1;

            //Realiza o select para poder preencher a lista
            listLivros =  livroBLL.MakeSelect(livro);

            //Preenche o repeater com a lista
            rptLivrosDiponiveis.DataSource = listLivros;
            rptLivrosDiponiveis.DataBind();
        }
    }
}