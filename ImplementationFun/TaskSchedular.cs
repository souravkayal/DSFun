using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskQueue = System.Collections.Generic.Queue<System.Threading.Tasks.Task>;

namespace ImplementationFun
{
    //Class design for simple task schedular, which will perform multiple tasks

    public interface Itask
    {
         Task Execute();
    }

    public class EmailTask : Itask
    {
        public async Task Execute()
        {
            Console.WriteLine("Email");
        }
    }

    public class SqlTask : Itask
    {
        public async Task Execute()
        {
            Console.WriteLine("Sql");
        }
    }

    public class FtpTask : Itask
    {
        public async Task Execute()
        {
            Console.WriteLine("FTP");
        }
    }




    public class TaskSchedular
    {
        //It could be priority Queue. based on demand
        Queue<Itask> TaskQueue = new Queue<Itask>();
        ConcurrentExclusiveSchedulerPair Scheduler = new ConcurrentExclusiveSchedulerPair();


        public void AddTask(Itask Task)
        {
            TaskQueue.Enqueue(Task);
        }

        public void TaskProcessor()
        {

            Task.Run(() => {

                while (TaskQueue.Count > 0)
                {
                   var item = TaskQueue.Dequeue();
                   item.Execute();
                }
            });
        }
    }
}
