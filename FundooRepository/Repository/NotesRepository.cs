// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NotesRepository.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Amit Rana"/>
// --------------------------------------------------------------------------------------------------------------------

namespace FundooRepository.Repository
{
    using FundooModels;
    using FundooRepository.Context;
    using FundooRepository.Interface;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Http;
    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;

    /// <summary>
    /// NotesRepository class
    /// </summary>
    /// <seealso cref="FundooRepository.Interfaces.INotesRepository" />
    public class NotesRepository : INotesRepository
    {
        /// <summary>
        /// The user context
        /// </summary>
        private UserContext userContext;

        /// <summary>
        /// The user IConfiguration
        /// </summary>
        private IConfiguration configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotesRepository"/> class.
        /// </summary>
        /// <param name="userContext">The user context.</param>
        public NotesRepository(UserContext userContext, IConfiguration configuration)
        {
            this.userContext = userContext;
            this.configuration = configuration;
        }

        /// <summary>
        /// Adds the notes.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>return true or false</returns>
        public bool AddNotes(NotesModel model)
        {
            try
            {
                if (model != null)
                {
                    this.userContext.Note_model.Add(model);
                    var notes = this.userContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Retrieves the notes.
        /// </summary>
        /// <returns>all notes</returns>   
        public IEnumerable<NotesModel> RetrieveNotes(int userId)
        {
            try
            {
                IEnumerable<NotesModel> result;
                IEnumerable<NotesModel> notes = this.userContext.Note_model.Where(x=> x.UserId==userId);
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

        /// <summary>
        /// Retrieves the notes by identifier.
        /// </summary>
        /// <param name="id">note id.</param>
        /// <returns>specific note</returns>
        /// <exception cref="Exception"></exception>
        public NotesModel RetrieveNotesById(int noteId)
        {
            try
            {
                if (noteId > 0)
                {
                    NotesModel notes = this.userContext.Note_model.Where(x => x.NoteId == noteId).SingleOrDefault();
                    return notes;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Removes the note.
        /// </summary>
        /// <param name="Id">note id</param>
        /// <returns>return true or false</returns>
        public bool RemoveNote(int noteId)
        {
            try
            {
                if (noteId > 0)
                {
                    var notes = this.userContext.Note_model.Where(x => x.NoteId == noteId).SingleOrDefault();
                    if (notes != null)
                    {
                        if (notes.isTrash == true)
                        {
                            this.userContext.Note_model.Remove(notes);
                            this.userContext.SaveChangesAsync();
                            return true;
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Updates the notes.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>string message</returns>
        public string UpdateNotes(NotesModel model)
        {
            try
            {
                if (model.NoteId != 0)
                {
                    this.userContext.Entry(model).State = EntityState.Modified;
                    this.userContext.SaveChanges();
                    return "UPDATE SUCCESSFULL";
                }
                return "Updation Failed";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// PinOrUnpin the notes
        /// </summary>
        /// <param name="id">note id</param>
        /// <returns>string message</returns>
        public string PinOrUnpin(int noteId)
        {
            try
            {
                var notes = this.userContext.Note_model.Where(x => x.NoteId == noteId).SingleOrDefault();
                if (notes.Pin == false)
                {
                    notes.Pin = true;
                    userContext.Entry(notes).State = EntityState.Modified;
                    userContext.SaveChanges();
                    string message = "Note is getting pin";
                    return message;
                }
                if (notes.Pin == true)
                {
                    notes.Pin = false;
                    userContext.Entry(notes).State = EntityState.Modified;
                    userContext.SaveChanges();
                    string message = "Note Unpinned";
                    return message;
                }
                return "Unable to Pin or Unpin notes";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Archives the or unarchive.
        /// </summary>
        /// <param name="id">note id</param>
        /// <returns>string message</returns>
        /// <exception cref="Exception"></exception>
        public string ArchieveOrUnarchieve(int noteId)
        {
            try
            {
                var notes = this.userContext.Note_model.Where(x => x.NoteId == noteId).SingleOrDefault();
                if (notes.Archive == false)
                {
                    notes.Archive = true;
                    userContext.Entry(notes).State = EntityState.Modified;
                    userContext.SaveChanges();
                    string message = "Note is Archieve";
                    return message;
                }
                if (notes.Archive == true)
                {
                    notes.Archive = false;
                    userContext.Entry(notes).State = EntityState.Modified;
                    userContext.SaveChanges();
                    string message = "Note UnArchieve";
                    return message;
                }
                return "Unable to Archieve or UnArchieve notes";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Retrieves the archive notes.
        /// </summary>
        /// <returns>all notes i archive</returns>
        /// <exception cref="Exception"></exception>
        public IEnumerable<NotesModel> RetrieveArchieveNotes(int userId)
        {
            try
            {
                IEnumerable<NotesModel> result;
                IEnumerable<NotesModel> notes = this.userContext.Note_model.Where(x => x.Archive == true && x.UserId== userId).ToList();
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

        /// <summary>
        /// IsTrash 
        /// </summary>
        /// <param name="id">note id</param>
        /// <returns>string message</returns>
        public string IsTrash(int noteId)
        {
            try
            {
                var notes = this.userContext.Note_model.Where(x => x.NoteId == noteId).SingleOrDefault();
                if (notes.isTrash == false)
                {
                    notes.isTrash = true;
                    userContext.Entry(notes).State = EntityState.Modified;
                    userContext.SaveChanges();
                    string message = "Notes Is Trashed";
                    return message;
                }
                if (notes.isTrash == true)
                {
                    notes.isTrash = false;
                    userContext.Entry(notes).State = EntityState.Modified;
                    userContext.SaveChanges();
                    string message = "Note Restored";
                    return message;
                }

                return "Unable to Trash or Restored notes"; ;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Retrieves the trash notes.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public IEnumerable<NotesModel> RetrieveTrashNotes(int userId)
        {
            try
            {
                IEnumerable<NotesModel> result;
                IEnumerable<NotesModel> notes = this.userContext.Note_model.Where(x => x.isTrash == true && x.UserId == userId).ToList();
                if (notes != null)
                {
                    result = notes;
                }
                else
                {
                    result = null;
                }
                return result; ;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Empties the trash.
        /// </summary>
        /// <returns>return true or false</returns>
        /// <exception cref="Exception"></exception>
        public bool EmptyTrash()
        {
            try
            {
                IEnumerable<NotesModel> result = this.userContext.Note_model.Where(x => x.isTrash == true).ToList();
                if (result != null)
                {
                    foreach (var trash in result)
                    {
                        this.userContext.Note_model.Remove(trash);
                        this.userContext.SaveChangesAsync();
                    }

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
        /// Add the reminder.
        /// </summary>
        /// <param name="id">Note Id</param>
        /// <param name="reminder">The reminder.</param>
        /// <returns>return true or false</returns>
        /// <exception cref="Exception"></exception>
        public bool AddReminder(int noteId, string reminder)
        {
            try
            {
                var notes = this.userContext.Note_model.Where(x => x.NoteId == noteId).FirstOrDefault();
                if (notes != null)
                {
                    notes.Reminder = reminder;
                    userContext.Entry(notes).State = EntityState.Modified;
                    userContext.SaveChanges();
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
        /// Gets the reminder by identifier.
        /// </summary>
        /// <param name="id">note id</param>
        /// <returns>notes</returns>
        /// <exception cref="Exception"></exception>
        public IEnumerable<NotesModel> GetAllNotesWhoesReminderIsSet(int userId)
        {
            try
            {
                IEnumerable<NotesModel> result;
                IEnumerable<NotesModel> notes = this.userContext.Note_model.Where(x => x.Reminder.Length > 0 && x.UserId == userId);
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

        /// <summary>
        /// Uns the set reminder.
        /// </summary>
        /// <param name="id">note id</param>
        /// <returns>return true or false</returns>
        /// <exception cref="Exception"></exception>
        public bool UnSetReminder(int noteId)
        {
            try
            {
                var notes = this.userContext.Note_model.Where(x => x.NoteId == noteId).SingleOrDefault();
                if (notes != null)
                {
                    notes.Reminder = null;
                    userContext.Entry(notes).State = EntityState.Modified;
                    userContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool AddColour(int noteId, string color)
        {
            try
            {
                var notes = this.userContext.Note_model.Where(x => x.NoteId == noteId).SingleOrDefault();
                if (notes != null)
                {
                    notes.Colour = color;
                    userContext.Entry(notes).State = EntityState.Modified;
                    userContext.SaveChanges();
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
        /// Uploads the image.
        /// </summary>
        /// <param name="Noteimage">The noteimage.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>return true or false</returns>
        /// <exception cref="Exception"></exception>
        public bool UploadImage(int noteId, IFormFile noteimage)
        {
            try
            {
                var notes = this.userContext.Note_model.Where(x => x.NoteId == noteId).SingleOrDefault();
                if (notes != null)
                {
                    Account account = new Account
                    (
                        configuration["CloudinaryAccount:CloudName"],
                        configuration["CloudinaryAccount:ApiKey"],
                        configuration["CloudinaryAccount:ApiSecret"]
                    );
                    var path = noteimage.OpenReadStream();
                    Cloudinary cloudinary = new Cloudinary(account);
                    ImageUploadParams uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(noteimage.FileName, path)
                    };
                    var uploadResult = cloudinary.Upload(uploadParams);
                    notes.Image = uploadResult.Url.ToString();
                    userContext.Entry(notes).State = EntityState.Modified;
                    userContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
