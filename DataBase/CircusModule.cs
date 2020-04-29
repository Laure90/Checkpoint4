using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Nancy;
using Nancy.ModelBinding;
using System.Linq;
using Nancy.Hosting.Self;
using Newtonsoft.Json;
using System.ServiceModel;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Checkpoint4_App;
using System.Security.Cryptography;

namespace DataBase
{
    public class CircusModule : NancyModule
    {
        public CircusModule()
        {
            Get("/", _ => "Hello world");
            Get("/User", parameter => ReturnUserData());
            Get("/Show", parameter => ReturnShowData());
            Put("/User/{userName}/{Password}", parameters => PutNewUser(parameters.userName, parameters.Password));
        }

        public dynamic ReturnUserData()
        {
            using (var context = new CircusContext())
            {
                var user = from u in context.Users
                           select u;
                string jsonString;
                jsonString = System.Text.Json.JsonSerializer.Serialize(user);
                return jsonString;
            }
        }

        public dynamic PutNewUser(string name, string password)
        {  
            using (var context = new CircusContext())
            {
                var user = new User();
                user.Name = name;
                user.Password = password;
                user.StaffMember = false;
                context.Users.AddRange(user);
                context.SaveChanges();

                string jsonString;
                jsonString = System.Text.Json.JsonSerializer.Serialize("User added.");
                return jsonString;
            }
        }

        public dynamic ReturnShowData()
        {
            using (var context = new CircusContext())
            {
                var show = from s in context.Shows
                           select s;
                string jsonString;
                jsonString = System.Text.Json.JsonSerializer.Serialize(show);
                return jsonString;
            }
        }

        
    }
}
