using FundooModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace FunduManger.Interface
{
    public interface ILableManager
    {
        /// <summary>
        /// Adds the lable.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>return true or false</returns>
        public bool AddLable(LableModel model);

        /// <summary>
        /// Retrieves the lables.
        /// </summary>
        /// <returns>all lables</returns>
        public IEnumerable<LableModel> RetrieveLables();

        /// <summary>
        /// Removes the lable.
        /// </summary>
        /// <param name="id">lable id</param>
        /// <returns>return true or false</returns>
        public bool RemoveLable(int lableId);

        /// <summary>
        /// Updates the lables.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>String message</returns>
        public string UpdateLables(LableModel model);

        /// <summary>
        /// Retrieves the lable by identifier.
        /// </summary>
        /// <param name="id">lable id</param>
        /// <returns>String message</returns>
        public LableModel RetrieveLableById(int lableId);
    }
}
