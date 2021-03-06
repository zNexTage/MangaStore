﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.ComponentModel;
using MangaStore.Util;
using System.Text;

namespace MangaStore.DAO
{
    public class DataBaseHelper
    {
        #region Atributos
        public static DataBaseHelper dbHelper = DataBaseHelper.Create();
        #endregion

        #region Propriedades
        public SqlConnection MyDbConnection { get; set; }
        #endregion

        #region Construtor
        public DataBaseHelper()
        {
            string ConnectionString;

            //Recupera do web config a connection string e atribui a variavel
            ConnectionString = ConfigurationManager.AppSettings["DB_MANGA_STORE"];

            //Cria um novo objeto SqlConnection
            this.MyDbConnection = new SqlConnection(ConnectionString);            
        }
        #endregion

        #region Metodos Publicos

        /// <summary>
        /// Cria um novo objeto DataBaseHelper
        /// </summary>
        /// <returns></returns>
        public static DataBaseHelper Create()
        {
            //Retorna um novo objeto DataBaseHelper
            return new DataBaseHelper();
        }

        /// <summary>
        /// Abre conexão com o banco de dados
        /// </summary>
        public void OpenConnection()
        {
            //Verifica se ja não há conexão aberta com o banco
            if (this.MyDbConnection.State == ConnectionState.Closed)
            {
                //Realiza a conexão
                MyDbConnection.Open();
            }
        }

        /// <summary>
        /// Fecha a conexão com o banco de dados
        /// </summary>
        public void CloseConnection()
        {
            //Verifica se a conexao está aberta
            if (this.MyDbConnection.State == ConnectionState.Open)
            {
                this.MyDbConnection.Close();
            }
        }

        /// <summary>
        /// Monta os parametros e adiciona ao sqlcommand
        /// </summary>
        /// <param name="sqlCmd"></param>
        /// <param name="Parametros"></param>
        public void BuildParameters(ref SqlCommand sqlCmd, params Parameters[] Parametros)
        {
            //Faz um laço pelos parametros
            foreach (Parameters Parameter in Parametros)
            {
                //Adiciona os parametros no SqlCommand
                sqlCmd.Parameters.AddWithValue(Parameter.Key, Parameter.Value).SqlDbType = Parameter.dbType;
            }            
        }

        /// <summary>
        /// Retorna o objeto de conexao
        /// </summary>
        /// <returns></returns>
        public SqlConnection ReturnConnection()
        {
            return this.MyDbConnection;
        }

        /// <summary>
        /// Adiciona ao comando uma ordenação
        /// </summary>
        /// <param name="sbCommand"></param>
        /// <param name="order"></param>
        public void MakeOrderBy(ref StringBuilder sbCommand, OrderBy order, string FieldName) 
        {
            //Verifica se é uma ordenação crescente
            if (order.Equals(OrderBy.ASC)) 
            {
                //Adiciona ao comando o campo a ser ordenado
                sbCommand.Append(string.Format(" ORDER BY {0} ASC ", FieldName));

                //Interrompe a execução do metodo
                return;
            }

            //Verifica se é uma ordenação decrescente 
            if (order.Equals(OrderBy.DESC)) 
            {
                //Adiciona ao comando o campo a ser ordenado
                sbCommand.Append(string.Format(" ORDER BY {0} DESC ", FieldName));

                //Interrompe a execução do metodo
                return;
            }
        }
        #endregion

        #region Enum
        public enum SelectType 
        {
           All = 0,
           One  = 1
        }

        public enum OrderBy
        {
            None = 0,
            ASC = 1,
            DESC = 2
        }
        #endregion
    }
}