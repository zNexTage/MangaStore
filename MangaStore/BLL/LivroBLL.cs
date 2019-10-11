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

        public List<object> MakeSelect(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retorna um livro pela sua ISBN
        /// </summary>
        /// <param name="ISBN"></param>
        /// <returns></returns>
        public object MakeSelect(string ISBN, DataBaseHelper.OrderBy orderBy) 
        {
            Livro Livro = null;
            LivroDAO livroDAO = null;

            livroDAO.Select(ISBN, orderBy);

            return Livro;
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

            //Verifica se a propriedade Autor está com o valor -1 (Vazio)
            if (livro.FkEditora.Equals(-1))
            {
                /*
                 * Se estiver vazia retorna uma mensagem alertando que a propriedade esta null, em outras palavras
                 * o usuário não escolheu uma opção no combo
                 */
                return Apoio.ComboBoxInvalido("Editora");
            }

            //Verifica se a propriedade Genero está com o valor -1 (Vazio)
            if (livro.FkGenero.Equals(-1))
            {
                /*
                * Se estiver vazia retorna uma mensagem alertando que a propriedade esta null, em outras palavras
                * o usuário não escolheu uma opção no combo
                */
                return Apoio.ComboBoxInvalido("Genêro");
            }

            //Verifica se a propriedade Idioma está com o valor -1 (Vazio)
            if (livro.FkIdioma.Equals(-1))
            {
                /*
                * Se estiver vazia retorna uma mensagem alertando que a propriedade esta null, em outras palavras
                * o usuário não escolheu uma opção no combo
                */
                return Apoio.ComboBoxInvalido("Idioma");
            }

            //Verifica se a propriedade Preco está vazia
            if (string.IsNullOrEmpty(livro.Preco.ToString().Trim()))
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
                //Se tiver significa que o usuário não digitou uma data no campo de texto
                return Apoio.RetornaMensagemCampoObrigatorio("Data Publicação");
            }

            //Verifica se a propriedade QtdPaginas está vazia
            if (string.IsNullOrEmpty(livro.QuantidadeLivros.ToString().Trim()))
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
    }
}