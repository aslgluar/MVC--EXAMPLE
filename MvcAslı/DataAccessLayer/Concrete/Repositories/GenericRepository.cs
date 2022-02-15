using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concreate.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        Context c = new Context();

        DbSet<T> _object;//T degerine karsılık gelencsınıfı tutar

       
        //objeye değer ataması yapabılmek için t ye karsılık gelen sınıfı bilebilmek icin constructor oluşturmalıyız

        public GenericRepository()
        {
            using (Context c = new Context())
            {
                _object = c.Set<T>(); //oluşturduğum fields olan dbset teki _objecte deger atabilmek için constructor oluşturduk
            }
        }
           
        public void Delete(T p)
        {
            var deleteEntity = c.Entry(p);
            deleteEntity.State = EntityState.Deleted;
            //_object.Remove(p);
            c.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _object.SingleOrDefault(filter);
        }

        public List<T> list()
        {
            return _object.ToList();
        }

        public List<T> list(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public void Update(T p)
        {
            var updatedEntity = c.Entry(p);
            updatedEntity.State = EntityState.Modified;
            c.SaveChanges();
            c.Entry(p).State = EntityState.Modified;
        }

        public void İnsert(T p)
        {
            var adderEntity = c.Entry(p);
            adderEntity.State = EntityState.Added;
            //_object.Add(p);
            c.SaveChanges();
        }
    }

    ///CRUD İŞLEMLERİNİ DATA KATMANINDA YAPARAK İŞ KATMANINDA MANAGER SINIFLARINDA DOLDURACAĞIM
    ///METOTLARDA KULLANABİLMEMİ SAĞLIYOR YANİ SÜREKLİ SÜREKLİ OLUŞTURMAMIŞ OLUYORUM ORTAK BİR YAPI DİYELİM
    ///İŞ KATMANINDA BURDAKİ CRUD LAR SAYESİNDE İŞLERİMİ YAPABİLİCEM YANİ VERİYE ULAŞABİLİCEM
}