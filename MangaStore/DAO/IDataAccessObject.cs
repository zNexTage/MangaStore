using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaStore.DAO
{
    public interface IDataAccessObject
    {
        /// <summary>
        /// Realiza um select 
        /// </summary>
        /// <param name="cod"></param>
        /// <returns></returns>
        List<object> Select(int cod, DataBaseHelper.SelectType selectType, DataBaseHelper.OrderBy orderBy);

        /// <summary>
        /// Realiza a inserção de dados
        /// </summary>
        /// <param name="obj"></param>
        void Insert(object obj);

        /// <summary>
        /// Realiza a atualização do dados
        /// </summary>
        /// <param name="cod"></param>
        /// <param name="obj"></param>
        void Update(int cod, object obj);

        /// <summary>
        /// Deleta os dados do banco de dados
        /// </summary>
        /// <param name="cod"></param>
        void Delete(int cod);
    }
}
