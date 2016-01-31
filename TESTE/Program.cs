using System;
using SpaUserControl.Domain.Contracts.Repositories;
using SpaUserControl.Domain.Models;
using SpaUserControl.Infrastructure.Data;
using SpaUserControl.Infrastructure.Repositories;

namespace TESTE
{
    class Program
    {
        static void Main(string[] args)
        {
            User x;
            var user = new User("Rafael", "oi@oi.com");
            user.SetPassword("teste123!@", "teste123!@");
            user.Validate();

            using (IUserRepository repo = new UserRepository(new AppDataContext()))
            {

                repo.Create(user);
            }

            using (IUserRepository repo = new UserRepository(new AppDataContext()))
            {
                x = repo.Get("oi@oi.com");
                Console.WriteLine(x.Name);
            }





            Console.ReadKey();

            //using (IUserRepository repo = new UserRepository(new AppDataContext()))
            //{
            //    repo.Delete(x);
            //}
        }
    }
}
