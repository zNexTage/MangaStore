using System;
using System.Collections.Generic;
using MangaStore.Model;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using MangaStore.Util;

namespace MangaStore.DAO
{
    public class LivroDAO : IDataAccessObject
    {
        public void Delete(int cod)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Realiza a inserção de um novo livro
        /// </summary>
        /// <param name="obj"></param>
        public void Insert(object obj)
        {            
            Livro livro = null;            
            DataBaseHelper dbHelper = null;
            SqlCommand sqlCommand = null;
            StringBuilder sbCommand = null;

            //Realiza o cast do object para Livro para utilizar os atributos
            livro = (Livro)obj;

            //Cria um novo StringBuilder
            sbCommand = new StringBuilder();

            //Monta o comando
            sbCommand.Append(" INSERT INTO TBL_LIVRO  ");
            sbCommand.Append(" (ISBN_LIVRO, TITULO_LIVRO, AUTOR_LIVRO, FK_EDITORA, FK_GENERO, FK_IDIOMA, PRECO_LIVRO, QTD_PAGINAS_LIVRO, DATA_PUBLICACAO_LIVRO, CAPA_LIVRO, QUANTIDADE_LIVRO, DESCRICAO_LIVRO)  ");
            sbCommand.Append(" VALUES (@Isbn, @Titulo, @Autor, @FkEditora, @FkEditora, @FkIdioma, @Preco, @QtdPaginas, @DataPublicacao, @CapaLivro, @QuantidadeLivros, @Descricao) ");
                        
            //Inicializa o objeto DataBaseHelper
            dbHelper = DataBaseHelper.Create();

            //Atribui o comando ao objeto SqlCommand
            sqlCommand = new SqlCommand(sbCommand.ToString());

            //Atribui o conection a ser usado
            sqlCommand.Connection = dbHelper.ReturnConnection();

            //Monta os parametros
            Parameters pIsbn = new Parameters("@Isbn", livro.Isbn, SqlDbType.VarChar);
            Parameters pTitulo = new Parameters("@Titulo", livro.Titulo, SqlDbType.VarChar);
            Parameters pAutor = new Parameters("@Autor", livro.Autor, SqlDbType.VarChar);
            Parameters pEditora = new Parameters("@FkEditora", livro.FkEditora, SqlDbType.Int);
            Parameters pGenero = new Parameters("@FkGenero", livro.FkGenero, SqlDbType.Int);
            Parameters pIdioma = new Parameters("@FkIdioma", livro.FkIdioma, SqlDbType.Int);
            Parameters pPreco = new Parameters("@Preco", livro.Preco, SqlDbType.Money);
            Parameters pQuantidadePaginas = new Parameters("@QtdPaginas", livro.QtdPaginas, SqlDbType.Int);
            Parameters pDataPublicacao = new Parameters("@DataPublicacao", livro.DataPublicacao, SqlDbType.DateTime);
            Parameters pCapaLivro = new Parameters("@CapaLivro", livro.CapaLivro, SqlDbType.VarBinary);
            Parameters pQuantidadeLivros = new Parameters("@QuantidadeLivros", livro.QuantidadeLivros,SqlDbType.Int);
            Parameters pDescricao = new Parameters("@Descricao", livro.Descricao, SqlDbType.VarChar);

            //Atribui os parametros ao objeto SqlCommand
            dbHelper.BuildParameters(ref sqlCommand, pIsbn, pTitulo, pAutor, pEditora, pGenero, pIdioma, pPreco, pQuantidadePaginas, pDataPublicacao, pCapaLivro, pQuantidadeLivros, pDescricao);
            
            //Abre conexao 
            dbHelper.OpenConnection();

            //Executa a query
            sqlCommand.ExecuteNonQuery();

            //Fecha a conexao
            dbHelper.CloseConnection();
        }
        
        public List<object> Select(int cod, DataBaseHelper.SelectType selectType)
        {
            throw new NotImplementedException();
        }

        public void Update(int cod, object obj)
        {
            throw new NotImplementedException();
        }
    }
}