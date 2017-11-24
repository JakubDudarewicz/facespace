using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace Models.Models
{
     public class PostModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }
       
        [DataType(DataType.Date), Display(Name = "Creation Time"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreationTime { get; set; }
        public string Content { get; set; }

        public virtual UserModel User { get; set; }
        public virtual ICollection<CommentModel> Comments { get; set; }
    }
}