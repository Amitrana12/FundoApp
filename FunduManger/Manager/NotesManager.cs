using FundooModels;
using FundooRepository.Interface;
using FunduManger.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace FunduManger.Manager
{
   public class NotesManager : INotesManager
    {
        private readonly INotesRepository repository;

        public NotesManager(INotesRepository userRepository)
        {
            this.repository = userRepository;
        }

        public bool AddNotes(NotesModel model)
        {
            try
            {
                bool result = this.repository.AddNotes(model);
                return result;
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
                IEnumerable<NotesModel> notes = this.repository.RetrieveNotes();
                return notes;
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
                NotesModel notes = this.repository.RetrieveNotesById(noteId);
                return notes;
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
                bool result = this.repository.RemoveNote(noteId);
                return result;
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
                string result = this.repository.UpdateNotes(model);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
