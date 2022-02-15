using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreate
{
    public class Content
    {
        [Key]
        public int ContentID { get; set; }
        [StringLength(50)]
        public string ContentValue { get; set; }
        public DateTime ContentDate { get; set; }
        public bool ContentStatus { get; set; }


        public int HeadingID { get; set; }
        public virtual Heading Heading { get; set; }

        //soru işareti writer ıd boş olabilir demek,böyle olmazsa hata veriri birden fazla foreign key vs diye
        public int? WriterID { get; set; }//content tablomda bir yazar ıd ye ihtiyacım var çünkü içeriği hangi yazar yazmış bilmem lazım
        public virtual Writer Writer { get; set; }

    }
}
