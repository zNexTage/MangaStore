using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MangaStore.Util
{
    public class Parameters
    {
        public string Key;
        public object Value;
        public SqlDbType dbType; 

        #region Construtor

        /// <summary>
        /// Cria um novo parametro
        /// </summary>
        /// <param name="Key"></param>
        /// <param name="Value"></param>
        public Parameters(string Key, object Value, SqlDbType sqlDb)
        {
            this.Key = Key;
            this.Value = Value;
            this.dbType = sqlDb;
        }

        #endregion
    }
}