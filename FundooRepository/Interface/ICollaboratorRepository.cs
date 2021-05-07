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
    ///  ICollaboratorRepository interface
    /// </summary>
    public interface ICollaboratorRepository
    {
        /// <summary>
        /// Adds the collaborator.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>return true or false</returns>
        public bool AddCollaborator(CollaboratorModel model);

        /// <summary>
        /// Deletes the collaborator.
        /// </summary>
        /// <param name="id">collaborator id</param>
        /// <returns>return true or false</returns>
        public bool DeleteCollaborator(int collaboratorId);

        /// <summary>
        /// Gets the collaborator.
        /// </summary>
        /// <returns>collaborator</returns>
        public IEnumerable<CollaboratorModel> GetCollaborator();
    }
}
