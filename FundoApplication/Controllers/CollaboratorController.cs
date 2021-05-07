// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CollaboratorController.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Amit Rana"/>
// --------------------------------------------------------------------------------------------------------------------


namespace FundoApplication.Controllers
{
    using FundooModels;
    using FunduManger.Interface;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// CollaboratorController class
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiController]
    [Route("api/[controller]")]
    public class CollaboratorController : ControllerBase
    {
        /// <summary>
        /// The collaborator manager
        /// </summary>
        private readonly ICollaboratorManager collaboratorManager;

        /// <summary>
        /// collaborator constructor <see cref="LableController"/> class.
        /// </summary>
        /// <param name="collaboratorManager">collaborator Manager.</param>
        public CollaboratorController(ICollaboratorManager collaboratorManager)
        {
            this.collaboratorManager = collaboratorManager;
        }

        /// <summary>
        /// Adds the collaborators.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>response body</returns>
        [HttpPost]
        [Route("addCollaborators")]
        public ActionResult AddCollaborators([FromBody] CollaboratorModel model)
        {
            try
            {
                bool result = this.collaboratorManager.AddCollaborator(model);
                if (result.Equals(true))
                {
                    return this.Ok(new ResponseModel<CollaboratorModel>() { Status = true, Message = "New Collaborator Added Sucessfully", Data = model });
                }

                return this.BadRequest(new { Status = false, Message = "Failed to Add Collaborator" });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Deletes the collaborator.
        /// </summary>
        /// <param name="id">collaborator id</param>
        /// <returns>response data</returns>
        [HttpDelete]
        [Route("collaboratorId")]
        public IActionResult DeleteCollaborator(int collaboratorId)
        {
            try
            {
                var result = this.collaboratorManager.DeleteCollaborator(collaboratorId);
                if (result.Equals(true))
                {
                    return this.Ok(new ResponseModel<int>() { Status = true, Message = "Collaborator Deleted Sucessfully", Data = collaboratorId });
                }

                return this.BadRequest(new { Status = false, Message = "Unable to delete collaborator : Enter valid Id" });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Retrieves all collaborator.
        /// </summary>
        /// <returns>response data</returns>
        [HttpGet]
        [Route("retrieveAllCollaborator")]
        public IActionResult RetrieveAllCollaborator()
        {
            try
            {
                IEnumerable<CollaboratorModel> result = this.collaboratorManager.GetCollaborator();
                if (result != null)
                {
                    return this.Ok(new ResponseModel<IEnumerable<CollaboratorModel>>() { Status = true, Message = "Retrieve Collaborator Successfully", Data = result });
                }

                return this.BadRequest(new { Status = false, Message = "Failed to Retrieve Collaborator" });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }
    }
}
