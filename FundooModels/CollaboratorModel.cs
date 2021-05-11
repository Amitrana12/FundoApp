// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CollaboratorModel.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Amit Rana"/>
// --------------------------------------------------------------------------------------------------------------------

namespace FundooModels
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    /// <summary>
    /// CollaboratorModel class
    /// </summary>
    public class CollaboratorModel
    {
        /// <summary>
        /// Gets or sets the CollaboratorId.
        /// </summary>
        /// <value>
        /// The CollaboratorId.
        /// </value>
        [Key]
        public int CollaboratorId { get; set; }

        /// <summary>
        /// Gets or sets the note identifier.
        /// </summary>
        /// <value>
        /// The note identifier.
        /// </value>
        [ForeignKey("NotesModel")]
        public int NoteId { get; set; }
        public virtual NotesModel NotesModel { get; set; }

        /// <summary>
        /// Gets or sets the SenderEmail.
        /// </summary>
        /// <value>
        /// The SenderEmail.
        /// </value>
        [RegularExpression(@"^[a-zA-Z0-9]{1,}([.]?[-]?[+]?[a-zA-Z0-9]{1,})?[@]{1}[a-zA-Z0-9]{1,}[.]{1}[a-z]{2,3}([.]?[a-z]{2})?$", ErrorMessage = "Invalid Email Id")]
        public string SenderEmail { get; set; }

        /// <summary>
        /// Gets or sets the ReceiverEmail.
        /// </summary>
        /// <value>
        /// The ReceiverEmail.
        /// </value>
        [RegularExpression(@"^[a-zA-Z0-9]{1,}([.]?[-]?[+]?[a-zA-Z0-9]{1,})?[@]{1}[a-zA-Z0-9]{1,}[.]{1}[a-z]{2,3}([.]?[a-z]{2})?$", ErrorMessage = "Invalid Email Id")]
        public string ReceiverEmail { get; set; }
    }
}
