using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;

namespace touch_led
{
    public class Program
    {
        static OutputPort buzz = new OutputPort(Pins.GPIO_PIN_D4, false);
        static OutputPort led = new OutputPort(Pins.ONBOARD_LED, false);

        public static void Main()
        {
            InterruptPort button = new InterruptPort(Pins.GPIO_PIN_D6, true, Port.ResistorMode.Disabled, Port.InterruptMode.InterruptEdgeBoth);
            button.OnInterrupt += button_OnInterrupt;

            InterruptPort touch = new InterruptPort(Pins.GPIO_PIN_D2, true, Port.ResistorMode.Disabled, Port.InterruptMode.InterruptEdgeBoth);
            touch.OnInterrupt += touch_OnInterrupt;

            Thread.Sleep(Timeout.Infinite);
        }

        static void touch_OnInterrupt(uint data1, uint data2, DateTime time)
        {
            led.Write((data2 != 0));
        }

        static void button_OnInterrupt(uint data1, uint data2, DateTime time)
        {
            buzz.Write((data2 != 0));
        }

    }
}
