using BussinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concreate.Repositories;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDAL _categoryDAL;//field oluşturduk ve deger ataması yapabilmek için constructor oluşturmalıyım  
                                  //bu işi generic repo ile de yapabilirdik ama olabildiğince bağımlılıkları ortadan kaldırmaya çalışıyoruuz,
                                  //business tarafında newlemekten kaçınmak için

        public CategoryManager(ICategoryDAL categoryDAL)
        {
            _categoryDAL = categoryDAL;
        }

        public void categoryAddBL(Category category)
        {
            _categoryDAL.İnsert(category);
        }

        public void categoryDelete(Category category)
        {
            _categoryDAL.Delete(category);
           
        }

        public void categoryUpdate(Category category)
        {
            _categoryDAL.Update(category);
        }

        public Category GetById(int id)
        {
            return _categoryDAL.Get(x => x.CategoryID == id);
        }

        public List<Category> GetList()
        {
            return _categoryDAL.list();
        }
    }
}
