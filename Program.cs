using System;
using System.Device.Gpio;

namespace RaspberryButtonLed
{
    class Program
    {
        static void Main(string[] args)
        {
            var controller = new GpioController();
            const int ledPin = 4;
            const int buttonPin = 18;
            try
            {
                Console.WriteLine("Start Button Leds!");
               
                controller.OpenPin(ledPin, PinMode.Output);
                controller.OpenPin(buttonPin, PinMode.Input);

                while (true)
                {
                    if (controller.Read(buttonPin) == PinValue.Low)
                    {
                        controller.Write(ledPin, PinValue.High);
                        Console.WriteLine("Led On");
                    }
                    else
                    {
                        controller.Write(ledPin, PinValue.Low);
                        Console.WriteLine("Led Off");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                controller.ClosePin(ledPin);
                controller.ClosePin(buttonPin);
            }               
        }
    }
}
