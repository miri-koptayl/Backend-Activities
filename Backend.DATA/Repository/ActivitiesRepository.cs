using Backend.CORE.entities;
using System.Collections.Generic;
using System.Linq;
using Backend.CORE.IRepositories;

namespace Backend.DATA.Repository
{
    public class ActivitiesRepository : IActivitiesRepository
    {
        private readonly DataContext _context;

        public ActivitiesRepository(DataContext context)
        {
            _context = context;
        }

        public List<Activities> GetActivities()
        {
            return _context.Activities.ToList();
        }

        public Activities? RegisterActivities(int ageGroupId, int pointsValue, string contentUrl, string type, string description, string title)
        {
            var activity = new Activities
            {
                AgeGroupId = ageGroupId,
                PointsValue = pointsValue,
                ContentUrl = contentUrl,
                Type = type,
                Description = description,
                Title = title,
                IsApproved = false // ברירת מחדל: טרם אושר
            };

            _context.Activities.Add(activity);
            _context.SaveChanges();
            return activity;
        }

        public Activities? UpdateActivities(int id, int ageGroupId, int pointsValue, string contentUrl, string type, string description, string title, bool isApproved)
        {
            var existing = _context.Activities.FirstOrDefault(a => a.Id == id);
            if (existing == null)
                return null;

            existing.AgeGroupId = ageGroupId;
            existing.PointsValue = pointsValue;
            existing.ContentUrl = contentUrl;
            existing.Type = type;
            existing.Description = description;
            existing.Title = title;
            existing.IsApproved = isApproved;

            _context.SaveChanges();
            return existing;
        }

        public Activities? RemoveActivities(int id)
        {
            var activity = _context.Activities.FirstOrDefault(a => a.Id == id);
            if (activity == null)
                return null;

            _context.Activities.Remove(activity);
            _context.SaveChanges();
            return activity;
        }
    }
}
