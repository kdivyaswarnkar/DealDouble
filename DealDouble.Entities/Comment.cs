using System;


namespace DealDouble.Entities
{
    public class Comment : BaseEntity
    {
        public string Text { get; set; }
        public string UserID { get; set; }
        public DateTime TimeStamp { get; set; }
        public int EntityID { get; set; }
        public int RecordID { get; set; }
    }
}
