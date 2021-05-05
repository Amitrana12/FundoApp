using FundooModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooRepository.Interface
{
    public interface INotesRepository
    {
        public bool AddNotes(NotesModel model);


        public IEnumerable<NotesModel> RetrieveNotes();


        public NotesModel RetrieveNotesById(int id);

        /// <summary>
        /// Removes the note.
        /// </summary>
        /// <param name="Id">note id</param>
        /// <returns>return true or false</returns>
        public bool RemoveNote(int Id);

        /// <summary>
        /// Updates the notes.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>string message</returns>
        public string UpdateNotes(NotesModel model);


        /// <summary>
        /// Pins the or unpin.
        /// </summary>
        /// <param name="id">note id</param>
        /// <returns>string message</returns>
        public string PinOrUnpin(int id);


        /// <summary>
        /// Archives the or unarchive.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>string message</returns>
        public string ArchieveOrUnarchieve(int id);

        /// <summary>
        /// Retrieves the archive notes.
        /// </summary>
        /// <returns>all archieve notes</returns>
        public IEnumerable<NotesModel> RetrieveArchieveNotes();

        /// <summary>
        /// Determines whether the specified identifier is trash.
        /// </summary>
        /// <param name="id">note id</param>
        /// <returns>string message</returns>
        public string IsTrash(int id);

        /// <summary>
        /// Retrieves the trash notes.
        /// </summary>
        /// <returns>all trash notes</returns>
        public IEnumerable<NotesModel> RetrieveTrashNotes();

        /// <summary>
        /// Empties the trash.
        /// </summary>
        /// <returns>return true or false</returns>
        public bool EmptyTrash();

        /// <summary>
        /// Adds the reminder.
        /// </summary>
        /// <param name="id">note id.</param>
        /// <param name="reminder">The reminder.</param>
        /// <returns>return true or false</returns>
        public bool AddReminder(int id, string reminder);

        /// <summary>
        /// Gets all notes whoes reminder is set.
        /// </summary>
        /// <returns>all notes whos reminder is set</returns>
        public IEnumerable<NotesModel> GetAllNotesWhoesReminderIsSet();

        /// <summary>
        /// Unset the reminder.
        /// </summary>
        /// <param name="id">note id</param>
        /// <returns>return true or false</returns>
        public bool UnSetReminder(int id);


    }
}
