using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementationFun.TaskManager
{

    public abstract class Common
    {
        public int Id { get; set; }
    }

    public enum ThreadStatus
    {
        Running, Waiting, Suspended, Sleep
    }

    public class StackFrame : Common
    {
        public List<Object> LocalVariables { get; set; }
    }

    public class Thread : Common
    {
        public ThreadStatus ThreadStatus { get; set; }
        public Stack<StackFrame> Stack { get; set; }
    }

    public class Process : Common
    {
        public List<Thread> Threads { get; set; }
        public double MemoryUsed { get; set; }
        public DateTime StartAt { get; set; }
        public Int16 CPUConsumption { get; set; }
    }

    public interface ITask
    {
        void AddProcess(Process Item);
        void EndProcess();
        IEnumerable<Process> GetTopCpuBoundProcess(int TopCount);
    }

    public class TaskManager
    {
        List<Process> Processes;
        public TaskManager()
        {
            this.Processes = new List<Process>();
        }

        public void AddProcess(Process Item)
        {
            this.Processes.Add(Item);
        }
        public void EndProcess(int ProcessId)
        {
            this.Processes.Remove(Processes.Where(f => f.Id == ProcessId).FirstOrDefault());
        }

        public IEnumerable<Process> GetTopCpuBoundProcess(int TopCount)
        {
            return this.Processes.OrderBy(f => f.CPUConsumption).Take(TopCount);
        }

        public Process GetProcess(int Id)
        {
            return this.Processes.Where(f => f.Id == Id).FirstOrDefault();
        }
    }
    
}
