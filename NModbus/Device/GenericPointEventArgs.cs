namespace NModbus.Device
{
    public class PointEventArgs<T> : PointEventArgs where T : struct
    {
        private readonly T[] _points;
        private readonly ushort _functionCode;
        private readonly string _clientIdentifier;
        public PointEventArgs(ushort startAddress, T[] points, ushort functionCode,string clientIdentifier) : base(startAddress, (ushort)points.Length,functionCode,clientIdentifier)
        {
            _points = points;
            _functionCode = functionCode;
            _clientIdentifier = clientIdentifier;
        }

        public T[] Points => _points;
    }
}
