using EFRepository;
using EFRepository.Entities;
using EFRepository.Entities.Specification;
using System;

namespace TestApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (IUnitOfWork uow = new UnitOfWork(new Guid("5B479CE2-4BBC-4F9E-8539-6A6BC2DD099D")))
                {
                    User user = null;
                    UserProfile userProfile = null;

                    uow.CreateRepository<UserProfile>();
                    uow.CreateRepository<User>();

                    var userProfileRepository = uow.GetRepository<UserProfile>();
                    var userRepository = uow.GetRepository<User>();

                    //Create Profile
                    userProfile = new UserProfile();
                    userProfile.Name = "Developpers";
                    userProfile.Description = "Developpers Group";
                    var profileAdded = userProfileRepository.Insert(userProfile);

                    //Create User
                    user = new User();
                    user.UserName = "Leonel Vasconcelos";
                    user.Login = "gurdurix";
                    user.Password = "123456";
                    user.ProfileUser = profileAdded;
                    userRepository.Insert(user);
                    
                    uow.SaveChanges();
                    user = null;
                    userProfile = null;

                    //Get user information
                    user = userRepository.GetEntityBy(new FindEntitySpecification<User>(p=>p.Login.Equals("gurdurix")));
                    Console.WriteLine($"{user.Id} >> {user.Login} ({user.UserName})");

                    //var user = userRepository.GetEntityByPrimaryKey(new FindEntityByIdSpecification<User>(new Guid("97DD8E65-76F1-4C12-A0FA-D9D07032C81B")));
                    //uow.CreateRepository<UserProfile>();
                    //IRepository<UserProfile> userProfileRepository = uow.GetRepository<UserProfile>();
                    //userProfileRepository.Insert(new UserProfile(
                    //var users = uow.GetRepository<User>().GetAllEntities(
                    //    new FindEntitySpecification<User>(p => p.ProfileUser.ID.Equals(new Guid("E50C5924-B88B-44D7-B89A-1F30244A1817")))
                    //        .Not(new FindEntityByIdSpecification<User>(new Guid("D9579A46-1B9F-4C09-A02D-E4A6D4096E00"))));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
