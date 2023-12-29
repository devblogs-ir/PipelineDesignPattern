using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipeLineDesignPattern
{
    public class UserController
    {
        private readonly HttpContext _context;

        public UserController(HttpContext context) 
        {
            _context = context;
        }

        public void GetUserById(int id)
        {
            var users = new List<string>();

            Console.WriteLine($"User {id} : {users[id]}");
        }
    }
}
