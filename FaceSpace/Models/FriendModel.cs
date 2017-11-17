using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    class FriendModel
    {
        [Key]
        public int RelationID { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }
        
        [ForeignKey("Friend")]
        public int FriendID { get; set; }

        public virtual UserModel User { get; set; }
        public virtual UserModel Friend { get; set; }
    }
}
