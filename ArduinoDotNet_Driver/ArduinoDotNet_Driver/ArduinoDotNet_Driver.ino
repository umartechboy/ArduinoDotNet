/*
Name:		ArduinoSharp_driver.ino
Created:	4/17/2017 5:42:55 PM
Author:	umar.hassan
*/

// the setup function runs once when you press reset or power the board
void setup()
{
	Serial.begin(115200);
}

// the loop function runs over and over again until power down or reset
void loop()
{
	if (!Serial.available()) return;
	uint8_t b = Serial.read();
	while (true)
	{
		if (b != 0xAA)
			return;
		while (!Serial.available());
		b = Serial.read();
		if (b == 0x55) break;
		if (b == 0xAA) continue;
	}
	while (Serial.available() < 2);
	uint8_t buf[4];
	Serial.readBytes(buf, 2);
	if (buf[0] == 'D' && buf[1] == 'W')
	{
		while (Serial.available() < 2);
		Serial.readBytes(buf, 2);
		digitalWrite(buf[0], buf[1]);
	}
	else if (buf[0] == 'A' && buf[1] == 'W')
	{
		while (Serial.available() < 3);
		Serial.readBytes(buf, 3);
		analogWrite(buf[0], buf[1] + (buf[1] << 8));
	}
	else if (buf[0] == 'P' && buf[1] == 'M')
	{
		while (Serial.available() < 2);
		Serial.readBytes(buf, 2);
		pinMode(buf[0], buf[1]);
	}
	else if (buf[0] == 'D' && buf[1] == 'R')
	{
		while (Serial.available() < 1);
		Serial.readBytes(buf, 1);
		Serial.write((uint8_t)digitalRead(buf[0]));
	}
	else if (buf[0] == 'A' && buf[1] == 'R')
	{
		while (Serial.available() < 1);
		Serial.readBytes(buf, 1);
		int aread = analogRead(buf[0]);
		Serial.write((uint8_t)aread % 0xFF);
		Serial.write((uint8_t)(aread >> 8) % 0xFF);
	}
	else if (buf[0] == 'V' && buf[1] == 'D')
	{
		Serial.print((uint8_t)'U');
	}
	else
	{
		Serial.print("Unknown command: ");
		Serial.print(buf[0]);
		Serial.print(", ");
		Serial.println(buf[1]);
	}
}
