using System.Collections.Generic;
using BookApp.Entities;

namespace BookApp.Mvc.Areas.Admin.Models
{
    public class UserListModel
    {
        public IList<User> Users { get; set; }
    }
}
