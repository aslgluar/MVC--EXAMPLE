using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Abstract
{
   public interface IAboutService
    {

        List<About> GetList();
        void AboutAdd(About about);
        About GetByID(int ID);
        void AboutDelete(About about);
        void AboutUpdate(About about);
    }
}
