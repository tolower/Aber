using Aber.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;

namespace Aber.Core.Http
{
    public class APIService:APIBaseService
    {
        public async Task<Users> Login(string name,string password)
        {
            string body = "name=" + name + "&password=" + password + "&type=1";
            JsonObject json = await PostJson(APIUrl.LoginUrl,body);
            if (json != null)
            {
                var succeed = json["succeed"].GetNumber();
                if (succeed.Equals(1))
                {
                    var json_data = json["data"].GetObject();
                    var json_user = json_data["user"].GetObject();
                    Users user = new Users { UserID=json_user["user_id"].GetString(),UserName=json_user["user_name"].GetString()};
                    return user;
                }
                return null;
            }
            else
            {
                return null;
            }
        }
    }
}
