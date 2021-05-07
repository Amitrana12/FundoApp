// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CollaboratorRepository.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name=Amit Rana"/>
// --------------------------------------------------------------------------------------------------------------------


namespace FundooRepository.Repository
{
    using FundooModels;
    using FundooRepository.Context;
    using FundooRepository.Interface;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    public class CollaboratorRepository : ICollaboratorRepository
    {
        /// <summary>
        /// The user context
        /// </summary>
        private UserContext userContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="CollaboratorRepository"/> class.
        /// </summary>
        /// <param name="userContext">The user context.</param>
        public CollaboratorRepository(UserContext userContext)
        {
            this.userContext = userContext;
        }

        /// <summary>
        /// Adds the collaborator.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>return true or false</returns>
        /// <exception cref="Exception"></exception>
        public bool AddCollaborator(CollaboratorModel model)
        {
            try
            {
                if (model != null)
                {
                    this.userContext.Collaborator.Add(model);
                    this.userContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Deletes the collaborator.
        /// </summary>
        /// <param name="id">collaborator id</param>
        /// <returns>return true or false</returns>
        /// <exception cref="Exception"></exception>
        public bool DeleteCollaborator(int collaboratorId)
        {
            try
            {
                if (collaboratorId > 0)
                {
                    var collaborator = this.userContext.Collaborator.Where(x => x.CollaboratorId == collaboratorId).SingleOrDefault();
                    this.userContext.Collaborator.Remove(collaborator);
                    this.userContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Gets the collaborator.
        /// </summary>
        /// <returns>all collaborator</returns>
        /// <exception cref="Exception"></exception>
        public IEnumerable<CollaboratorModel> GetCollaborator()
        {
            try
            {
                IEnumerable<CollaboratorModel> result;
                IEnumerable<CollaboratorModel> notes = this.userContext.Collaborator;
                if (notes != null)
                {
                    result = notes;
                }
                else
                {
                    result = null;
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
