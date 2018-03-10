using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementationFun
{
    public enum PerfRating
    {
        Average, Good, VeryGood, Excellent
    }

    public enum Class
    {
        X, XI, XII, Graduation, Master
    }

    public static class FeesMapper
    {
        static Dictionary<Class, int> Fees = new Dictionary<Class, int>();
        static FeesMapper()
        {
            Fees.Add(Class.X, 1000);
            Fees.Add(Class.XI, 1500);
            Fees.Add(Class.XII, 2000);
            Fees.Add(Class.Graduation, 2500);
            Fees.Add(Class.Master, 3000);
        }
        public static int GetFees(Class StudentClass)
        {
            return Fees[StudentClass];
        }
    }

    public enum Days
    {
        Sum, Mon, Tues, Wed, Thr, Fri, Sat
    }

    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Class Class { get; set; }
        public PerfRating Rating { get; set; }
        public bool IsActive { get; set; }
    }

    public class Batch
    {
        public int Id { get; set; }
        public string BatchName { get; set; }
        public List<Student> Students { get; set; }
        public DateTime StartedOn { get; set; }
        public List<Days> Days { get; set; }
        public bool IsDismissed { get; set; }
        public decimal Timeing { get; set; } //Timing in 24 clock , Example : 13.30 
    }

    public class StudentFees
    {
        public int Id { get; set; }
        public Student Student { get; set; }
        public DateTime PaidOn { get; set; }
        public int Amount { get; set; }
    }


    public class BatchCollectionViewModel
    {
        public int Id { get; set; }
        public int BatchId { get; set; }
        public string BatchName { get; set; }
        public int TotalCollection { get; set; }
        public int StudentCount { get; set; }
        public int PercentPaid { get; set; }
    }

    public class StudentAttendence
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int BatchId { get; set; }
        public DateTime DateOnAt { get; set; }
    }


    public class TutionFessManager
    {
        List<Batch> Batches;
        List<StudentFees> Fees;
        List<StudentAttendence> AttendenceBook;

        public TutionFessManager()
        {
            this.Batches = new List<Batch>();
            this.Fees = new List<StudentFees>();
            this.AttendenceBook = new List<StudentAttendence>();
        }

        public void AddBatch(Batch Item)
        {
            this.Batches.Add(Item);
        }

        public void RemoveBatch(int BatchId)
        {
            this.Batches.Remove(this.Batches.Where(f => f.Id == BatchId).First());
        }
        
        public void AddStudent(Student Student, int BatchId)
        {
            var item = this.Batches.Where(f => f.Id == BatchId).First();
            item.Students.Add(Student);
        }

        public void RemoveStudent( int StudentId , int BatchId) 
        {
            var item = this.Batches.Where(f => f.Id == BatchId).First();
            item.Students.Remove(item.Students.Where(f => f.Id == StudentId).First());
        }

        public void GiveFees(StudentFees Item)
        {
            this.Fees.Add(Item);
        }

        public List<Batch> FindBatchDetail(Func<Batch,bool> where)
        {
            return this.Batches.Where(where).ToList();
        }

        public BatchCollectionViewModel GetTotalCollectionByBatch(int BatchId , DateTime FromDate , DateTime ToDate)
        {
            var Batch = this.Batches.Where(f => f.Id == BatchId).First();
            var Students = Batch.Students;
            var StartDate = Batch.StartedOn;
            int TotalAmount = 0;
            int ExpectedAmount = 0;

            foreach (var item in Students)
            {
                ExpectedAmount += FeesMapper.GetFees(item.Class);
                var fees = this.Fees.Where(f => f.Student.Id == item.Id && f.Student.IsActive == true && ( f.PaidOn > FromDate && f.PaidOn < ToDate)).Sum(f => f.Amount);
                TotalAmount += fees;
            }

            return new BatchCollectionViewModel { BatchId = BatchId, BatchName = Batch.BatchName, StudentCount = Batch.Students.Count(), TotalCollection = TotalAmount , PercentPaid = (TotalAmount/ExpectedAmount) *100 };
        }

        public StudentAttendence GetattendenceByBatch(int BatchId, DateTime Date)
        {
            return this.AttendenceBook.Where(f => f.BatchId == BatchId && f.DateOnAt == Date).FirstOrDefault();
        }



    }
}
