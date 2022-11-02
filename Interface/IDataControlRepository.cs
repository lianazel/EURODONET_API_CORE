using API.Core.Framawork;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EuroDonetApi.Interface
{
    /// <summary>
    /// Interface for "DataControlRepository" (Inherited from "IRepository")
    /// </summary>

    public interface IDataControlRepository  : IRepository
    {

        #region Methods
        // > Controle d'une adresse <
        string ChkAdresse(string _Id_Key);


        // > Controle d'une société <
        string ChkSociete(string _Id_Key);


        #endregion


    }
}
