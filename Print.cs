// Copyright (c) Bruker BioSpin AG. All Rights Reserved. E4 Software Team.

namespace TAP
{
    using System;
    using System.Collections.Generic;
    using Bruker.Synergy.Communication.I2c;
    using Bruker.Synergy.Hardware.Ftdi;

    public enum CommandByte
    {
        ConfigPort0 = 0x06,
        ConfigPort1 = 0x07,
        OutputPort1 = 0x03,
        OutputPort0 = 0x02,
        InputPort0 = 0x00,
        InputPort1 = 0x01,
    }

    public enum Segment
    {
        Led1 = 0x01,
        Led2 = 0x02,
        Led3 = 0x03,
        Led4 = 0x04,
        Led5 = 0x05,
        Led6 = 0x06,
        Led7 = 0x07,
        Led8 = 0x08,
        Led9 = 0x09
    }

    public enum Leds
    {
        Led1 = 0x10,
        Led2 = 0x20,
        Led3 = 0x40,
        Led4 = 0x80
    }

    public enum AdcCommands
    {
        GET_CH0 = 0X18,
        GET_CH2 = 0x48
    }

    public class Print
    {
        private II2cReadWrite _i2cInterface;
        private I2cConnectionSettings _i2cConnectionSettingIo;
        private I2cConnectionSettings _i2cConnectionSettingAdc;

        public Print()
        {
            var mpsseChannel = new MpsseChannelI2c("FT3LX971A");
            mpsseChannel.Connect();
            _i2cInterface = mpsseChannel as II2cReadWrite;
            _i2cConnectionSettingIo = new I2cConnectionSettings(0x20); // Adresse I/O Expander
            _i2cConnectionSettingAdc = new I2cConnectionSettings(0x28);  // Adresse ADC, Kraftsensor
            ConfigIoExpander();
        }

        public void SetAllLeds()
        {
            Dictionary<Buttons, Leds> lookup = new Dictionary<Buttons, Leds>()
            {
                { Buttons.S1, Leds.Led1 },
                { Buttons.S2, Leds.Led2 },
                { Buttons.S3, Leds.Led3 },
                { Buttons.S4, Leds.Led4 }
            };

            foreach (var i in lookup)
            {
                bool buttonValue = GetButton(i.Key);
                SetLed(i.Value, buttonValue);
            }
        }

        private void SetLed(Leds value, bool buttonValue)
        {
            uint newPortValue = 0;
            byte[] varIOexpander = new byte[2];
            varIOexpander = ReadIoExpander();
            uint actualPortValue = Convert.ToUInt32(varIOexpander[0]);

            if (buttonValue == false)
            {
                 newPortValue = actualPortValue | Convert.ToByte(value);
            }
            else
            {
                newPortValue = actualPortValue & (byte)(~Convert.ToByte(value));
            }

            WriteCommand(CommandByte.OutputPort1, Convert.ToByte(newPortValue));
        }

        private void ConfigIoExpander()
        {
            WriteCommand(CommandByte.ConfigPort1, 0x0F);
            WriteCommand(CommandByte.ConfigPort0, 0xF0);
            WriteCommand(CommandByte.OutputPort1, 0x0F);
        }

        public void Ausgabe7Segment(Segment led)
        {
            WriteCommand(CommandByte.OutputPort0, Convert.ToByte(Segment.Led8)); //Hier den Wert vom 7-Segment definieren
        }

        public enum Buttons
        {
            S1 = 0x01,
            S2 = 0x02,
            S3 = 0x04,
            S4 = 0x08
        }

        public bool GetButton(Buttons button)
        {
            byte[] zsReadButtonInput = new byte[2];
            zsReadButtonInput = ReadIoExpander();
            return Convert.ToBoolean(zsReadButtonInput[0] & Convert.ToByte(button));
        }

        public byte[] ReadAdc(AdcCommands adcCommands)
        {
              byte[] readAdcInput = ReadAdcCommand(AdcCommands.GET_CH0);
              return readAdcInput;
        }

        public byte[] ReadIoExpander()
        {
              byte[] readButtonInput = ReadIoCommand(CommandByte.InputPort1, 0x20);
              return readButtonInput;
        }

        private byte[] ReadIoCommand(CommandByte commandRead, int numbOfDataToRead)
        {
            return _i2cInterface.WriteRead(_i2cConnectionSettingIo, Convert.ToUInt32(numbOfDataToRead), new byte[] { Convert.ToByte(commandRead) });
        }

        private byte[] ReadAdcCommand(AdcCommands adcCommands)
        {
             return _i2cInterface.WriteRead(_i2cConnectionSettingAdc, 1, Convert.ToByte(adcCommands));
        }

        internal void WriteCommand(CommandByte command, params byte[] data)
        {
            List<byte> completeData = new List<byte>();
            completeData.Add(Convert.ToByte(command));
            completeData.InsertRange(completeData.Count, data);
            _i2cInterface.Write(_i2cConnectionSettingIo, completeData.ToArray());
        }
    }
}