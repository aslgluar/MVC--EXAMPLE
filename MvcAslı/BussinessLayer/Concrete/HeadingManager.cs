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
    public class HeadingManager : IHeadingService
    {
        IHeadingDAL _headingDAL;

        public HeadingManager(IHeadingDAL headingDAL)
        {
            _headingDAL = headingDAL;
        }
        public void HeadingUpdate(Heading heading)
        {
            _headingDAL.Update(heading);
        }

        public Heading GetByID(int ID)
        {
            return _headingDAL.Get(x => x.HeadingID == ID);
        }

        public List<Heading> GetList()
        {
            return _headingDAL.list();
        }

        public void HeadingAdd(Heading heading)
        {
            _headingDAL.İnsert(heading);
        }

        public void HeadingDelete(Heading heading)
        {
            _headingDAL.Update(heading);
        }

        public List<Heading> GetListByWriter(int id)
        {
          return  _headingDAL.list(x => x.WriterID == id);
        }
    }
}
