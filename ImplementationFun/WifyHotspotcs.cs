using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementationFun
{

    public interface IWifyActivity
    {
        void Connect(DeviceConnection DeviceConnection);
        void Disconnect(DeviceConnection DeviceConnection);
        List<DeviceConnection> GetAllDevices();
    }

    public class HotSpot 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public List<DeviceConnection> ConnectedDevice { get; set; }
    }
    

    public abstract class Device
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class PC : Device
    {
        public string SomePCProperty { get; set; }
    }
    public class Mobile : Device
    {
        public string SomePCProperty { get; set; }
    }
    
    public enum ConnectionStatus
    {
        Connected, Disconnected , Connecting
    }

    public class DeviceConnection
    {
        public string ConnectionId { get; set; }
        public Device Device { get; set; }
        public ConnectionStatus ConnectionStatus { get; set; }
        public DateTime ConnectedAt { get; set; }
    }


    public class Wify : IWifyActivity
    {
        HotSpot hotSpot;
        public Wify()
        {
            this.hotSpot = new HotSpot();
        }

        public void Connect(DeviceConnection DeviceConnection)
        {
            var Result = this.hotSpot.ConnectedDevice.Where(f => f.Device.Id == DeviceConnection.Device.Id).FirstOrDefault();
            if(Result == null)
            {
                this.hotSpot.ConnectedDevice.Add(DeviceConnection);
            }
        }

        public void Disconnect(DeviceConnection DeviceConnection)
        {
            this.hotSpot.ConnectedDevice.Remove(this.hotSpot.ConnectedDevice.Where(f => f.Device.Id == DeviceConnection.Device.Id).FirstOrDefault());
        }

        public List<DeviceConnection> GetAllDevices()
        {
            return this.hotSpot.ConnectedDevice;
        }
        
    }
}
