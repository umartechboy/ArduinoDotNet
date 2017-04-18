# ArduinoDotNet
ArduinoDotNet is a tiny interface built to control the Arduino directly from a.Net application.
The idea is NOT new and is NOT robust, but, it this kind of library was missing from observable web. 
# The Idea
An Arduino is integrated with the PC and controlled directly from the PC applications. Individual pins can also be read and written from the PC application. It is obvious that a specific ArduinoDotNet_Driver sketch resides on the Arduino which complements the pc interface. Other code can also go alongside this sketch but is not recommended. The PC application, after importing/using the ArdunioDotNet library, can access digitalWrite, analogueWrite, pinMode etc right from the dot net environment. These functions do the necessary communication with the Arduino to implement the same function within the Arduino and to return the values, if necessary. This way, we have digitalWrite, analogueWrite etc. functions within our C# (C Sharp), VB (Visual basic) or other .net languages.
# The Story 
Once, I had to work with an electronics legend who has spent his life designing, repairing and re-engineering cool electronics gadgets, precision instruments, military equipment, radios, televisions, legacy microcontrollers etc. He faces no problem creating a human machine interface using controllers like 8051, 8bit PIC and digital logic design. The only problem he seemed to face was that the world had changed so rapidly that interfacing an Arduino with SD card needed some learning. He had worked on .Net applications in Visual Basic and done all sorts of things like creating GUIs, saving data on the disc etc. 

Now, he had interface some sensors with an Arduino and log the data on an SD card. Instead of saving the data using Arduino on an SD card, he sends character commands via serial to an Arduino which implements the sensor routine and returns the data on serial which is eventually shown in a textbox on the computer screen. 
# Why so indirect?
This technique seems quite indirect but reduces the design complexity for most kinds of data acquisition application. I had this thing in mind for years but never considered worth spending time on. With this experience I realized that I should make an eloquent interface which integrates an Arduino with a PC seamlessly. It’s just like adding a parallel port to the PC. Not just a parallel port, but a full fledge microcontroller which has its own PWM generators, ADC, and many other peripherals.

# Using the Codes

 - Clone/Download the whole GIT from the button on the upper right corner of the main page.

 - Create/open a DotNet application, either in VB, C# or other dot net languages.

 - Depending upon the version of .Net Framework of your application (Visual Studio >> Project >> Properties >> Application), add reference to the appropriate ArduinoDotNetDNX_X.DLL to the project.

 - Import/use the namespace ArduinoDotNet. and create a global ArduinoDotNetInterface object.

 - Open the interface using the COM port name where the Arduino is connected.

 - use FlashFirmware method to flash the required driver on the Arduino. (This step is required only the first time an Arduino is prepared for interfacing. The driver can also be uploaded using the ArduinoDotNet_Driver.ino file under Arduino IDE)
 - Start using the functions like digitalRead, analogue read etc. under the ArduinoDotNetInterface object.

# Example


    ArduinoDotNet.ArduinoDotNetInterface arduino = new ArduinoDotNetInterface();
    arduino.Open();
    arduino.pinMode(2, true);
    arduino.pinMode(Pins.A0, 0); // only arduino Mega
    int i = arduino.analogRead(Pins.A0);
    if (i > 500)
    {
        MessageBox.Show("The Value is greater than 500");
        arduino.digitalWrite(2, true);
    }
    else
        arduino.digitalWrite(2, false);

    arduino.Close();

