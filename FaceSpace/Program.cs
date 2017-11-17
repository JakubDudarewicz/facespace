using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FaceSpace
{
    public class Program
    {
        static void Main(string[] args)
        {

            using (var ctx = new ContextModel())
            {
                UserModel user = new UserModel() { Nick = "New User" };

                ctx.Users.Add(user);
                ctx.SaveChanges();
            }
        }
    }
}