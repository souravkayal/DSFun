using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementationFun.BugTrackingSystem
{
    public abstract class ItemDescription
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal EstimatedDay { get; set; }
        public DateTime StartDate { get; set; }
        public User Owner { get; set; }

        public List<Bug> Bugs { get; set; }
    }

    public class Feature : ItemDescription
    {
        public List<Story> Storys { get; set; }
    }

    public class Story : ItemDescription
    {
        public List<Task> Tasks { get; set; }
    }

    public class Task: ItemDescription
    {

    }

    public class Bug
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public CurrentStatus CurrentStatus { get; set; }
        public User CreatedBy { get; set; }
        public User AssignTo { get; set; }
        public DateTime CreatedOn { get; set; }

    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public enum CurrentStatus
    {
        Open, DevTesting , QATesting, Closed
    }

    public class BugTrackerSystem
    {
        public List<Feature> Feature;

        public BugTrackerSystem()
        {
            this.Feature = new List<BugTrackingSystem.Feature>();
        }

        public List<Bug> GetBugInFeature(Func<Bug,bool> Where , string FeatureId)
        {
            return Feature.Where(f => f.Id == FeatureId).FirstOrDefault().Bugs;
        }
    }
}
