using BussinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Concrete
{
    public class ImageManager : IImageServices
    {
        IImageFileDAL _ımageFileDal;

        public ImageManager(IImageFileDAL ımageFileDAL)
        {
             _ımageFileDal = ımageFileDAL;
        }
        public List<ImageFile> GetList()
        {
            return _ımageFileDal.list();        
        }
    }
}
