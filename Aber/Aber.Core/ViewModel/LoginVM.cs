using Aber.Core.Http;
using Aber.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Aber.Core.ViewModel
{
    public class LoginVM
    {
        APIService _api = new APIService();
        public async void Login(string name,string password)
        {
            Users user = await _api.Login(name, password);
            if (user != null)
            {
               
            }
            else
            {
                var dialog = new ContentDialog()
                {
                    Title = "提示",
                    Content = "登录失败",
                    PrimaryButtonText = "确定"
                };
                await dialog.ShowAsync();
            }
        }
    }
}
