// Copyright (c) Bruker BioSpin AG. All Rights Reserved. E4 Software Team.

namespace TAP
{
    using System;
    using System.Collections.Generic;
    using Bruker.Synergy.Communication.I2c;
    using Bruker.Synergy.Hardware.Ftdi;

    internal enum CommandByte
    {
        ConfigPort0 = 0x06,
        ConfigPort1 = 0x07,
        OutputPort1 = 0x03,
        OutputPort0 = 0x02,
        InputPort0 = 0x00,
        InputPort1 = 0x01
    }

    public class Print
    {
        private II2cReadWrite _i2cInterface;
        private I2cConnectionSettings _i2cConnectionSetting;

        public Print()
        {
            var mpsseChannel = new MpsseChannelI2c("FT3LX971A");
            mpsseChannel.Connect();
            _i2cInterface = mpsseChannel as II2cReadWrite;
            _i2cConnectionSetting = new I2cConnectionSettings(0x20);
            ConfigIoExpander();
            Console.WriteLine("marps erster push");
        }

        //public void SetLed()
        //{
        //    WriteCommand(CommandByte.OutputPort0, 0x0F);
        //}

        //public void ClearLed()
        //{
        //    WriteCommand(CommandByte.OutputPort0, 0x00);
        //}

        private void ConfigIoExpander()
        {
            WriteCommand(CommandByte.ConfigPort1, 0x0F);
            WriteCommand(CommandByte.ConfigPort0, 0xF0);
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

        public void Ausgabe7Segment(Segment led)
        {
            WriteCommand(CommandByte.OutputPort0, Convert.ToByte(Segment.Led2)); //Hier den Wert vom 7-Segment definieren
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

        public byte[] ReadIoExpander()
        {
            byte[] readButtonInput = ReadCommand(CommandByte.InputPort1, 0x20); //0x20 = Adresse vom I/OExpander
            return readButtonInput;
        }

        private byte[] ReadCommand(CommandByte commandRead, int numbOfDataToRead)
        {
            return _i2cInterface.WriteRead(_i2cConnectionSetting, Convert.ToUInt32(numbOfDataToRead), new byte[] { Convert.ToByte(commandRead)});
        }

        internal void WriteCommand(CommandByte command, params byte[] data)
        {
            List<byte> completeData = new List<byte>();
            completeData.Add(Convert.ToByte(command));
            completeData.InsertRange(completeData.Count, data);
            _i2cInterface.Write(_i2cConnectionSetting, completeData.ToArray());
        }
    }
}
