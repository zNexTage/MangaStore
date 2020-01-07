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
            sbCommand.Append(" (ISBN_LIVRO, TITULO_LIVRO, AUTOR_LIVRO, EDITORA_LIVRO, GENERO_LIVRO, IDIOMA_LIVRO, PRECO_LIVRO, QTD_PAGINAS_LIVRO, DATA_PUBLICACAO_LIVRO, CAPA_LIVRO, QUANTIDADE_LIVRO, DESCRICAO_LIVRO, STATUS_LIVRO)  ");
            sbCommand.Append(" VALUES (@Isbn, @Titulo, @Autor, @Editora,@Genero, @Idioma, @Preco, @QtdPaginas, @DataPublicacao, @CapaLivro, @QuantidadeLivros, @Descricao,0) ");
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
            Parameters pPreco = new Parameters("@Preco", livro.PrecoConvertido, SqlDbType.Decimal);
            Parameters pQuantidadePaginas = new Parameters("@QtdPaginas", livro.QtdPaginas, SqlDbType.Int);
            Parameters pDataPublicacao = new Parameters("@DataPublicacao", livro.DataPublicacao, SqlDbType.DateTime);
            Parameters pCapaLivro = new Parameters("@CapaLivro", livro.CapaLivro, SqlDbType.VarBinary);
            Parameters pQuantidadeLivros = new Parameters("@QuantidadeLivros", livro.Quantidade, SqlDbType.Int);
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

        /// <summary>
        /// Realiza um select e retorna os livros em uma lista
        /// </summary>
        /// <param name="cod"></param>
        /// <param name="selectType"></param>
        /// <param name="orderBy"></param>
        /// <returns></returns>
        public List<object> Select(long cod, DataBaseHelper.SelectType selectType, DataBaseHelper.OrderBy orderBy)
        {
            Livro livro = null;
            SqlCommand sqlCmd = null;
            SqlDataReader sqlReader = null;
            StringBuilder sbCommand = null;
            DataBaseHelper dbHelper = null;
            List<object> listLivros = null;
            int iContador = 0;
            int iPagina = 1;

            //Cria um novo StringBuilder
            sbCommand = new StringBuilder();

            //Inicializa o dbhelper
            dbHelper = DataBaseHelper.Create();

            //Inicializa o sqlcommand
            sqlCmd = new SqlCommand();

            //Se for para selecionar todos os dados
            if (selectType == DataBaseHelper.SelectType.All)
            {
                //Monta o comando
                sbCommand.Append(" SELECT COD_LIVRO, FK_USUARIO, ISBN_LIVRO, TITULO_LIVRO, AUTOR_LIVRO, EDITORA_LIVRO, GENERO_LIVRO, IDIOMA_LIVRO, PRECO_LIVRO, QTD_PAGINAS_LIVRO, DATA_PUBLICACAO_LIVRO, QUANTIDADE_LIVRO, DESCRICAO_LIVRO, STATUS_LIVRO ");
                sbCommand.Append(" FROM TBL_LIVRO LIVRO ");
            }

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
                //Instancia um nova lista de objetos
                listLivros = new List<object>();

                //Realiza um laço para recuperar as informações retornadas do banco
                while (sqlReader.Read())
                {
                    //Realiza a contagem dos items para realiza a paginacao
                    if (iContador == 12)
                    {
                        iContador = 0;
                        iPagina = iPagina + 1;
                    }

                    //Cria um novo livro
                    livro = new Livro();

                    //Atribui os valores nas propriedades
                    livro.CdLivro = Convert.ToInt32(sqlReader["COD_LIVRO"]);
                    livro.Isbn = Convert.ToString(sqlReader["ISBN_LIVRO"]);
                    livro.Titulo = Convert.ToString(sqlReader["TITULO_LIVRO"]);
                    livro.Autor = Convert.ToString(sqlReader["AUTOR_LIVRO"]);
                    livro.Editora = Convert.ToString(sqlReader["EDITORA_LIVRO"]);
                    livro.Genero = Convert.ToString(sqlReader["GENERO_LIVRO"]);
                    livro.Idioma = Convert.ToString(sqlReader["IDIOMA_LIVRO"]);
                    livro.Preco = Convert.ToDecimal(sqlReader["PRECO_LIVRO"]);
                    livro.PrecoConvertido = string.Format("{0:C}", livro.Preco);
                    livro.QtdPaginas = Convert.ToInt32(sqlReader["QTD_PAGINAS_LIVRO"]);
                    livro.DataPublicacao = Convert.ToDateTime(sqlReader["DATA_PUBLICACAO_LIVRO"]);
                    livro.Quantidade = Convert.ToInt32(sqlReader["QUANTIDADE_LIVRO"]);
                    livro.Descricao = Convert.ToString(sqlReader["DESCRICAO_LIVRO"]);
                    livro.Status = Convert.ToInt16(sqlReader["STATUS_LIVRO"]);
                    livro.iPaginacaoLivro = iPagina;

                    //Adiciona o livro na lista
                    listLivros.Add(livro);

                    iContador++;
                }
            }

            //Fecha a conexao com o banco de dados
            dbHelper.CloseConnection();

            //Retona os livros
            return listLivros;
        }

        /// <summary>
        /// Retorna a capa de um livro pelo codigo (id)
        /// </summary>
        /// <param name="lCodLivro"></param>
        /// <returns></returns>
        public byte[] RetornaCapaLivro(long lCodLivro)
        {
            byte[] bCapaImagem = null;
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
            sbCommand.Append(" SELECT CAPA_LIVRO ");
            sbCommand.Append(" FROM TBL_LIVRO LIVRO ");
            sbCommand.Append(" WHERE COD_LIVRO = @COD_LIVRO ");

            //Cria o parametro a ser utilizado na query
            Parameters pCod = new Parameters("@COD_LIVRO", lCodLivro, SqlDbType.Int);

            //Monta o parametro e adiciona ao sql command
            dbHelper.BuildParameters(ref sqlCmd, pCod);

            //Atribui o comando no sqlcommand
            sqlCmd.CommandText = sbCommand.ToString();

            //Atribui a conexao ao sqlcommand
            sqlCmd.Connection = dbHelper.ReturnConnection();

            //Abre conexao com o banco de dados
            dbHelper.OpenConnection();

            //Executa a leitura dos dados
            sqlReader = sqlCmd.ExecuteReader();

            //Verifica se foi encotrado algum valor
            if (sqlReader.Read())
            {
                //Recebe os bytes da imagem
                bCapaImagem = (byte[])sqlReader["CAPA_LIVRO"];
            }

            //Fecha a conexao com o banco de dados
            dbHelper.CloseConnection();

            //Retona os livros
            return bCapaImagem;
        }

        /// <summary>
        /// Retorna um livro pela sua ISBN
        /// </summary>
        /// <param name="ISBN"></param>
        /// <param name="selectType"></param>
        /// <param name="orderBy"></param>
        /// <returns></returns>
        //public object Select(object Livro, DataBaseHelper.OrderBy orderBy, StatusLivro statusLivro)
        //{
        //    Livro livro = null;
        //    SqlCommand sqlCmd = null;
        //    SqlDataReader sqlReader = null;
        //    StringBuilder sbCommand = null;
        //    DataBaseHelper dbHelper = null;

        //    //Cria um novo StringBuilder
        //    sbCommand = new StringBuilder();

        //    //Inicializa o dbhelper
        //    dbHelper = DataBaseHelper.Create();

        //    //Inicializa o sqlcommand
        //    sqlCmd = new SqlCommand();

        //    //Monta o comando
        //    sbCommand.Append(" SELECT LIVRO.COD_LIVRO, LIVRO.TITULO_LIVRO, LIVRO.AUTOR_LIVRO, LIVRO.ISBN_LIVRO, EDITORA.ID_EDITORA,EDITORA.EDITORA, GENERO.ID_GENERO, GENERO.GENERO, IDIOMA.ID_IDIOMA, IDIOMA.IDIOMA, LIVRO.PRECO_LIVRO, LIVRO.QTD_PAGINAS_LIVRO, LIVRO.DATA_PUBLICACAO_LIVRO, LIVRO.QUANTIDADE_LIVRO, LIVRO.CAPA_LIVRO, LIVRO.DESCRICAO_LIVRO ");
        //    sbCommand.Append(" FROM TBL_LIVRO LIVRO ");
        //    sbCommand.Append(" INNER JOIN TBL_EDITORA EDITORA ON EDITORA.ID_EDITORA = LIVRO.FK_EDITORA ");
        //    sbCommand.Append(" INNER JOIN TBL_GENEROS GENERO ON GENERO.ID_GENERO = LIVRO.FK_GENERO ");
        //    sbCommand.Append(" INNER JOIN TBL_IDIOMAS IDIOMA ON IDIOMA.ID_IDIOMA = LIVRO.FK_IDIOMA ");
        //    sbCommand.Append(" WHERE ISBN_LIVRO = @ISBN ");

        //    //Verifica se acrescentara a query uma ordenação
        //    if (orderBy != DataBaseHelper.OrderBy.None)
        //    {
        //        //Cria a ordenação e acrescenta ao comando
        //        dbHelper.MakeOrderBy(ref sbCommand, orderBy, "ISBN");
        //    }

        //    //Cria o parametro a ser usado na query
        //    Parameters pIsbn = new Parameters("@ISBN", Isbn, SqlDbType.VarChar);

        //    //Constroi os parametros e adiciona ao sqlcommand
        //    dbHelper.BuildParameters(ref sqlCmd, pIsbn);

        //    //Atribui o comando no sqlcommand
        //    sqlCmd.CommandText = sbCommand.ToString();

        //    //Atribui a conexao ao sqlcommand
        //    sqlCmd.Connection = dbHelper.ReturnConnection();

        //    //Abre conexao com o banco de dados
        //    dbHelper.OpenConnection();

        //    //Executa a leitura dos dados
        //    sqlReader = sqlCmd.ExecuteReader();

        //    //Inicializa o objeto
        //    livro = new Livro();

        //    //Define como -1, pois caso não tenha encotrado nenhum valor ao buscar no banco, o -1 simbolizara que nada foi enctrado. O -1 é utilizado para realizar
        //    //uma verificação. if(livro.cdlivro > 0 ) livro encotrado else livro nao encotrado
        //    livro.CdLivro = -1;

        //    //Verifica se foi encotrado algum valor
        //    if (sqlReader.HasRows)
        //    {
        //        //Realiza um laço para recuperar as informações retornadas do banco
        //        while (sqlReader.Read())
        //        {
        //            //Atribui os valores nas propriedades
        //            livro.CdLivro = Convert.ToInt32(sqlReader["COD_LIVRO"]);
        //            livro.Isbn = Convert.ToString(sqlReader["ISBN_LIVRO"]);
        //            livro.Titulo = Convert.ToString(sqlReader["TITULO_LIVRO"]);
        //            livro.Autor = Convert.ToString(sqlReader["AUTOR_LIVRO"]);
        //            livro.Editora = Convert.ToString(sqlReader["EDITORA"]);
        //            livro.Genero = Convert.ToString(sqlReader["GENERO"]);
        //            livro.Idioma = Convert.ToString(sqlReader["IDIOMA"]);
        //            livro.Preco = Convert.ToDecimal(sqlReader["PRECO_LIVRO"]);
        //            livro.QtdPaginas = Convert.ToInt32(sqlReader["QTD_PAGINAS_LIVRO"]);
        //            livro.DataPublicacao = Convert.ToDateTime(sqlReader["DATA_PUBLICACAO_LIVRO"]);
        //            livro.Quantidade = Convert.ToInt32(sqlReader["QUANTIDADE_LIVRO"]);
        //            livro.CapaLivro = (byte[])(sqlReader["CAPA_LIVRO"]);
        //            livro.Descricao = Convert.ToString(sqlReader["DESCRICAO_LIVRO"]);
        //        }
        //    }

        //    //Fecha a conexao com o banco de dados
        //    dbHelper.CloseConnection();

        //    //Retona os dados do livro
        //    return livro;
        //}

        public void Update(int cod, object obj)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Seleciona todos os livros em ordem do maior preço
        /// </summary>
        /// <returns></returns>
        public List<Livro> SelectAtBiggestPrices()
        {
            List<Livro> listLivros = null;
            StringBuilder sbCommand = null;
            DataBaseHelper dbHelper = null;
            SqlCommand sqlCommand;
            SqlDataReader sqlReader = null;
            int iContador = 0;
            int iPagina = 1;
            Livro livro;

            try
            {
                sbCommand = new StringBuilder();

                sbCommand.Append(" SELECT * FROM TBL_LIVRO ");
                sbCommand.Append(" ORDER BY PRECO_LIVRO DESC ");

                //Cria o objeto 
                dbHelper = DataBaseHelper.Create();

                sqlCommand = new SqlCommand();

                sqlCommand.Connection = dbHelper.ReturnConnection();
                sqlCommand.CommandText = sbCommand.ToString();

                dbHelper.OpenConnection();

                sqlReader = sqlCommand.ExecuteReader();

                while (sqlReader.Read())
                {
                    if (iContador == 12)
                    {
                        iContador = 0;
                        iPagina = iPagina + 1;
                    }

                    //Cria um novo livro
                    livro = new Livro();

                    //Atribui os valores nas propriedades
                    livro.CdLivro = Convert.ToInt32(sqlReader["COD_LIVRO"]);
                    livro.Isbn = Convert.ToString(sqlReader["ISBN_LIVRO"]);
                    livro.Titulo = Convert.ToString(sqlReader["TITULO_LIVRO"]);
                    livro.Autor = Convert.ToString(sqlReader["AUTOR_LIVRO"]);
                    livro.Editora = Convert.ToString(sqlReader["EDITORA_LIVRO"]);
                    livro.Genero = Convert.ToString(sqlReader["GENERO_LIVRO"]);
                    livro.Idioma = Convert.ToString(sqlReader["IDIOMA_LIVRO"]);
                    livro.Preco = Convert.ToDecimal(sqlReader["PRECO_LIVRO"]);
                    livro.PrecoConvertido = string.Format("{0:C}", livro.Preco);
                    livro.QtdPaginas = Convert.ToInt32(sqlReader["QTD_PAGINAS_LIVRO"]);
                    livro.DataPublicacao = Convert.ToDateTime(sqlReader["DATA_PUBLICACAO_LIVRO"]);
                    livro.Quantidade = Convert.ToInt32(sqlReader["QUANTIDADE_LIVRO"]);
                    livro.Descricao = Convert.ToString(sqlReader["DESCRICAO_LIVRO"]);
                    livro.Status = Convert.ToInt16(sqlReader["STATUS_LIVRO"]);
                    livro.iPaginacaoLivro = iPagina;

                    //Adiciona o livro na lista
                    listLivros.Add(livro);

                    iContador++;
                }

                return listLivros;
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
            finally
            {
                //Fecha a conexao com o banco de dados
                dbHelper.CloseConnection();
            }
        }

        /// <summary>
        /// Retorna o livro com maior preco
        /// </summary>
        /// <returns></returns>
        public string GetBiggestPrice()
        {
            StringBuilder sbCommand = null;
            DataBaseHelper dbHelper = null;
            SqlCommand sqlCommand = null;
            SqlDataReader sqlReader = null;
            string sMaiorPreco = "";
            decimal dcmMaiorPreco = 0;

            try
            {
                sbCommand = new StringBuilder();

                //Monta o comando
                sbCommand.Append(" SELECT MAX(PRECO_LIVRO) AS PRECO_LIVRO FROM TBL_LIVRO ");

                //Cria o objeto 
                dbHelper = DataBaseHelper.Create();

                //Cria o objeto
                sqlCommand = new SqlCommand();

                //Atribui a conexao e o comando a ser executado
                sqlCommand.Connection = dbHelper.ReturnConnection();
                sqlCommand.CommandText = sbCommand.ToString();

                //Abre a conexao
                dbHelper.OpenConnection();

                //Executa o comando
                sqlReader = sqlCommand.ExecuteReader();

                //Verifica se houve algum retorno
                if (sqlReader.HasRows)
                {
                    //Realiza a leitura
                    sqlReader.Read();

                    //Recebe o preco e logo após converte para formato de dinheiro
                    dcmMaiorPreco = Convert.ToDecimal(sqlReader["PRECO_LIVRO"]);
                    sMaiorPreco = string.Format("{0:0.00}", dcmMaiorPreco);
                }

                return sMaiorPreco;
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
            finally
            {
                dbHelper.CloseConnection();
            }
        }

        /// <summary>
        /// Filtra os livros de acordo com as escolhas do usuário
        /// </summary>
        /// <param name="sMensagem"></param>
        /// <param name="livro"></param>
        /// <returns></returns>
        public List<object> FilterAllBooks(ref string sMensagem, Livro livro)
        {
            SqlCommand sqlCommand;
            StringBuilder sbCommand;
            Parameters pIsbn, pTitulo, pAutor, pEditora, pGenero, pPrecoMenor, pPrecoMaior;
            SqlDataReader sqlReader;
            int iContador = 0, iPagina = 1;
            List<object> listLivros = null;
            StringBuilder sbMensagem = null;
            int iContClausureAnd = 0;
            int iMenorPreco, iMaiorPreco;

            //Instancia o objeto
            sbCommand = new StringBuilder();
            sbMensagem = new StringBuilder();

            //Instancia o objeto
            sqlCommand = new SqlCommand();

            //Abre a conexao com o banco de dados
            DataBaseHelper.dbHelper.OpenConnection();

            //Monta o select do comando
            sbCommand.Append(" SELECT * FROM TBL_LIVRO WHERE ");

            //Monta uma mensagem para caso não seja encontrado um livro com os filtros do usuario
            sbMensagem.Append(" <label> Não foi encontrado livro com: </label><br />");

            //Verifica se é para filtrar pela isbn
            if (!string.IsNullOrEmpty(livro.Isbn.Trim()))
            {
                //Verifica se precisa adicionar a clausula AND
                if (iContClausureAnd > 0)
                {
                    sbCommand.Append(" AND ");
                }

                //Incrementa para que poder adicionar a clausula and nos proximos filtros.
                iContClausureAnd++;

                sbCommand.Append(" ISBN_LIVRO LIKE @ISBN ");
                pIsbn = new Parameters("@ISBN", string.Format("%{0}%", livro.Isbn), SqlDbType.VarChar);
                DataBaseHelper.dbHelper.BuildParameters(ref sqlCommand, pIsbn);

                //Adiciona a isbn na mensagem de livro não encotrado, para caso a isbn digitada não seja encotrada
                sbMensagem.Append(string.Format(" <label> ISBN: {0} </label><br />  ", livro.Isbn));
            }

            //Verifica se é para filtrar pelo titulo
            if (!string.IsNullOrEmpty(livro.Titulo.Trim()))
            {
                //Verifica se precisa adicionar a clausula AND
                if (iContClausureAnd > 0)
                {
                    sbCommand.Append(" AND ");
                }

                //Incrementa para que poder adicionar a clausula and nos proximos filtros.
                iContClausureAnd++;

                sbCommand.Append(" TITULO_LIVRO LIKE @TITULO ");
                pTitulo = new Parameters("@TITULO", string.Format("%{0}%", livro.Titulo), SqlDbType.VarChar);
                DataBaseHelper.dbHelper.BuildParameters(ref sqlCommand, pTitulo);

                //Adiciona o titulo na mensagem de livro não encotrado, para caso o titulo digitado não seja encotrado
                sbMensagem.Append(string.Format(" <label> Titulo: {0} </label><br />  ", livro.Titulo));
            }

            //Verifica se é para filtrar pelo autor
            if (!string.IsNullOrEmpty(livro.Autor.Trim()))
            {
                //Verifica se precisa adicionar a clausula AND
                if (iContClausureAnd > 0)
                {
                    sbCommand.Append(" AND ");
                }

                //Incrementa para que poder adicionar a clausula and nos proximos filtros.
                iContClausureAnd++;

                sbCommand.Append(" AUTOR_LIVRO LIKE @AUTOR ");
                pAutor = new Parameters("@AUTOR", string.Format("%{0}%", livro.Autor), SqlDbType.VarChar);
                DataBaseHelper.dbHelper.BuildParameters(ref sqlCommand, pAutor);

                //Adiciona o autor na mensagem de livro não encotrado, para caso o autor digitado não seja encotrado
                sbMensagem.Append(string.Format("<label> Autor: {0} </label> <br />", livro.Autor));
            }

            //Verifica se é para filtrar pela editora
            if (!string.IsNullOrEmpty(livro.Editora.Trim()))
            {
                if (iContClausureAnd > 0)
                {
                    sbCommand.Append(" AND ");
                }

                iContClausureAnd++;

                sbCommand.Append(" EDITORA_LIVRO LIKE @EDITORA ");
                pEditora = new Parameters("@EDITORA", string.Format("%{0}%", livro.Editora), SqlDbType.VarChar);
                DataBaseHelper.dbHelper.BuildParameters(ref sqlCommand, pEditora);

                //Adiciona a editora na mensagem de livro não encotrado, para caso a editora digitada não seja encotrada
                sbMensagem.Append(string.Format("<label> Editora: {0} </label> <br />", livro.Editora));
            }

            //Verifica se é para filtrar pelo genero
            if (!string.IsNullOrEmpty(livro.Genero.Trim()))
            {
                //Verifica se precisa adicionar a clausula AND
                if (iContClausureAnd > 0)
                {
                    sbCommand.Append(" AND ");
                }

                //Incrementa para que poder adicionar a clausula and nos proximos filtros.
                iContClausureAnd++;

                sbCommand.Append(" GENERO_LIVRO LIKE @GENERO ");
                pGenero = new Parameters("@GENERO", string.Format("%{0}%", livro.Genero), SqlDbType.VarChar);
                DataBaseHelper.dbHelper.BuildParameters(ref sqlCommand, pGenero);

                //Adiciona o genero na mensagem de livro não encotrado, para caso o genero digitado não seja encotrado
                sbMensagem.Append(string.Format("<label> Genero: {0} </label> <br />", livro.Genero));
            }

            //Verifica se é para filtrar pelo preco
            if (!livro.Preco.Equals("0"))
            {
                //Verifica se precisa adicionar a clausula AND
                if (iContClausureAnd > 0)
                {
                    sbCommand.Append(" AND ");
                }

                //Incrementa para que poder adicionar a clausula and nos proximos filtros.
                iContClausureAnd++;
                         
                //Calcula a diferença e a soma em 10 do valor digitado pelo usuario, para trazer resultados aproximados
                iMenorPreco = Convert.ToInt32(livro.Preco - 5);
                iMaiorPreco = Convert.ToInt32(livro.Preco + 5);

                sbCommand.Append(" PRECO_LIVRO >= @MENOR_PRECO AND PRECO_LIVRO <= @MAIOR_PRECO ");
                pPrecoMenor = new Parameters("@MENOR_PRECO", iMenorPreco, SqlDbType.VarChar);
                pPrecoMaior = new Parameters("@MAIOR_PRECO", iMaiorPreco, SqlDbType.VarChar);
                DataBaseHelper.dbHelper.BuildParameters(ref sqlCommand, pPrecoMenor, pPrecoMaior);

                //Adiciona o preço na mensagem de livro não encotrado, para caso o preco digitado não seja encotrado
                sbMensagem.Append(string.Format("<label> Preço aproximado de: {0} </label> <br />", livro.Preco));
            }

            //Abre a conexao com o banco de dados
            sqlCommand.Connection = DataBaseHelper.dbHelper.ReturnConnection();

            //Monta o comando
            sqlCommand.CommandText = sbCommand.ToString();

            //Executa o reader
            sqlReader = sqlCommand.ExecuteReader();

            //Verifica se foi retornado valores
            if (sqlReader.HasRows)
            {
                //Instancia a lista
                listLivros = new List<object>();

                //Realiza um laço para recuperar as informações retornadas do banco
                while (sqlReader.Read())
                {

                    if (iContador == 12)
                    {
                        iContador = 0;
                        iPagina = iPagina + 1;
                    }

                    //Cria um novo livro
                    livro = new Livro();

                    //Atribui os valores nas propriedades
                    livro.CdLivro = Convert.ToInt32(sqlReader["COD_LIVRO"]);
                    livro.Isbn = Convert.ToString(sqlReader["ISBN_LIVRO"]);
                    livro.Titulo = Convert.ToString(sqlReader["TITULO_LIVRO"]);
                    livro.Autor = Convert.ToString(sqlReader["AUTOR_LIVRO"]);
                    livro.Editora = Convert.ToString(sqlReader["EDITORA_LIVRO"]);
                    livro.Genero = Convert.ToString(sqlReader["GENERO_LIVRO"]);
                    livro.Idioma = Convert.ToString(sqlReader["IDIOMA_LIVRO"]);
                    livro.Preco = Convert.ToDecimal(sqlReader["PRECO_LIVRO"]);
                    livro.PrecoConvertido = string.Format("{0:C}", livro.Preco);
                    livro.QtdPaginas = Convert.ToInt32(sqlReader["QTD_PAGINAS_LIVRO"]);
                    livro.DataPublicacao = Convert.ToDateTime(sqlReader["DATA_PUBLICACAO_LIVRO"]);
                    livro.Quantidade = Convert.ToInt32(sqlReader["QUANTIDADE_LIVRO"]);
                    livro.Descricao = Convert.ToString(sqlReader["DESCRICAO_LIVRO"]);
                    livro.Status = Convert.ToInt16(sqlReader["STATUS_LIVRO"]);
                    livro.iPaginacaoLivro = iPagina;

                    //Adiciona o livro na lista
                    listLivros.Add(livro);

                    //Incrementa o contador de paginas para a paginação
                    iContador++;
                }
            }

            //Recebe uma possivel mensagem de livro não encotrado
            sMensagem = sbMensagem.ToString();

            //Fecha a conexa com o banco de dados
            DataBaseHelper.dbHelper.CloseConnection();

            //Retorna a lista com os livros
            return listLivros;
        }
    }
}