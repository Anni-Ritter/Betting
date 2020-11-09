using Betting.Data;
using Betting.Data.Models;
using System;

namespace Betting
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new BettingContext())
            {
                var user = new User();
                user.Name = "Sam";
                user.Balance = 0;
                user.Email = "Sam@gmail.com";
                user.Password = "123456789";
                context.Users.Add(user);

                context.SaveChanges();
            }
        }
    }
}
