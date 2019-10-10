using MangaStore.Model;
using MangaStore.Util;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace MangaStore.DAO
{
    public class GeneroDAO : IDataAccessObject
    {
        public void Delete(int cod)
        {
            throw new NotImplementedException();
        }

        public void Insert(object obj)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Realiza um select no banco de dados dos generos
        /// </summary>
        /// <param name="cod"></param>
        /// <param name="selectType"></param>
        /// <param name="orderBy"></param>
        /// <returns></returns>
        public List<object> Select(int cod, DataBaseHelper.SelectType selectType, DataBaseHelper.OrderBy orderBy)
        {
            StringBuilder sbCommand = null;
            SqlCommand sqlCmd = null;
            DataBaseHelper dbHelper = null;
            SqlDataReader sqlReader = null;
            Genero genero = null;
            List<object> listGenero = null;

            //Cria um novo StringBuilder
            sbCommand = new StringBuilder();

            //Cria o DataBaseHelper
            dbHelper = DataBaseHelper.Create();

            //Cria um novo SqlCommand
            sqlCmd = new SqlCommand();

            //Monta o comando
            sbCommand.Append(" SELECT * FROM TBL_GENEROS ");

            //Verifica se o tipo do select envolvera um where, para trazer um dado pelo ID
            if (selectType == DataBaseHelper.SelectType.One) 
            {
                //Monta o Where no comando
                sbCommand.Append(" WHERE ID_GENERO = @ID ");

                //Cria o parametro para a consulta
                Parameters pId = new Parameters("@ID", cod, System.Data.SqlDbType.Int);

                //Monta os parametros
                dbHelper.BuildParameters(ref sqlCmd, pId);
            }

            //Verifica se ocorrera alguma ordenação
            if (orderBy != DataBaseHelper.OrderBy.None) 
            {
                //Monta um orderby ma consulta
                dbHelper.MakeOrderBy(ref sbCommand, orderBy, "GENERO");
            }

            //Adiciona o comando ao SqlCommand
            sqlCmd.CommandText = sbCommand.ToString();

            //Retorna a conexao
            sqlCmd.Connection = dbHelper.ReturnConnection();

            //Abre conexao com o banco de dados
            dbHelper.OpenConnection();

            //Executa a leitura dos dados
            sqlReader = sqlCmd.ExecuteReader();

            //Verifica se foi retornado algum valor
            if (sqlReader.HasRows) 
            {
                //Cria uma nova lista de generos
                listGenero = new List<object>();

                //Realiza a leitura dos dados
                while (sqlReader.Read()) 
                {
                    //Cria um novo objeto 
                    genero = new Genero();

                    //Recebe os valores
                    genero.IdGenero = Convert.ToInt64(sqlReader["ID_GENERO"]);
                    genero.sGenero = Convert.ToString(sqlReader["GENERO"]);

                    //Adiciona na lista
                    listGenero.Add(genero);
                }
            }

            //Fecha a conexao com o banco de dados
            dbHelper.CloseConnection();

            //Retorna a lista com os valores
            return listGenero;
        }

        public void Update(int cod, object obj)
        {
            throw new NotImplementedException();
        }
    }
}