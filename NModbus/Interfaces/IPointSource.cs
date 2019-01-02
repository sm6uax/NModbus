namespace NModbus
{
    /// <summary>
    /// Represents a memory map.
    /// </summary>
    /// <typeparam name="TPoint"></typeparam>
    public interface IPointSource<TPoint>
    {
        /// <summary>
        /// Read a series of points.
        /// </summary>
        /// <param name="startAddress"></param>
        /// <param name="numberOfPoints"></param>
        /// <param name="functionCode"></param>
        /// <param name="clientIdentifier"></param>

        /// <returns></returns>
        TPoint[] ReadPoints(ushort startAddress, ushort numberOfPoints,ushort functionCode,string clientIdentifier);

        /// <summary>
        /// Write a series of points.
        /// </summary>
        /// <param name="startAddress"></param>
        /// <param name="points"></param>
        /// <param name="functionCode"></param>
        /// <param name="clientIdentifier"></param>

        void WritePoints(ushort startAddress, TPoint[] points, ushort functionCode, string clientIdentifier);
    }
}