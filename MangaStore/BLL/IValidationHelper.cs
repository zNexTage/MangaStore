using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaStore.BLL
{
    interface IValidationHelper
    {
        /// <summary>
        /// Realiza a validação das propriedades de um objeto
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        string ValidateFields(object obj);

        /// <summary>
        /// Chama um metodo da DAO para realizar o cadastro
        /// </summary>
        /// <param name="obj"></param>
        void MakeInsert(object obj);

        /// <summary>
        /// Realiza a chamada de um metodo da dal para fazer o select
        /// </summary>
        /// <param name="id"></param>
        List<object> MakeSelect(object obj);
    }
}
