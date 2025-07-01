using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.CORE.Iservices;
using Backend.CORE.entities;

namespace Backend.CORE.IRepositories
{
    public interface IActivitiesRepository
    {
        List<Activities> GetActivities();
        Activities? RemoveActivities(int id);
        Activities? RegisterActivities(int AgeGroupId, int PointsValue, string ContentUrl, string Type, string Description, string Title);
        Activities? UpdateActivities(int id, int AgeGroupId, int PointsValue, string ContentUrl, string Type, string Description, string Title, bool IsApproved);
    }
}
