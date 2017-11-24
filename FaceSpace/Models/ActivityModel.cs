using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models///
{
    class ActivityModel
    {
        [Key, ForeignKey("User")]
        public int ID { get; set; }

        public int NumberOfPosts { get; set; }
        public int NumberOfComments { get; set; }

        public virtual UserModel User { get; set; }
    }
}
