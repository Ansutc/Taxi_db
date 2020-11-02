using System;
using System.Collections.Generic;

namespace Taxi_db.Model
{
    public partial class ДополнительныеУслуги
    {
        public long КодУслуги { get; set; }
        public string Наименование { get; set; }
        public string Описание { get; set; }
        public double Стоимость { get; set; }
    }
}
