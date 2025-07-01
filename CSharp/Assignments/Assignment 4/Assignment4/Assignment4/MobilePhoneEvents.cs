using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    class MobilePhoneEvents
    {
        
    public delegate void RingEventHandler();

    public class MobilePhone
    {
        
        public event RingEventHandler OnRing;

        
        public void ReceiveCall()
        {
            Console.WriteLine("Incoming call...");
            if (OnRing != null)
            {
                OnRing(); 
            }
        }
    }

    
    public class RingtonePlayer
    {
        public void PlayRingtone()
        {
            Console.WriteLine("Playing ringtone...");
        }
    }

    
    public class ScreenDisplay
    {
        public void ShowCallerInfo()
        {
            Console.WriteLine("Displaying caller information...");
        }
    }

    
    public class VibrationMotor
    {
        public void Vibrate()
        {
            Console.WriteLine("Phone is vibrating...");
        }
    }

    class Program
    {
        static void Main()
        {
            
            MobilePhone phone = new MobilePhone();
            RingtonePlayer ringtone = new RingtonePlayer();
            ScreenDisplay screen = new ScreenDisplay();
            VibrationMotor vibration = new VibrationMotor();

            
            phone.OnRing += ringtone.PlayRingtone;
            phone.OnRing += screen.ShowCallerInfo;
            phone.OnRing += vibration.Vibrate;

            
            phone.ReceiveCall();
                Console.Read();
        }
    }

}
}
