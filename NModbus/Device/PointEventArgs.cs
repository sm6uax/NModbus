using System;


namespace NModbus.Device
{
    /// <summary>
    /// Modbus Slave request event args containing information on the message.
    /// </summary>
    public class PointEventArgs : EventArgs
    {
        private ushort _numberOfPoints;

        private ushort _startAddress;

        private ushort _functionCode;

        private string _clientIdentifier;

        public PointEventArgs(ushort startAddress, ushort numberOfPoints, ushort FunctionCode,string clientIdentifier)
        {
            _startAddress = startAddress;
            _numberOfPoints = numberOfPoints;
            _functionCode = FunctionCode;
            _clientIdentifier = clientIdentifier;
        }

        public ushort NumberOfPoints => _numberOfPoints;
        public ushort FunctionCode => _functionCode;
        public ushort StartAddress => _startAddress;
        public string ClientIdentifier => _clientIdentifier;
    }
}
