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
    public class IdiomaDAO : IDataAccessObject
    {
        public void Delete(int cod)
        {
            throw new NotImplementedException();
        }

        public void Insert(object obj)
        {
            throw new NotImplementedException();
        }

        public List<object> Select(int cod, DataBaseHelper.SelectType selectType)
        {
            StringBuilder sbCommand = null;
            DataBaseHelper dbHelper = null;
            SqlCommand sqlCommand = null;
            SqlDataReader sqlReader = null;
            Idioma idioma = null;
            List<object> listIdioma = null;

            //Inicializa o objeto DataBaseHelper
            dbHelper = DataBaseHelper.Create();

            //Instancia um novo StringBuilder
            sbCommand = new StringBuilder();

            //Instancia um novo SqlCommand
            sqlCommand = new SqlCommand();

            //Monta o comando
            sbCommand.Append(" SELECT * FROM TBL_IDIOMAS ");

            //Verifica se o tipo de select é de um unico itemu
            if (selectType.Equals(DataBaseHelper.SelectType.One)) 
            {
                //Adiciona o WHERE a query
                sbCommand.Append(" WHERE ID_IDIOMA = @ID ");

                //Monta um parametro com o ID do usuario
                Parameters pId = new Parameters("@ID", cod, System.Data.SqlDbType.Int);

                //Realiza a montagem do parametro
                dbHelper.BuildParameters(ref sqlCommand, pId);
            }

            //Atribui o comando ao Sql Command
            sqlCommand.CommandText = sbCommand.ToString();

            //Atribui a conexao ao SqlCommand
            sqlCommand.Connection = dbHelper.ReturnConnection();

            //Abre a conexao com o banco de dados
            dbHelper.OpenConnection();

            //Executa a leitura dos dados
            sqlReader = sqlCommand.ExecuteReader();

            //Verifica se foi retornado algum valor durante a leitura dos dados
            if (sqlReader.HasRows) 
            {
                //Instancia uma nova lista de idioma
                listIdioma = new List<object>();

                //Realiza a leitura dos dados e atribui a lista
                while (sqlReader.Read()) 
                {
                    //Instancia a model de idioma
                    idioma = new Idioma();

                    //Atribui os valore nas propriedades da Model
                    idioma.Id = Convert.ToInt32(sqlReader["ID_IDIOMA"]);
                    idioma.sIdioma = Convert.ToString(sqlReader["IDIOMA"]);

                    //Adiciona na lista
                    listIdioma.Add(idioma);
                }
            }

            //Finaliza a conexao com o banco de dados
            dbHelper.CloseConnection();

            //Retorna a lista
            return listIdioma;
        }

        public void Update(int cod, object obj)
        {
            throw new NotImplementedException();
        }
    }
}