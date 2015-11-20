using System;

namespace PhoneBookModel
{
    public abstract class EntityCore
    {
        public long Id { get; set; }
        public Nullable<System.DateTime> InsertDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
    }
}
