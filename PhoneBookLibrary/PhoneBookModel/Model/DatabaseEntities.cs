using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;

namespace PhoneBookModel
{
    public partial class DatabaseEntities : DbContext
    {
        public DatabaseEntities()
            : base("name=DatabaseEntities")
        {
            Database.SetInitializer<DatabaseEntities>(new DatabaseEntitiesInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PhoneBook>()
                .ToTable("PhoneBook")
                .Property(x => x.UserId)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute())
                );
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<PhoneBook> PhoneBooks { get; set; }
        public virtual DbSet<PhoneType> PhoneTypes { get; set; }
    }

    public class DatabaseEntitiesInitializer : CreateDatabaseIfNotExists<DatabaseEntities>
    {
        protected override void Seed(DatabaseEntities context)
        {
            context.PhoneTypes.Add(new PhoneType
            {
                Name = "Work",
                InsertDate = DateTime.Now
            });

            context.PhoneTypes.Add(new PhoneType
            {
                Name = "Cellphone",
                InsertDate = DateTime.Now
            });

            context.PhoneTypes.Add(new PhoneType
            {
                Name = "Home",
                InsertDate = DateTime.Now
            });

            context.SaveChanges();

            for (int i = 0; i < 10; i++)
            context.PhoneBooks.Add(new PhoneBook
            {
                FirstName = "First" + i.ToString(),
                LastName = "Last" + i.ToString(),
                Number = i.ToString(),
                PhoneTypeId = (i % 3) + 1,
                UserId = 1 + i/5,
                InsertDate = DateTime.Now
            });


            context.PhoneBooks.Add(new PhoneBook
            {
                FirstName = "Adam",
                LastName = "Kowalski",
                Number = "123456",
                PhoneTypeId = 1,
                UserId = 1,
                InsertDate = DateTime.Now
            });

            context.PhoneBooks.Add(new PhoneBook
            {
                FirstName = "Bartosz",
                LastName = "Z",
                Number = "123456",
                PhoneTypeId = 1,
                UserId = 1,
                InsertDate = DateTime.Now
            });


            context.PhoneBooks.Add(new PhoneBook
            {
                FirstName = "Zenon",
                LastName = "X",
                Number = "123456",
                PhoneTypeId = 1,
                UserId = 1,
                InsertDate = DateTime.Now
            });


            context.SaveChanges();
        }
    }
}
