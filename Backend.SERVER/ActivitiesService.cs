using Backend.CORE.entities;
using Backend.CORE.IRepositories;
using Backend.CORE.Iservices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.SERVER
{
    public class ActivitiesService : IActivitiesService
    {
        private readonly IActivitiesRepository _ActivitiesRepository;

        public ActivitiesService(IActivitiesRepository activitiesRepository)
        {
            _ActivitiesRepository = activitiesRepository;
        }
        public List<Activities> GetActivities()
        {
            return _ActivitiesRepository.GetActivities();
        }


        public Activities? RegisterActivities(int AgeGroupId, int PointsValue, string ContentUrl, string Type, string Description, string Title)
        {
            var activity = new Activities
            {
                AgeGroupId = AgeGroupId,
                PointsValue = PointsValue,
                ContentUrl = ContentUrl,
                Type = Type,
                Description = Description,
                Title = Title,
                IsApproved = false
            };

            return _ActivitiesRepository.RegisterActivities(AgeGroupId, PointsValue, ContentUrl, Type, Description, Title);
        }



        public Activities? RemoveActivities(int id)
        {
          return  _ActivitiesRepository.RemoveActivities(id);
        }

        public Activities? UpdateActivities(int id, int AgeGroupId, int PointsValue, string ContentUrl, string Type, string Description, string Title, bool IsApproved)
        {
            return _ActivitiesRepository.UpdateActivities(
                id,
                AgeGroupId,
                PointsValue, 
                ContentUrl,
                Type, 
                Description,
                Title, 
                IsApproved);
        }
    }
}

