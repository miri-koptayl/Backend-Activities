using Backend.CORE.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.CORE.Iservices
{
    public interface IActivitiesService
    {
        List<Activities> GetActivities();
        Activities? RemoveActivities(int id);

        Activities? RegisterActivities(int AgeGroupId,
                    int PointsValue,
                    string ContentUrl,
                    string Type,
                    string Description,
                     string Title
                    );
        Activities? UpdateActivities(
             int id,
            int AgeGroupId,
                    int PointsValue,
                    string ContentUrl,
                    string Type,
                    string Description,
                     string Title,
                    bool IsApproved);
    }
}
