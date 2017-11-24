using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class CommentModel
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }
        [ForeignKey("Post")]
        public int PostID { get; set; }
       
        [DataType(DataType.Date), Display(Name = "Creation Time"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreationTime { get; set; } 
        public string Content { get; set; }

        public virtual UserModel User { get; set; }
        public virtual PostModel Post { get; set; }

    }
}
