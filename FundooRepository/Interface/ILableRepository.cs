// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ILableRepository.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Amit Rana"/>
// ---------------------------------------------------------------------------------------------------------

namespace FundooRepository.Interface
{
    using FundooModels;
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// ILableRepository interface 
    /// </summary>
    public interface ILableRepository
    {
        /// <summary>
        /// Adds the lable.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>return true or false</returns>
        public bool AddLable(LableModel model);

        /// <summary>
        /// Retrieves the notes.
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
        /// <returns>string message</returns>
        public string UpdateLables(LableModel model);

        /// <summary>
        /// Retrieves the lable by identifier.
        /// </summary>
        /// <param name="id">lable id.</param>
        /// <returns>particular lable</returns>
        public LableModel RetrieveLableById(int lableId);
    }
}
