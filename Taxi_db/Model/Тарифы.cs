using System;
using System.Collections.Generic;

namespace Taxi_db.Model
{
    public partial class Тарифы
    {
        public long КодТарифа { get; set; }
        public string Наименование { get; set; }
        public string Описание { get; set; }
        public double Стоимость { get; set; }
    }
}
