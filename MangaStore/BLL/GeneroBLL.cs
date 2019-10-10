using MangaStore.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MangaStore.BLL
{
    public class GeneroBLL : IValidationHelper
    {
        public void MakeInsert(object obj)
        {
            throw new NotImplementedException();
        }

        public List<object> MakeSelect(int id)
        {
            List<object> listGenero = null;
            GeneroDAO generoDAO = null;

            //Cria um novo objeto
            generoDAO = new GeneroDAO();

            if(id < 0) 
            {
                //Realiza um select de todos os dados
                listGenero = generoDAO.Select(id, DataBaseHelper.SelectType.All, DataBaseHelper.OrderBy.ASC);
            }
            else
            {
                //Realiza um select de um dado
                listGenero = generoDAO.Select(id, DataBaseHelper.SelectType.One, DataBaseHelper.OrderBy.ASC);
            }

            //Retorna a lista com os generos
            return listGenero;
        }

        public string ValidateFields(object obj)
        {
            throw new NotImplementedException();
        }
    }
}