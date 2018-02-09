using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementationFun
{
    //In this Example, we have implemented Kitchen Section and Bedroom section
    //This is to just implement OOPS concept for same, You can add more component later on
    
    #region KitchenSection
    public enum KitchenStyle
    {
        Indian, Chinees, Itelian
    }

    public interface IKitchen
    {
        KitchenStyle KitchenStyle { get; set; }
        int GetBuildupArea(int X, int Y);
    }

    public abstract class KitchenBase
    {
        public int Area { get; set; }
        public string ChimneyStyle { get; set; }
        public string CupboardStyle { get; set; }
        public string FloringStyle { get; set; }
    }

    public class NotmalKitchen : KitchenBase, IKitchen
    {
        public KitchenStyle KitchenStyle { get; set; }
        public int GetBuildupArea(int X, int Y)
        {
            this.Area = X * Y;
            return Area;
        }
    }

    public class ModularKitchen : KitchenBase, IKitchen
    {
        public KitchenStyle KitchenStyle { get; set; }
        public int GetBuildupArea(int X, int Y)
        {
            //Here 10 is salt for calculation. Which could be business logic
            this.Area = X * Y + 10;
            return Area;
        }
    }

    #endregion

    #region Bedroom
        public class Window
        {
            public int Height { get; set; }
            public int Width { get; set; }
            public string PanelStyle { get; set; }
            public string GlassStyle { get; set; }
            public int PositionX { get; set; }
            public int PositionY { get; set; }
            public Face WindowFace { get; set; }
        }
        public class Bathroom
        {
            public int Length { get; set; }
            public int Width { get; set; }
            //Add more property in need
        }
        public interface Ibedroom
        {
            int CalculateCarpetArea(int TotalArea, int OccupiedSpace);
        }
        public class Bedroom : Ibedroom
        {
            int Area;
            public int Leanth;
            public int Width;
            List<Window> Windows;
            List<Bathroom> Bathroom;

            public Bedroom()
            {
                //Default constructor with some default setting
                this.Leanth = 10;
                this.Width = 12;
            }

            public Bedroom(int Length, int Width)
            {
                this.Area = Length * Width;
            }

            public Bedroom SetWindow(List<Window> Windows)
            {
                this.Windows = Windows;
                return this;
            }

            public Bedroom SetBathroom(List<Bathroom> Bathroom)
            {
                this.Bathroom = Bathroom;
                return this;
            }

            public int CalculateCarpetArea(int TotalArea, int OccupiedSpace)
            {
                return TotalArea - OccupiedSpace;
            }
        }
    #endregion

    public enum Face
    {
        East,West,Noth,South
    }

    //The entire building may contain many appartments
    public class Appartment
    {
        IKitchen Kitchen;
        List<Bedroom> Bedrooms;
        public Appartment(IKitchen Kitchen , List<Bedroom> BedroomList)
        {
            this.Kitchen = Kitchen;
            this.Bedrooms = BedroomList;
        }
    }
}
