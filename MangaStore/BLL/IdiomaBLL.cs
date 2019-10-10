using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MangaStore.DAO;

namespace MangaStore.BLL
{
    public class IdiomaBLL : IValidationHelper
    {
        public void MakeInsert(object obj)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Realiza a chamada da IdiomaDAO para realizar um select
        /// </summary>
        /// <param name="id"></param>
        public List<object> MakeSelect(int id)
        {
            IdiomaDAO idiomaDAO = null;
            List<object> listIdiomas = null;

            //Instancia a dao de idiomas
            idiomaDAO = new IdiomaDAO();

            //Recebe a lista com os idiomas
            listIdiomas = idiomaDAO.Select(id, DataBaseHelper.SelectType.All);

            //Retorna a lista com os idiomas
            return listIdiomas;
        }

        public string ValidateFields(object obj)
        {
            throw new NotImplementedException();
        }
    }
}