using System;
using System.Collections.Generic;

namespace Taxi_db.Model
{
    public partial class Вызовы
    {
        public byte[] Дата { get; set; }
        public byte[] Время { get; set; }
        public string Телефон { get; set; }
        public string Откуда { get; set; }
        public string Куда { get; set; }
        public long КодАвтомобиля { get; set; }
        public long КодСотрудника { get; set; }
        public long КодТарифа { get; set; }
        public long КодУслуги { get; set; }

        public virtual Автомобили КодАвтомобиляNavigation { get; set; }
        public virtual Сотрудники КодСотрудникаNavigation { get; set; }
        public virtual Тарифы КодТарифаNavigation { get; set; }
        public virtual ДополнительныеУслуги КодУслугиNavigation { get; set; }
    }
}
