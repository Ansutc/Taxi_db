using System;
using System.Collections.Generic;

namespace Taxi_db.Model
{
    public partial class Должности
    {
        public Должности()
        {
            Сотрудники = new HashSet<Сотрудники>();
        }

        public long КодДолжности { get; set; }
        public string Наименование { get; set; }
        public double Оклад { get; set; }
        public string Обязанности { get; set; }
        public string Требования { get; set; }

        public virtual ICollection<Сотрудники> Сотрудники { get; set; }
    }
}
