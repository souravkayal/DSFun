using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementationFun
{
    //In this implementation we will design configuration of mobile phone
    public enum PhoneMode
    {
        FlyingMode, NormalMode, SilentMode, LoudMode
    }
    public enum WarrentyType
    {
        Normal,Pro
    }


    public interface Ifunction
    {
        void On();
        void Off();
        void ChangeMode(PhoneMode Mode);
    }

    //We will assume that the phone has Display and Keypad component which is configurable
    #region Phone Display Setting
    public interface IScreen
    {
        void TurnOnDisplay();
    }

    public class LEDScreen : IScreen
    {
        public void TurnOnDisplay()
        {
            throw new NotImplementedException();
        }
    }

    public class LCDScreen : IScreen
    {
        public void TurnOnDisplay()
        {
            throw new NotImplementedException();
        }
    }
    #endregion

    #region Phone Keyboard Setting

    public interface IKeyboard
    {
        void OnT9Dictionary();
    }

    public class TouchKeyboard : IKeyboard
    {
        public void OnT9Dictionary(){ }
    }

    public class NormalKeyboard : IKeyboard
    {
        public void OnT9Dictionary() { }
    }

    #endregion

    public class PhoneConfiguration : Ifunction
    {
        //Private Member
        IScreen Screen;
        IKeyboard Keyboard;

        public string BrandName { get; set; }
        public double Price { get; set; }
        public WarrentyType WarrentyType { get; set; }

        //Constructor injection to set Screen and Keyboard
        public PhoneConfiguration(IScreen Screen, IKeyboard Keyboard)
        {
            this.Screen = Screen;
            this.Keyboard = Keyboard;
        }

        public IScreen GetScreen { get { return Screen; } }
        public IKeyboard GetKeyboard { get { return Keyboard; } }

        #region PhoneFunction
            public void On()
            {
                throw new NotImplementedException();
            }

            public void Off()
            {
                throw new NotImplementedException();
            }

            public void ChangeMode(PhoneMode Mode)
            {
                throw new NotImplementedException();
            }
        #endregion

    }
        
}
