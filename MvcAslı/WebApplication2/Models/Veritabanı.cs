

namespace WebApplication2.Models
{
    public static class Veritabanı
    {
        private static Dictionary<string, DavetiyeModel> _Liste;

        static Veritabanı()
        {
            _Liste = new Dictionary<string, DavetiyeModel>();

            _Liste.Add("aslı", new DavetiyeModel
            {
                Ad = "aslı",
                Eposta = "asligul444@gmail.com",
                KatilmaDurumu = true
            });

            _Liste.Add("esra", new DavetiyeModel
            {
                Ad = "esra",
                Eposta = "asligul444@gmail.com",
                KatilmaDurumu = true
            });

            _Liste.Add("sıla", new DavetiyeModel
            {
                Ad = "sıla",
                Eposta = "asligul444@gmail.com",
                KatilmaDurumu = true
            });

            _Liste.Add("oğuz", new DavetiyeModel
            {
                Ad = "oğuz",
                Eposta = "asligul444@gmail.com",
                KatilmaDurumu = true
            });

        }

        public static void Add(DavetiyeModel model)
        {
            string key =model.Ad.ToLower();
            if (_Liste.ContainsKey(key)){
                _Liste[key] = model;
            }
            else
            {
                _Liste.Add(key, model); 
            }
        }

        public static IEnumerable<DavetiyeModel> Liste
        {
            get { return _Liste.Values; }
        }
    }
}
