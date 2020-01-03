using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MangaStore.DAO;
using MangaStore.Model;
using MangaStore.Util;

namespace MangaStore.BLL
{
    public class LivroBLL : IValidationHelper
    {
        private Livro livro;
        LivroDAO LivroDAO;

        /// <summary>
        /// Realiza a inserção dos dados
        /// </summary>
        /// <param name="obj"></param>
        public void MakeInsert(object obj)
        {
            //Instancia a DAO
            LivroDAO = new LivroDAO();

            //Chama o metodo para realizar a inserção
            LivroDAO.Insert(obj);
        }

        /// <summary>
        /// Realiza um select dos livros, o parametro object serve para adicionar filtros para a query.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public List<object> MakeSelect(object obj)
        {
            List<object> listLivro = null;
            LivroDAO livroDAO = null;
            Livro livro = null;

            //Realiza o cast dos valores a serem usados na query (filtro)
            livro = (Livro)obj;

            //Inicializa a dao de livros
            livroDAO = new LivroDAO();

            //Realiza o select e devolve os dados do livro
            listLivro = livroDAO.Select(livro.CdLivro, DataBaseHelper.SelectType.All, DataBaseHelper.OrderBy.ASC);

            //Retorna o livro
            return listLivro;
        }

        /// <summary>
        /// Realiza a chamada do metodo da dao de livros para retornar a capa de um livro pelo seu codigo (id)
        /// </summary>
        /// <param name="lCdLivro"></param>
        /// <returns></returns>
        public byte[] RetornaCapaLivro(long lCdLivro) 
        {
            LivroDAO livroDAO = null;

            //Instancia um novo DAO
            livroDAO = new LivroDAO();

            //Retorna a capa do livro pelo seu id
            return livroDAO.RetornaCapaLivro(lCdLivro);
        }

        /// <summary>
        /// Realiza uma validação das propriedades de um objeto
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public string ValidateFields(object obj)
        {
            //Faz o cast para recuperar os dados
            livro = (Livro)obj;

            //Verifica se a propriedade ISBN está vazia
            if (string.IsNullOrEmpty(livro.Isbn.Trim()))
            {
                /*Se estiver vazia retorna uma mensagem alertando que a propriedade esta null.
                 Em outras palavras, significa que o usuário não preencheu o campo ISBN
                 */
                return Apoio.RetornaMensagemCampoObrigatorio("ISBN");
            }

            //Verifica se a propriedade Titulo está vazia
            if (string.IsNullOrEmpty(livro.Titulo.Trim()))
            {
                /*Se estiver vazia retorna uma mensagem alertando que a propriedade esta null.
                 Em outras palavras, significa que o usuário não preencheu o campo Titulo
                 */
                return Apoio.RetornaMensagemCampoObrigatorio("Titulo");
            }

            //Verifica se a propriedade Autor está vazia
            if (string.IsNullOrEmpty(livro.Autor.Trim()))
            {
                /*Se estiver vazia retorna uma mensagem alertando que a propriedade esta null.
                 Em outras palavras, significa que o usuário não preencheu o campo Autor
                 */
                return Apoio.RetornaMensagemCampoObrigatorio("Autor");
            }

            //Verifica se a propriedade Editora está vazia
            if (string.IsNullOrEmpty(livro.Editora.Trim()))
            {
                /*
                 * Se estiver vazia retorna uma mensagem alertando que a propriedade esta null.
                 Em outras palavras, significa que o usuário não preencheu o campo Editora
                 */
                return Apoio.RetornaMensagemCampoObrigatorio("Editora");
            }

            //Verifica se a propriedade Genero está vazia
            if (string.IsNullOrEmpty(livro.Genero.Trim()))
            {
                /*
                * Se estiver vazia retorna uma mensagem alertando que a propriedade esta null.
                 Em outras palavras, significa que o usuário não preencheu o campo Genero
                */
                return Apoio.RetornaMensagemCampoObrigatorio("Genêro");
            }

            //Verifica se a propriedade Idioma está vazia
            if (string.IsNullOrEmpty(livro.Idioma.Trim()))
            {
                /*
                * Se estiver vazia retorna uma mensagem alertando que a propriedade esta null.
                 Em outras palavras, significa que o usuário não preencheu o campo Idioma
                */
                return Apoio.RetornaMensagemCampoObrigatorio("Idioma");
            }

            //Verifica se a propriedade Preco está vazia
            if (string.IsNullOrEmpty(livro.PrecoConvertido.Trim()))
            {
                /*Se estiver vazia retorna uma mensagem alertando que a propriedade esta null.
                Em outras palavras, significa que o usuário não preencheu o campo Preco
                */
                return Apoio.RetornaMensagemCampoObrigatorio("Preço");
            }

            //Verifica se a propriedade QtdPaginas está vazia
            if (string.IsNullOrEmpty(livro.QtdPaginas.ToString().Trim()))
            {
                /*Se estiver vazia retorna uma mensagem alertando que a propriedade esta null.
              Em outras palavras, significa que o usuário não preencheu o campo QtdPaginas
              */
                return Apoio.RetornaMensagemCampoObrigatorio("N° de páginas");
            }

            //Verifica se a propriedade DataPublicacao possui o valor minimo do DateTime
            if (livro.DataPublicacao.Equals(DateTime.MinValue))
            {
                //Se tiver significa que o usuário escolheu uma data (mes e ano)
                return "Por favor! Selecione um mês e um ano";
            }

            //Verifica se a propriedade QtdPaginas está vazia
            if (string.IsNullOrEmpty(livro.Quantidade.ToString().Trim()))
            {
                //Verifica se a propriedade QtdPaginas está vazia
                return Apoio.RetornaMensagemCampoObrigatorio("Quantidade Livros");
            }

            //Verifica se o usuario adicionou um capa
            if (livro.CapaLivro.Length == 0)
            {
                //Retorna a mensagem alertando que não foi adicionado uma capa
                return "É necessário escolher uma capa";
            }

            //Verifica se a propriedade Descricao está vazia
            if (string.IsNullOrEmpty(livro.Descricao.Trim()))
            {
                //Se estiver vazia significa que o usuário não preencheu o campo de texto Descrição
                return Apoio.RetornaMensagemCampoObrigatorio("Descrição");
            }

            //Se passar por todas as verificações eu retorno vazio, que sinaliza que todos os campos foram preenchidos corretamente.
            return "";
        }

        /// <summary>
        /// Retorna o preco do livro de maior de valor
        /// </summary>
        /// <returns></returns>
        public string GetBiggestPrice() 
        {
            LivroDAO daoLivro = null;

            //Instancia a classe
            daoLivro = new LivroDAO();

            //Retorna o maior preco
            return daoLivro.GetBiggestPrice();
        }

        #region Filters
        public List<object> FilterBiggestPrices() 
        {
            LivroDAO daoLivro = null;

            daoLivro = new LivroDAO();

            return daoLivro.SelectAtBiggestPrices();
        }
        #endregion
    }
}