namespace iTransition.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using iTransition.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<iTransition.Models.iTransitionContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(iTransition.Models.iTransitionContext context)
        {
            context.Users.AddOrUpdate(x => x.Id,
            new User() { Id = 1, Name = "Evgen Shkelev", E_mail = "sorkoni@mail.ru", Password = "User1" },
            new User() { Id = 2, Name = "Evgen Rimashevski", E_mail = "try1@mail.ru", Password = "User2" },
            new User() { Id = 3, Name = "Ilya Vasilevich", E_mail = "try2@mail.ru", Password = "User3" }
            );

            context.Sites.AddOrUpdate(x => x.Id,
                new Site()
                {
                    Id = 1,
                    Title = "Pride and Prejudice",
                    Year = 1813,
                    UserId = 1,
                    Description = "Comedy of manners"
                },
                new Site()
                {
                    Id = 2,
                    Title = "Northanger Abbey",
                    Year = 1817,
                    UserId = 1,
                    Description = "Gothic parody"
                },
                new Site()
                {
                    Id = 3,
                    Title = "David Copperfield",
                    Year = 1850,
                    UserId = 2,
                    Description = "Bildungsroman"
                },
                new Site()
                {
                    Id = 4,
                    Title = "Don Quixote",
                    Year = 1617,
                    UserId = 3,
                    Description = "Picaresque"
                }
                );
        }
    }
}
