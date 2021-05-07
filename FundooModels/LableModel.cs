// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LableModel.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Amit Rana"/>
// --------------------------------------------------------------------------------------------------------------------


namespace FundooModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;

    /// <summary>
    /// LableModel class
    /// </summary>
    public class LableModel
    {
        /// <summary>
        /// Gets or sets the lable identifier.
        /// </summary>
        /// <value>
        /// The lable identifier.
        /// </value>
        [Key]
        public int LableId { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        [ForeignKey("RegisterModel")]
        public int UserId { get; set; }
        public virtual RegisterModel RegisterModel { get; set; }

        /// <summary>
        /// Gets or sets the note identifier.
        /// </summary>
        /// <value>
        /// The note identifier.
        /// </value>
         [ForeignKey("NotesModel")]
        public int? NoteId { get; set; }
        public virtual NotesModel NotesModel { get; set; }

        /// <summary>
        /// Gets or sets the lable.
        /// </summary>
        /// <value>
        /// The lable.
        /// </value>
        public string Lable { get; set; }
    }
}
