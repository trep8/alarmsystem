using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;

namespace DelegatesAndEvents
{
    class AlarmSystems
    {
        private SpeechSynthesizer alarmvoice = new SpeechSynthesizer();
        
        public void Speak(string msg, VoiceGender sex, int rate)
        {
            alarmvoice.SelectVoiceByHints(sex);
            alarmvoice.Rate = rate;            
            alarmvoice.SpeakAsync(msg);            
        }

        // event handlers (subscribers)
        public void OnExcessCO2lvl(object source)
        {           
            var tempobj = source as SmartBuilding;
            tempobj.setFan_speed(100);
            tempobj.CO2_warning_light = true;

            string msg = "Alarm!, Excess CO2 levels detected";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("{0}",msg);
            Console.WriteLine("Fan speed\t\t[{0}]", tempobj.getFan_speed());
            Console.WriteLine("CO2 warning light\t[{0}]", tempobj.CO2_warning_light);
            Console.ForegroundColor = ConsoleColor.White;
            Speak(msg, VoiceGender.Female,2);
        }   

        public void OnToxicFire(object source)
        {            
            var tempobj = source as SmartBuilding;
            tempobj.ventilation_system = false;
            tempobj.setFan_speed(0);
            tempobj.fire_alarm = true;

            string msg = "Alarm, Toxic Fire detected";
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("{0}", msg);         
            Console.WriteLine("Ventilation system\t[{0}]",tempobj.ventilation_system);
            Console.WriteLine("Fan speed\t\t[{0}]", tempobj.getFan_speed());
            Console.WriteLine("Fire Alarm\t\t[{0}]", tempobj.fire_alarm);
            Console.ForegroundColor = ConsoleColor.White;
            Speak(msg, VoiceGender.Female, 2);
        }

        public void OnNormalCO2lvl(object source)
        {            
            var tempobj = source as SmartBuilding;
            tempobj.setFan_speed(30);
            tempobj.fire_alarm = false;
            tempobj.CO2_warning_light = false;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Operating with normal parameters");
            Console.ForegroundColor = ConsoleColor.White;
            
        }
    }
}
