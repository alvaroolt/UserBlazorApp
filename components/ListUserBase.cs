//using Microsoft.AspNetCore.Components;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using UserBlazorApp.Services;
//using WebServiceApiRest.Models;

//namespace UserBlazorApp.components
//{
//    public class ListUserBase:ComponentBase
//    {
//        [Inject]
//        public IServiceUser ServiceUser { get; set; }
//        public IEnumerable<User> Users { get; set; }
//        public IEnumerable<User> SelectedUsers { get; set; }

//        [Parameter]
//        public int Id { get; set; }
//        protected override async Task OnInitializedAsync()
//        {
//            if (Id == 0)
//            {
//                Users = (await ServiceUser.DameUsers()).ToList();
//            } else
//            {
//                Users = (await ServiceUser.DameUser(Id)).ToList();
//            }
//        }
//    }
//}
