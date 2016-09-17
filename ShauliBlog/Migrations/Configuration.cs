namespace ShauliBlog.Migrations
{
    using Models;
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<ShauliBlog.Data.ShauliBlogDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ShauliBlog.Data.ShauliBlogDbContext context)
        {

            var comment = new Comment { Text = "Nice article", Title = "My Comment", Writer = "Maor Eini", WriterWebsite = "www.facebook.com" };
            var posts = new[]
{
                new Post {
                    Author ="Maor Eini",
                    AuthorWebsite ="www.ynet.co.il",
                    Image ="http://images1.ynet.co.il/PicServer4/2015/09/27/6460739/603184701002299183103no.jpg",
                    Comments = new[] { comment },
                    PublishDate = DateTime.Now,
                    Text="balblablbalbalbalbal",
                    Title="Titlllllleeeee",
                    Video="https://images-na.ssl-images-amazon.com/images/I/C1UnLxHAkNS.mp4"

                }
            };

            context.Comments.AddOrUpdate(comment);
            context.Posts.AddOrUpdate(posts);
            context.SaveChanges();

        }
    }
}
