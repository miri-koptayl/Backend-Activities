using System;

namespace Backend.CORE.entities
{
    public class Activities
    {
        // קונסטרקטור ריק שחיוני ל-EF Core
        public Activities() { }

        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Type { get; set; }
        public string? ContentUrl { get; set; }
        public int PointsValue { get; set; }
        public int AgeGroupId { get; set; }
        public bool IsApproved { get; set; } = false;
        public int? ApprovedBy { get; set; }
    }
}
