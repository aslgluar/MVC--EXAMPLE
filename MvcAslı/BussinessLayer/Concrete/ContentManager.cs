using BussinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Concrete
{
   public class ContentManager : IContentService
    {
        IContentDAL _contentDAL;

        public ContentManager(IContentDAL contentDAL)
        {
            _contentDAL = contentDAL;
        }
        public void ContentAdd(Content content)
        {
            _contentDAL.İnsert(content);
        }

        public void ContentDelete(Content content)
        {
            _contentDAL.Delete(content);
        }

        public void ContentUpdate(Content content)
        {
            _contentDAL.Update(content);
        }

        public Content GetByID(int ID)
        {
            return _contentDAL.Get(x => x.ContentID == ID);
        }

        public List<Content> GetList()
        {
            return _contentDAL.list();
        }

        public List<Content> GetListByHeadingID(int id)
        {
            return _contentDAL.list(x => x.HeadingID == id);
        }

        public List<Content> GetListByWriter(int id)
        {
            return _contentDAL.list(x => x.WriterID == id);
        }
    }
}
