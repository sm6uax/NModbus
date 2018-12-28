namespace NModbus.Device
{
    public class PointEventArgs<T> : PointEventArgs where T : struct
    {
        private readonly T[] _points;
        private readonly ushort _functionCode;
        public PointEventArgs(ushort startAddress, T[] points, ushort functionCode) : base(startAddress, (ushort)points.Length,functionCode)
        {
            _points = points;
            _functionCode = functionCode;
        }

        public T[] Points => _points;
    }
}
