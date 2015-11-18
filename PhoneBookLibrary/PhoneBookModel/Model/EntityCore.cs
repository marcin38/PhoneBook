using System;

namespace PhoneBookModel
{
    public abstract class EntityCore
    {
        public int Id { get; set; }
        public Nullable<System.DateTime> InsertDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
    }
}
