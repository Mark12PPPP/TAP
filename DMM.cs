using Bruker.Synergy.Devices.DAQ;

namespace TAP
{
    class Dmm
    {
        private DaqKeysight34972A _dmm;

        public Dmm()
        {
            _dmm = new DaqKeysight34972A("TCPIP::<IP-Adresse einfügen>::INSTR");
        }
    }
}
