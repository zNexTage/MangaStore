using MangaStore.BLL;
using MangaStore.Model;
using MangaStore.Util;
using System;
using System.Collections.Generic;
using System.Web.UI;

namespace MangaStore
{
    public partial class LivrosDisponiveis : System.Web.UI.Page
    {
        //Quantidade maxima de livros que serão demonstrados na pagina
        public const short FL_QTD_LIMITE_LIVROS = 12;

        protected void Page_Load(object sender, EventArgs e)
        {
            try 
            {
                if (!this.IsPostBack)
                {
                    //Preenche o repeater com os livros
                    PreencheRepeaterLivros();
                }
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
            List<Livro> listLivroAux = null;
            Livro livro = null;
            int iUltimaPagina = 0;
            string sMaiorPreco;
            double dMaiorPreco;

            btnProximo.Enabled = false;
            btnAnterior.Enabled = false;

            //Cria um novo objeto 
            livroBLL = new LivroBLL();

            //Instancia um novo objeto
            livro = new Livro();

            //Define o codigo do livro como -1, pois não iremos utilizar filtro por id
            livro.CdLivro = -1;

            //Realiza o select para poder preencher a lista
            listLivros =  livroBLL.MakeSelect(livro);

            //Instancia a lisa
            listLivroAux = new List<Livro>();

            //Faz um laco para pegar os items da list<object> e adicionar na list<livros>
            foreach (Livro livroAux in listLivros) 
            {
                listLivroAux.Add(livroAux);
            }
            
            //Recebe a ultima pagina para realiza a paginacao
            iUltimaPagina = listLivroAux[listLivroAux.Count - 1].iPaginacaoLivro;

            //Salva na sessao a ultima para poder reutilizar
            Session[Sessao.ULTIMA_PAGINA_PAGINACAO] = iUltimaPagina;

            //Recebe o preco do livro mais caro
            sMaiorPreco = livroBLL.GetBiggestPrice();

            //Converte o preco  em double
            dMaiorPreco = Convert.ToDouble(sMaiorPreco);

            //Arrendonda o preco do livro mais caro
            dMaiorPreco = Math.Round(dMaiorPreco);

            //Adiciona o atributo max no ranger junto com o valor
            rgPreco.Attributes.Add("max", dMaiorPreco.ToString());

            //Adiciona o preco do livro mais caro na label
            lblPrecoMax.Text = string.Format("R$ {0}", dMaiorPreco);

            //Verifica a quantidade de livros retornados com a quantidade que sera demonstrada na pagina
            if (listLivroAux.Count >= FL_QTD_LIMITE_LIVROS) 
            {
                //Cria a paginacao dos livros
                listLivros = CriarPaginacao(listLivros);

                //Por ser a primeira pagina, bloqueia o botão anterior e habilita o proximo
                AjustarBotoesPaginacao(false, true);
            }

            //Preenche o repeater com a lista
            rptLivrosDiponiveis.DataSource = listLivros;
            rptLivrosDiponiveis.DataBind();
        }


        public List<object> CriarPaginacao(List<object> listLivro) 
        {
            List<object> listLivros;

            //Guarda a lista de livros na sessao
            Session[Sessao.LISTA_LIVROS] = listLivro;

            //Define como 12, pois sera demonstrado os dozes primeiros livros
            Session[Sessao.PAGINA_ATUAL] = 1;

            //Instancia a lista de livros
            listLivros = new List<object>();

            //Faz um laço para pegar somente os primeiros 12 valores
            foreach (Livro livroAux in listLivro)
            {
                //Verifica se ja foi adicionado 12 livros na lista
                if (livroAux.iPaginacaoLivro == 1) 
                {
                    //Adiciona os livros na lista
                    listLivros.Add(livroAux);
                }
            }

            //Retorna a lista de livros
            return listLivros;
        }
                
        /// <summary>
        /// Retorna a paginacao para os 12 livros anteriores da lista
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAnterior_Click(object sender, EventArgs e)
        {
            List<object> listLivros = null;
            List<object> listLivrosAux = null;
            int iPaginaAtual;
            int iPaginaAnterior;

            try
            {
                //Verifica se a sessao com a lista de livros esta vazia
                if (Session[Sessao.LISTA_LIVROS] == null || Session[Sessao.PAGINA_ATUAL] == null || Session[Sessao.ULTIMA_PAGINA_PAGINACAO] == null)
                {
                    //Preenche o repeater novamente e a sessao com a lista
                    PreencheRepeaterLivros();

                    //Finaliza a execução do método
                    return;
                }

                //Adiciona a lista de sessão na variavel
                listLivros = (List<object>)Session[Sessao.LISTA_LIVROS];

                //Recebe a pagina atual da paginacao
                iPaginaAtual = Convert.ToInt32(Session[Sessao.PAGINA_ATUAL]);

                //Calcula qual sera a pagina anterior
                iPaginaAnterior = iPaginaAtual - 1;

                //Verifica se a pagina anterior é igual a 1
                if(iPaginaAnterior == 1) 
                {
                    //Se for o botao Anterior é bloqueado
                    AjustarBotoesPaginacao(false, true);
                }

                //Instancia a lista
                listLivrosAux = new List<object>();

                //Faz um laço pelos items da lista, para pegar os item pertencentes da pagina que sera usada na paginacao
                foreach (Livro livro in listLivros) 
                {
                    if (livro.iPaginacaoLivro == iPaginaAnterior) 
                    {
                        listLivrosAux.Add(livro);
                    }
                }
                
                //Atualiza a sessao que guarda o valor da pagina atual
                Session[Sessao.PAGINA_ATUAL] = iPaginaAnterior;

                //Preenche o repeater 
                rptLivrosDiponiveis.DataSource = listLivrosAux;
                rptLivrosDiponiveis.DataBind();

                //Atualiza o repeater dos livros
                uptLivros.Update();
            }
            catch (Exception err)
            {
                Apoio.DialogMessage(this, this.GetType(), "Atençao!!", "Ocorreu um erro");
            }
        }

        /// <summary>
        /// Avança a paginacao para os 12 livros anteriores da lista
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnProximo_Click(object sender, EventArgs e)
        {
            List<object> listLivros = null;
            List<object> listLivrosAux = null;
            int iPaginaAtual;
            int iUltimaPagina;
            int iProximaPagina;

            try
            {
                //Verifica se a sessao com a lista de livros esta vazia
                if (Session[Sessao.LISTA_LIVROS] == null || Session[Sessao.PAGINA_ATUAL] == null)
                {
                    //Preenche o repeater novamente e a sessao com a lista
                    PreencheRepeaterLivros();

                    //Finaliza a execução do método
                    return;
                }

                //Adiciona a lista de sessão na variavel
                listLivros = (List<object>)Session[Sessao.LISTA_LIVROS];

                //Recebe a pagina atual da paginacao
                iPaginaAtual = Convert.ToInt32(Session[Sessao.PAGINA_ATUAL]);

                //Calcula qual sera a proxima pagina
                iProximaPagina = iPaginaAtual + 1;

                //Recebe a ultima pagina
                iUltimaPagina = Convert.ToInt32(Session[Sessao.ULTIMA_PAGINA_PAGINACAO]);

                //Verifica se é a ultima pagina
                if (iProximaPagina == iUltimaPagina) 
                {
                    //Bloqueia o botao Proximo
                    AjustarBotoesPaginacao(true, false);
                }

                //Instancia a lista de livros
                listLivrosAux = new List<object>();

                //Faz um laço pelos items da lista, para pegar os item pertencentes da pagina que sera usada na paginacao
                foreach (Livro livro in listLivros)
                {
                    if (livro.iPaginacaoLivro == iProximaPagina)
                    {
                        listLivrosAux.Add(livro);
                    }
                }

                //Atualiza a sessao que guarda o valor da pagina atual
                Session[Sessao.PAGINA_ATUAL] = iProximaPagina;

                //Preenche o repeater
                rptLivrosDiponiveis.DataSource = listLivrosAux;
                rptLivrosDiponiveis.DataBind();

                //Atualiza o repeater com os livros
                uptLivros.Update();
            }
            catch (Exception err)
            {
                Apoio.DialogMessage(this, this.GetType(), "Atençao!!", "Ocorreu um erro");
            }
        }

        /// <summary>
        /// Habilita/Desabilita os botoes de paginacao
        /// </summary>
        /// <param name="bbtnAterior"></param>
        /// <param name="bBtnProximo"></param>
        private void AjustarBotoesPaginacao(bool bbtnAterior, bool bBtnProximo) 
        {
            btnAnterior.Enabled = bbtnAterior;
            btnProximo.Enabled = bBtnProximo;
        }
    }
}