using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FundooModels;
using FunduManger.Interface;

namespace FundoApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class NotesController : Controller
    {

        private readonly INotesManager notesManager;

        public NotesController(INotesManager notesManager)
        {
            this.notesManager = notesManager;
        }


        [HttpPost]
        [Route("addNotes")]
        public ActionResult AddNotes([FromBody] NotesModel model)
         {
             try
             {
                 bool result = this.notesManager.AddNotes(model);

                 if (result.Equals(true))
                 {
                     return this.Ok(new ResponseModel<NotesModel>() { Status = true, Message = "Notes Added Successfully",});
                 }

                 return this.BadRequest(new { Status = false, Message = "Failed to Add Notes" });
             }
             catch (Exception ex)
             {
                 return this.NotFound(new { Status = false, Message = ex.Message });
             }
         }

        [HttpGet]
        [Route("retrieveNotes")]
        public IActionResult RetrieveNotes()
        {
            try
            {
                IEnumerable<NotesModel> result = this.notesManager.RetrieveNotes();
                if (result != null)
                {
                    return this.Ok(new ResponseModel<IEnumerable<NotesModel>>() { Status = true, Message = "Retrieve Notes Successfully", Data = result });
                }

                return this.BadRequest(new { Status = false, Message = "Failed to Retrieve Notes" });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }



        [HttpGet]
        [Route("{noteId}")]
        public IActionResult RetrieveNotesById(int noteId)
        {
            try
            {
                NotesModel result = this.notesManager.RetrieveNotesById(noteId);
                if (result != null)
                {
                    return this.Ok(new ResponseModel<NotesModel>() { Status = true, Message = "Retrieve Notes By Id Successfully", Data = result });
                }

                return this.BadRequest(new { Status = false, Message = "Failed to Retrieve Notes By id" });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }
        /// <summary>
        /// DeleteNotes for delete specific notes
        /// </summary>
        /// <param name="id">notes id</param>
        /// <returns>response data</returns>
        [HttpDelete]
        [Route("{noteId}")]
        public IActionResult DeleteNotes(int noteId)
        {
            try
            {
                var result = this.notesManager.RemoveNote(noteId);
                if (result.Equals(true))
                {
                    return this.Ok(new ResponseModel<int>() { Status = true, Message = "Delete Note Successfully", Data = noteId });
                }

                return this.BadRequest(new { Status = false, Message = "Unable to delete note : Enter valid Id" });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// UpdateNotes for updating notes
        /// </summary>
        /// <param name="model">notes model</param>
        /// <returns>response data</returns>
        [HttpPut]
        [Route("updateNotes")]
        public IActionResult UpdateNotes([FromBody] NotesModel model)
        {
            try
            {
                var result = this.notesManager.UpdateNotes(model);
                if (result.Equals("UPDATE SUCCESSFULL"))
                {
                    return this.Ok(new ResponseModel<NotesModel>() { Status = true, Message = result, Data = model });
                }

                return this.BadRequest(new { Status = false, Message = "Error while updating notes" });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }

    }
}
