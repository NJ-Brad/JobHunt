using LiteDB;

namespace JobHunt
{
    public class JobListingItem
    {
        [BsonId]
        //[BsonId(IdGenerator = typeof(ObjectIdGenerator))]
        //[BsonRepresentation(BsonType.String)]
        public string? JobId { get; set; } = Guid.NewGuid().ToString().Replace("-", "");
        //        Notification(s)
        public string? Company { get; set; }
        public string? LinkOne { get; set; }
        public string? LinkTwo { get; set; }
        public string? TrackingUrl { get; set; }
        public DateTime? Applied { get; set; }
        public DateTime? Viewed { get; set; }
        public DateTime? TheyContacted { get; set; }
        public DateTime? NoLongerAccepting { get; set; }
        public string? Status { get; set; } = "Looking";
        public string? Comment { get; set; }

        [BsonIgnore]
        public DateOnly? Applied_DO
        {
            get
            {
                return D_O(Applied);
            }
        }

        [BsonIgnore]
        public DateOnly? Viewed_DO
        {
            get
            {
                return D_O(Viewed);
            }
        }
        [BsonIgnore]
        public DateOnly? TheyContacted_DO
        {
            get
            {
                return D_O(TheyContacted);
            }
        }
        [BsonIgnore]
        public DateOnly? NoLongerAccepting_DO
        {
            get
            {
                return D_O(NoLongerAccepting);
            }
        }

        [BsonIgnore]
        private DateOnly? D_O(DateTime? date)
        {
            if (date.HasValue)
            {
                return new DateOnly(date.Value.Year, date.Value.Month, date.Value.Day);
            }
            return null;
        }

        // this is for Mongo
        public bool ShouldSerializeApplied_DO() { return false; }
        public bool ShouldSerializeViewed_DO() { return false; }
        public bool ShouldSerializeTheyContacted_DO() { return false; }
        public bool ShouldSerializeNoLongerAccepting_DO() { return false; }

        public void CopyTo(JobListingItem targetItem)
        {
            targetItem.JobId = JobId;
            targetItem.Company = Company;
            targetItem.LinkOne = LinkOne;
            targetItem.LinkTwo = LinkTwo;
            targetItem.Applied = Applied;
            targetItem.Viewed = Viewed;
            targetItem.TheyContacted = TheyContacted;
            targetItem.NoLongerAccepting = NoLongerAccepting;
            targetItem.Status = Status;
            targetItem.Comment = Comment;
        }
    }
}
