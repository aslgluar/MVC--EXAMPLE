using EntityLayer.Concreate;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concreate
{
    //entitiy framework paketini indirmeliyiz

    public class Context:DbContext
    {
        /// app congig için geçerli alan burası
        /// app config içinde add name yanına yazacagımız isim
        /// tırnak içinde yazan isimdir
        public DbSet<About> Abouts/*sql deki oluşacak tablolarımın adlası s takılı olanları */{ get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Heading> Headings { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<ImageFile> ımageFiles { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Comment> Comments { get; set; }



    }
}
