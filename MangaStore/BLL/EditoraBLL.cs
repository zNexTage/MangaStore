using MangaStore.DAO;
using System;
using System.Collections.Generic;

namespace MangaStore.BLL
{
    public class EditoraBLL : IValidationHelper
    {
        public object EditoraDAO { get; private set; }

        public void MakeInsert(object obj)
        {
            throw new NotImplementedException();
        }

        public List<object> MakeSelect(int id)
        {
            List<object> listEditora = null;
            EditoraDAO editoraDAO = null;

            //Instancia a dao de editoras
            editoraDAO = new EditoraDAO();

            //Se foi fornecido um ID
            if (id < 0) 
            {
                //Retorna todas as editoras
                listEditora =  editoraDAO.Select(id, DataBaseHelper.SelectType.All, DataBaseHelper.OrderBy.ASC);
            }
            else
            {
                //Retorna somente uma editora
                listEditora = editoraDAO.Select(id, DataBaseHelper.SelectType.One, DataBaseHelper.OrderBy.ASC);
            }

            //Retorna a lista com as editoras
            return listEditora;
        }

        public string ValidateFields(object obj)
        {
            throw new NotImplementedException();
        }
    }
}