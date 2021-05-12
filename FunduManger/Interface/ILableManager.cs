// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ILableManager.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Amit Rana"/>
// --------------------------------------------------------------------------------------------------------------------

namespace FunduManger.Interface
{
    using FundooModels;
    using System.Collections.Generic;

    /// <summary>
    /// INotesManager interface
    /// </summary>
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
        public IEnumerable<LableModel> RetrieveLables(int userId);

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
        public IEnumerable<LableModel> RetrieveLableById(int noteId);
    }
}
