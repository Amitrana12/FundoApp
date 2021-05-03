using FundooModels;
using FundooRepository.Context;
using FundooRepository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FundooRepository.Repository
{
    public class NotesRepository : INotesRepository
    {
        private UserContext userContext;
         private IConfiguration configuration;

        public NotesRepository(UserContext userContext, IConfiguration configuration) 
        {
            this.userContext = userContext;
            this.configuration = configuration;
        }

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


        public IEnumerable<NotesModel> RetrieveNotes()
        {
            try
            {
                IEnumerable<NotesModel> result;
                IEnumerable<NotesModel> notes = this.userContext.Note_model;
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

    }
}
