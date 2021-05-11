// --------------------------------------------------------------------------------------------------------------------
// <copyright file="INotesManager.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Amit Rana"/>
// --------------------------------------------------------------------------------------------------------------------

namespace FunduManger.Interface
{
    using System.Collections.Generic;
    using FundooModels;
    using Microsoft.AspNetCore.Http;

    /// <summary>
    ///  interface INotesManager
    /// </summary>
    public interface INotesManager
    {
        /// <summary>
        /// Adds the notes.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>return true or false</returns>
        public bool AddNotes(NotesModel model);

        /// <summary>
        /// Retrieves the notes.
        /// </summary>
        /// <returns>all notes</returns>
        public IEnumerable<NotesModel> RetrieveNotes(int userId);

        /// <summary>
        /// Retrieves the notes by identifier.
        /// </summary>
        /// <param name="noteId">note id</param>
        /// <returns>particular note</returns>
        public NotesModel RetrieveNotesById(int noteId);

        /// <summary>
        /// Removes the note.
        /// </summary>
        /// <param name="noteId">The identifier.</param>
        /// <returns>return true or false</returns>
        public bool RemoveNote(int noteId);

        /// <summary>
        /// Updates the notes.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>string message</returns>
        public string UpdateNotes(NotesModel model);

        /// <summary>
        /// Pins the or unpin.
        /// </summary>
        /// <param name="noteId">note id</param>
        /// <returns>String message</returns>
        public string PinOrUnpin(int noteId);

        /// <summary>
        /// Archives the or un archive.
        /// </summary>
        /// <param name="noteId">note id</param>
        /// <returns>String message</returns>
        public string ArchieveOrUnArchieve(int noteId);

        /// <summary>
        /// Retrieves the archive notes.
        /// </summary>
        /// <returns>data in list </returns>
        public IEnumerable<NotesModel> RetrieveArchieveNotes(int userId);

        /// <summary>
        /// Determines whether the specified identifier is trash.
        /// </summary>
        /// <param name="noteId">note id</param>
        /// <returns>String message</returns>
        public string isTrash(int noteId);

        /// <summary>
        /// Empties the trash.
        /// </summary>
        /// <returns>return true or false</returns>
        public bool EmptyTrash();

        /// <summary>
        /// Retrieves the trash notes.
        /// </summary>
        /// <returns>all trash notes</returns>
        public IEnumerable<NotesModel> RetrieveTrashNotes(int userId);

        /// <summary>
        /// Adds the reminder.
        /// </summary>
        /// <param name="noteId">note id</param>
        /// <param name="reminder">The reminder.</param>
        /// <returns>return true or false</returns>
        public bool AddReminder(int noteId, string reminder);

        /// <summary>
        /// Gets all notes who's reminder is set.
        /// </summary>
        /// <returns>all notes whose reminder is set</returns>
        public IEnumerable<NotesModel> GetAllNotesWhoesReminderIsSet(int userId);

        /// <summary>
        /// Unsets the reminder.
        /// </summary>
        /// <param name="noteId">note id</param>
        /// <returns>return true or false</returns>
        public bool UnsetReminder(int noteId);

        /// <summary>
        /// Add the color.
        /// </summary>
        /// <param name="id">note id</param>
        /// <param name="color">The color.</param>
        /// <returns>return true or false</returns>
        public bool AddColor(int noteId, string color);

        /// <summary>
        /// Uploads the image.
        /// </summary>
        /// <param name="noteimage">The noteimage.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>return true or false</returns>
        public bool UploadImage(int noteId, IFormFile noteimage);
    }
}
