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
    public class EditoraDAO : IDataAccessObject
    {
        public void Delete(int cod)
        {
            throw new NotImplementedException();
        }

        public void Insert(object obj)
        {
            throw new NotImplementedException();
        }

        public List<object> Select(int cod, DataBaseHelper.SelectType selectType, DataBaseHelper.OrderBy orderBy)
        {
            SqlCommand sqlCmd = null;
            DataBaseHelper dbHelper = null;
            StringBuilder sbCommand = null;
            List<object> listEditoras = null;
            SqlDataReader sqlReader = null;
            Editora editora = null;

            //Cria um novo string builder
            sbCommand = new StringBuilder();

            //Cria um novo dbHelper
            dbHelper = DataBaseHelper.Create();

            //Cria um novo SqlCommand
            sqlCmd = new SqlCommand();

            //Monta o comando
            sbCommand.Append(" SELECT * FROM TBL_EDITORA ");

            //Verifica se irá adicionar o where para trazer uma unica editora
            if (selectType == DataBaseHelper.SelectType.One) 
            {
                //Adiciona o where no comando
                sbCommand.Append(" WHERE ID_EDITORA = @ID ");

                //Cria o parametro de ID da editora
                Parameters pId = new Parameters("@ID", cod, System.Data.SqlDbType.Int);

                //Monta os parametros
                dbHelper.BuildParameters(ref sqlCmd, pId);
            }

            //Verifica se irá ocorrer uma ordenação
            if(orderBy != DataBaseHelper.OrderBy.None) 
            {
                //Adiciona o OrderBy no comando
                dbHelper.MakeOrderBy(ref sbCommand, orderBy, "EDITORA");
            }

            //Adiciona o comando a ser executado
            sqlCmd.CommandText = sbCommand.ToString();

            //Atribui a conexao ao banco de dados
            sqlCmd.Connection = dbHelper.ReturnConnection();

            //Abre a conexao com o banco de dados
            dbHelper.OpenConnection();

            //Executa a leitura dos dados
            sqlReader = sqlCmd.ExecuteReader();

            //Se foi retornado algum valor
            if (sqlReader.HasRows) 
            {
                //Instancia a lista de editoras
                listEditoras = new List<object>();

                //Realiza a leitura
                while (sqlReader.Read()) 
                {
                    //Cria um novo objeto Editora
                    editora = new Editora();

                    //Atribui os valores nas propriedades
                    editora.IdEditora = Convert.ToInt64(sqlReader["ID_EDITORA"]);
                    editora.sEditora = Convert.ToString(sqlReader["EDITORA"]);

                    //Adiciona a lista
                    listEditoras.Add(editora);
                }
            }

            //Fecha a conexao com o banco de dados
            dbHelper.CloseConnection();

            //Retorna a lista 
            return listEditoras;
        }

        public void Update(int cod, object obj)
        {
            throw new NotImplementedException();
        }
    }
}