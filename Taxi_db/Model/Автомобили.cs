using System;
using System.Collections.Generic;

namespace Taxi_db.Model
{
    public partial class Автомобили
    {
        public Автомобили()
        {
            Сотрудники = new HashSet<Сотрудники>();
        }

        public long КодАвтомобиля { get; set; }
        public string РегистрационныйНомер { get; set; }
        public string НомерКузова { get; set; }
        public string НомерДвигателя { get; set; }
        public byte[] ГодВыпуска { get; set; }
        public double Пробег { get; set; }
        public byte[] ДатаПоследнегоТо { get; set; }
        public string СпециальныеОтметки { get; set; }
        public long КодМарки { get; set; }

        public virtual Марки КодМаркиNavigation { get; set; }
        public virtual ICollection<Сотрудники> Сотрудники { get; set; }
    }
}
