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

            if (id < 0)
            {
                //Recebe a lista com todos os idiomas
                listIdiomas = idiomaDAO.Select(id, DataBaseHelper.SelectType.All, DataBaseHelper.OrderBy.ASC);
            }
            else
            {
                //Recebe a lista com somente um idioma
                listIdiomas = idiomaDAO.Select(id, DataBaseHelper.SelectType.One, DataBaseHelper.OrderBy.ASC);
            }

            //Retorna a lista com os idiomas
            return listIdiomas;
        }

        public string ValidateFields(object obj)
        {
            throw new NotImplementedException();
        }
    }
}