using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DelegatesAndEvents
{
  
    class SmartBuilding
    {
        public delegate void AlarmEventHandler(object source);  // Delegate
        public event AlarmEventHandler ToxicFire;               // event
        public event AlarmEventHandler ExcessCO2lvl;            // event
        public event AlarmEventHandler NormalCO2lvl;            // event
        private int CO2_levels, fan_speed;
        
        // declaring members and get/set at the same time
        public float temp { get; set; }
        public bool ventilation_system { get; set; }
        public bool fire_alarm { get; set; }
        public bool CO2_warning_light { get; set; }

        
        public SmartBuilding()                  // Constructor
        {
            ventilation_system = true;
            fire_alarm = false;
            CO2_warning_light = false;
            fan_speed = 30;
        }

        #region Getters And Setters (custom)
        // getters n setters
        public void setFan_speed(int spd)
        {
            if (spd >= 0 && spd <= 100)
                this.fan_speed = spd;
            else
                this.fan_speed = 0;
        }
        public int getFan_speed()
        {
            return this.fan_speed;
        }       
        public void setCO2_levels(int co2lvl)
        {
            if (co2lvl >= 0)
                this.CO2_levels = co2lvl;
            else
                this.CO2_levels = 0;
        }
        public int getCO2_levels()
        {
            return this.CO2_levels;
        }
               
        #endregion

        // Events 
        protected virtual void OnToxicFire()    // event
        {
            if (ToxicFire != null)
                ToxicFire(this);           
        }

        protected virtual void OnExcessCO2lvl() // event
        {
            if (ExcessCO2lvl != null)
                ExcessCO2lvl(this);
        }

        protected virtual void OnNormalCO2lvl() // event
        {
            if (NormalCO2lvl != null)
                NormalCO2lvl(this);          
        }
        public virtual void RunSmartBuilding()               // virtual because inherited testclass has similar method
        {
            Console.WriteLine("Base Class Run method");
        }
    }
}
