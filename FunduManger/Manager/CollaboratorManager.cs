using FundooModels;
using FundooRepository.Interface;
using FunduManger.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace FunduManger.Manager
{
    public class CollaboratorManager : ICollaboratorManager
    {
        /// <summary>
        /// The repository
        /// </summary>
        private readonly ICollaboratorRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CollaboratorManager"/> class.
        /// </summary>
        /// <param name="userRepository">The user repository.</param>
        public CollaboratorManager(ICollaboratorRepository userRepository)
        {
            this.repository = userRepository;
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
                bool result = this.repository.AddCollaborator(model);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Deletes the collaborator.
        /// </summary>
        /// <param name="id">Collaborator id</param>
        /// <returns>return true or false</returns>
        /// <exception cref="Exception"></exception>
        public bool DeleteCollaborator(int collaboratorId)
        {
            try
            {
                bool result = this.repository.DeleteCollaborator(collaboratorId);
                return result;
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
        /// <exception cref="Exception">ex.message</exception>
        public IEnumerable<CollaboratorModel> GetCollaborator()
        {
            try
            {
                IEnumerable<CollaboratorModel> lables = this.repository.GetCollaborator();
                return lables;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
