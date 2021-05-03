using FundooModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace FunduManger.Interface
{
    public interface INotesManager
    {
        public bool AddNotes(NotesModel model);


        public IEnumerable<NotesModel> RetrieveNotes();


        public NotesModel RetrieveNotesById(int noteId);

        /// <summary>
        /// Removes the note.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns>return true or false</returns>
        public bool RemoveNote(int noteId);

        /// <summary>
        /// Updates the notes.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>string message</returns>
        public string UpdateNotes(NotesModel model);



    }
}
