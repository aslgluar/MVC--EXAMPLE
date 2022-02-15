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
    public class WriterManager : IWriterService
    {
        IWriterDAL _writerDAL;

        public WriterManager(IWriterDAL writer)
        {
            _writerDAL = writer;

        }
        public Writer GetByID(int id)
        {
            return _writerDAL.Get(x => x.WriterID == id);
        }

        public List<Writer> GetList()
        {
            return _writerDAL.list();
        }

        public void WriterUpdate(Writer writer)
        {
            _writerDAL.Update(writer);
        }

        public void WriterAdd(Writer writer)
        {
             _writerDAL.İnsert(writer);
        }

        public void WriterDelete(Writer writer)
        {
            _writerDAL.Delete(writer);
        }
    }
}
