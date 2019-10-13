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
            sbCommand.Append(" (ISBN_LIVRO, TITULO_LIVRO, AUTOR_LIVRO, EDITORA_LIVRO, GENERO_LIVRO, IDIOMA_LIVRO, PRECO_LIVRO, QTD_PAGINAS_LIVRO, DATA_PUBLICACAO_LIVRO, CAPA_LIVRO, QUANTIDADE_LIVRO, DESCRICAO_LIVRO)  ");
            sbCommand.Append(" VALUES (@Isbn, @Titulo, @Autor, @Editora,@Genero, @Idioma, @Preco, @QtdPaginas, @DataPublicacao, @CapaLivro, @QuantidadeLivros, @Descricao) ");                        
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
            Parameters pEditora = new Parameters("@Editora", livro.Editora, SqlDbType.VarChar);
            Parameters pGenero = new Parameters("@Genero", livro.Genero, SqlDbType.VarChar);
            Parameters pIdioma = new Parameters("@Idioma", livro.Idioma, SqlDbType.VarChar);
            Parameters pPreco = new Parameters("@Preco", livro.Preco, SqlDbType.Decimal);
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
        
        public List<object> Select(int cod, DataBaseHelper.SelectType selectType, DataBaseHelper.OrderBy orderBy)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retorna um livro pela sua ISBN
        /// </summary>
        /// <param name="ISBN"></param>
        /// <param name="selectType"></param>
        /// <param name="orderBy"></param>
        /// <returns></returns>
        public object Select(string Isbn,  DataBaseHelper.OrderBy orderBy) 
        {
            Livro livro = null;
            SqlCommand sqlCmd = null;
            SqlDataReader sqlReader = null;
            StringBuilder sbCommand = null;
            DataBaseHelper dbHelper = null;

            //Cria um novo StringBuilder
            sbCommand = new StringBuilder();

            //Inicializa o dbhelper
            dbHelper = DataBaseHelper.Create();

            //Inicializa o sqlcommand
            sqlCmd = new SqlCommand();

            //Monta o comando
            sbCommand.Append(" SELECT LIVRO.COD_LIVRO, LIVRO.TITULO_LIVRO, LIVRO.AUTOR_LIVRO, LIVRO.ISBN_LIVRO, EDITORA.ID_EDITORA,EDITORA.EDITORA, GENERO.ID_GENERO, GENERO.GENERO, IDIOMA.ID_IDIOMA, IDIOMA.IDIOMA, LIVRO.PRECO_LIVRO, LIVRO.QTD_PAGINAS_LIVRO, LIVRO.DATA_PUBLICACAO_LIVRO, LIVRO.QUANTIDADE_LIVRO, LIVRO.CAPA_LIVRO, LIVRO.DESCRICAO_LIVRO ");
            sbCommand.Append(" FROM TBL_LIVRO LIVRO ");
            sbCommand.Append(" INNER JOIN TBL_EDITORA EDITORA ON EDITORA.ID_EDITORA = LIVRO.FK_EDITORA ");
            sbCommand.Append(" INNER JOIN TBL_GENEROS GENERO ON GENERO.ID_GENERO = LIVRO.FK_GENERO ");
            sbCommand.Append(" INNER JOIN TBL_IDIOMAS IDIOMA ON IDIOMA.ID_IDIOMA = LIVRO.FK_IDIOMA ");
            sbCommand.Append(" WHERE ISBN_LIVRO = @ISBN ");

            //Verifica se acrescentara a query uma ordenação
            if(orderBy != DataBaseHelper.OrderBy.None) 
            {
                //Cria a ordenação e acrescenta ao comando
                dbHelper.MakeOrderBy(ref sbCommand, orderBy, "ISBN");
            }

            //Cria o parametro a ser usado na query
            Parameters pIsbn = new Parameters("@ISBN", Isbn, SqlDbType.VarChar);

            //Constroi os parametros e adiciona ao sqlcommand
            dbHelper.BuildParameters(ref sqlCmd, pIsbn);

            //Atribui o comando no sqlcommand
            sqlCmd.CommandText = sbCommand.ToString();

            //Atribui a conexao ao sqlcommand
            sqlCmd.Connection = dbHelper.ReturnConnection();

            //Abre conexao com o banco de dados
            dbHelper.OpenConnection();

            //Executa a leitura dos dados
            sqlReader = sqlCmd.ExecuteReader();

            //Inicializa o objeto
            livro = new Livro();

            //Define como -1, pois caso não tenha encotrado nenhum valor ao buscar no banco, o -1 simbolizara que nada foi enctrado. O -1 é utilizado para realizar
            //uma verificação. if(livro.cdlivro > 0 ) livro encotrado else livro nao encotrado
            livro.CdLivro = -1;

            //Verifica se foi encotrado algum valor
            if (sqlReader.HasRows) 
            {
                //Realiza um laço para recuperar as informações retornadas do banco
                while (sqlReader.Read()) 
                {
                    //Atribui os valores nas propriedades
                    livro.CdLivro = Convert.ToInt32(sqlReader["COD_LIVRO"]);
                    livro.Isbn = Convert.ToString(sqlReader["ISBN_LIVRO"]);
                    livro.Titulo = Convert.ToString(sqlReader["TITULO_LIVRO"]);
                    livro.Autor = Convert.ToString(sqlReader["AUTOR_LIVRO"]);
                    livro.Editora = Convert.ToString(sqlReader["EDITORA"]);
                    livro.Genero = Convert.ToString(sqlReader["GENERO"]);
                    livro.Idioma = Convert.ToString(sqlReader["IDIOMA"]);
                    livro.Preco = Convert.ToDecimal(sqlReader["PRECO_LIVRO"]);
                    livro.QtdPaginas = Convert.ToInt32(sqlReader["QTD_PAGINAS_LIVRO"]);
                    livro.DataPublicacao = Convert.ToDateTime(sqlReader["DATA_PUBLICACAO_LIVRO"]);
                    livro.QuantidadeLivros = Convert.ToInt32(sqlReader["QUANTIDADE_LIVRO"]);
                    livro.CapaLivro = (byte[])(sqlReader["CAPA_LIVRO"]);
                    livro.Descricao = Convert.ToString(sqlReader["DESCRICAO_LIVRO"]);
                }
            }

            //Fecha a conexao com o banco de dados
            dbHelper.CloseConnection();

            //Retona os dados do livro
            return livro;
        }

        public void Update(int cod, object obj)
        {
            throw new NotImplementedException();
        }
    }
}