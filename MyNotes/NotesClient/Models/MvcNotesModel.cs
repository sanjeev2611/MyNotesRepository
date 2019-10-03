using System.ComponentModel.DataAnnotations;

namespace NotesClient.Models
{
    /// <summary>
    /// Notes Model
    /// </summary>
    public class MvcNotesModel
    {
        /// <summary>
        /// Identity Column
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets User Alias
        /// </summary>
        [Required]
        public int UserID { get; set; }

        /// <summary>
        /// Gets or sets Note Title
        /// </summary>        
        [StringLength(255, ErrorMessage = "The Title value cannot exceed 255 characters. ")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets Note Content
        /// </summary>
        [DataType(DataType.MultilineText)]
        [StringLength(1024, ErrorMessage = "The Content value cannot exceed 1024 characters. ")]
        public string Content { get; set; }
    }
}