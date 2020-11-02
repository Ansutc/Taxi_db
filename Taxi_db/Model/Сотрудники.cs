using System;
using System.Collections.Generic;

namespace Taxi_db.Model
{
    public partial class Сотрудники
    {
        public long КодСотрудника { get; set; }
        public string Фио { get; set; }
        public byte[] Возраст { get; set; }
        public string Пол { get; set; }
        public string Адрес { get; set; }
        public string Телефон { get; set; }
        public string ПаспортныеДанные { get; set; }
        public long КодАвтомобиля { get; set; }
        public long КодДолжности { get; set; }

        public virtual Автомобили КодАвтомобиляNavigation { get; set; }
        public virtual Должности КодДолжностиNavigation { get; set; }
    }
}
