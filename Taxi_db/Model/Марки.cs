using System;
using System.Collections.Generic;

namespace Taxi_db.Model
{
    public partial class Марки
    {
        public Марки()
        {
            Автомобили = new HashSet<Автомобили>();
        }

        public long КодМарки { get; set; }
        public string Наименование { get; set; }
        public string ТехническиеХарактеристики { get; set; }
        public double Стоимость { get; set; }
        public string Специфика { get; set; }

        public virtual ICollection<Автомобили> Автомобили { get; set; }
    }
}
