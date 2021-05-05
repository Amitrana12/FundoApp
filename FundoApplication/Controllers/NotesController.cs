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
    public class NotesController : Controller
    {

        private readonly INotesManager notesManager;

        public NotesController(INotesManager notesManager)
        {
            this.notesManager = notesManager;
        }


        [HttpPost]
        [Route("addNotes")]
        public ActionResult AddNotes(NotesModel model)
         {
             try
             {
                 bool result = this.notesManager.AddNotes(model);

                 if (result.Equals(true))
                 {
                     return this.Ok(new ResponseModel<NotesModel>() { Status = true, Message = "Notes Added Successfully", Data = model });
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
        [Route(" RetrieveNotes{noteId}")]
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
        ///  delete specific notes
        /// </summary>
        /// <param name="id">notes id</param>
        /// <returns>response data</returns>
        [HttpDelete]
        [Route("DeleteNote{noteId}")]
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
        ///  updating notes
        /// </summary>
        /// <param name="model">notes model</param>
        /// <returns>response data</returns>
        [HttpPut]
        [Route("updateNotes")]
        public IActionResult UpdateNotes( NotesModel model)
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

        /// <summary>
        /// Retrieves the notes by pin.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>response data</returns>
        [HttpPut]
        [Route("pinOrUnpin")]
        public IActionResult PinOrUnpinNote(int noteId)
        {
            try
            {
                var result = this.notesManager.PinOrUnpin(noteId);
                if (result != null)
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result, Data = result });
                }

                return this.BadRequest(new { Status = false, Message = result });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Archive  or unarchive.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>response data</returns>
        [HttpPut]
        [Route("archieveOrUnarchieve")]
        public IActionResult ArchieveOrUnarchieve(int noteId)
        {
            try
            {
                var result = this.notesManager.ArchieveOrUnArchieve(noteId);
                if (result != null)
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result, Data = result });
                }

                return this.BadRequest(new { Status = false, Message = result });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }


        /// <summary>
        /// Retrieve All Archive Notes 
        /// </summary>
        /// <returns>response body</returns>
        [HttpGet]
        [Route("retrieveAllArchieveNotes")]
        public IActionResult RetrieveAllArchieveNotes()
        {
            try
            {
                IEnumerable<NotesModel> result = this.notesManager.RetrieveArchieveNotes();
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


        /// <summary>
        /// Trash  or untrash.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>response data</returns>
        [HttpPut]
        [Route("trashOrUntrash")]
        public IActionResult TrashOrUntrash(int noteId)
        {
            try
            {
                var result = this.notesManager.isTrash(noteId);
                if (result != null)
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result, Data = result });
                }

                return this.BadRequest(new { Status = false, Message = result });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Retrieve All Trash Notes 
        /// </summary>
        /// <returns>response data</returns>
        [HttpGet]
        [Route("retrieveAllTrashNotes")]
        public IActionResult RetrieveAllTrashNotes()
        {
            try
            {
                IEnumerable<NotesModel> result = this.notesManager.RetrieveTrashNotes();
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

        /// <summary>
        /// Empty the trash.
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        [Route("emptyTrash")]
        public IActionResult EmptyTrash()
        {
            try
            {
                var result = this.notesManager.EmptyTrash();
                if (result.Equals(true))
                {
                    return this.Ok(new ResponseModel<bool>() { Status = true, Message = "All Trashed Note Deleted Successfully", Data = result });
                }

                return this.BadRequest(new { Status = false, Message = "Unable to delete Trash note : Something went wrong" });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Set the reminder.
        /// </summary>
        /// <param name="id">note id.</param>
        /// <param name="reminder">The reminder.</param>
        /// <returns>response data</returns>
        [HttpPut]
        [Route("setReminder")]
        public IActionResult SetReminder(int noteId, string reminder)
        {
            try
            {
                var result = this.notesManager.AddReminder(noteId, reminder);
                if (result.Equals(true))
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Reminder Set Successfully", Data = reminder });
                }

                return this.BadRequest(new { Status = false, Message = result });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Get all notes whose reminder is set.
        /// </summary>
        /// <returns>Response data</returns>
        [HttpGet]
        [Route("getAllNotesWhoseReminderIsSet")]
        public IActionResult GetAllNotesWhoseReminderIsSet()
        {
            try
            {
                IEnumerable<NotesModel> result = this.notesManager.GetAllNotesWhoesReminderIsSet();
                if (result != null)
                {
                    return this.Ok(new ResponseModel<IEnumerable<NotesModel>>() { Status = true, Message = "Retrieve All Notes Whose Reminder Is Set", Data = result });
                }

                return this.BadRequest(new { Status = false, Message = "Failed to Retrieve Notes" });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Unset the set reminder.
        /// </summary>
        /// <param name="id">note id</param>
        /// <returns>response data</returns>
        [HttpPut]
        [Route("unSetReminder")]
        public IActionResult UnSetReminder(int noteId)
        {
            try
            {
                var result = this.notesManager.UnsetReminder(noteId);
                if (result.Equals(true))
                {
                    return this.Ok(new ResponseModel<int>() { Status = true, Message = "Unset Reminder For Note Sucessfully", Data = noteId });
                }

                return this.BadRequest(new { Status = false, Message = result });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }

    }
}
