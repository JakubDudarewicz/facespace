using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class UserModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string Nick { get; set; }
        public string Mail { get; set; }

        public virtual ActivityModel Activity { get; set; }
        public virtual ICollection<PostModel> Posts { get; set; }
        public virtual ICollection<CommentModel> Comments { get; set; }
        public virtual ICollection<FriendModel> Friends { get; set; }
    }
}
