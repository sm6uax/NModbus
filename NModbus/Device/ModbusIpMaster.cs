﻿using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace NModbus.Device
{

    /// <summary>
    ///    Modbus IP master device.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1706:ShortAcronymsShouldBeUppercase", Justification = "Breaking change.")]
    internal class ModbusIpMaster : ModbusMaster
    {
        /// <summary>
        ///     Modbus IP master device.
        /// </summary>
        /// <param name="transport">Transport used by this master.</param>
        public ModbusIpMaster(IModbusTransport transport)
            : base(transport)
        {
        }

        /// <summary>
        ///    Reads from 1 to 2000 contiguous coils status.
        /// </summary>
        /// <param name="startAddress">Address to begin reading.</param>
        /// <param name="numberOfPoints">Number of coils to read.</param>
        /// <param name="clientIdentifier"></param>
        /// <returns>Coils status.</returns>
        public bool[] ReadCoils(ushort startAddress, ushort numberOfPoints,string clientIdentifier)
        {
            return base.ReadCoils(Modbus.DefaultIpSlaveUnitId, startAddress, numberOfPoints,clientIdentifier);
        }

        /// <summary>
        ///    Asynchronously reads from 1 to 2000 contiguous coils status.
        /// </summary>
        /// <param name="startAddress">Address to begin reading.</param>
        /// <param name="numberOfPoints">Number of coils to read.</param>
        /// <param name="clientIdentifier"></param>
        /// <returns>A task that represents the asynchronous read operation.</returns>
        public Task<bool[]> ReadCoilsAsync(ushort startAddress, ushort numberOfPoints,string clientIdentifier)
        {
            return base.ReadCoilsAsync(Modbus.DefaultIpSlaveUnitId, startAddress, numberOfPoints,clientIdentifier);
        }

        /// <summary>
        ///    Reads from 1 to 2000 contiguous discrete input status.
        /// </summary>
        /// <param name="startAddress">Address to begin reading.</param>
        /// <param name="numberOfPoints">Number of discrete inputs to read.</param>
        /// <param name="clientIdentifier"></param>
        /// <returns>Discrete inputs status.</returns>
        public bool[] ReadInputs(ushort startAddress, ushort numberOfPoints,string clientIdentifier)
        {
            return base.ReadInputs(Modbus.DefaultIpSlaveUnitId, startAddress, numberOfPoints,clientIdentifier);
        }

        /// <summary>
        ///    Asynchronously reads from 1 to 2000 contiguous discrete input status.
        /// </summary>
        /// <param name="startAddress">Address to begin reading.</param>
        /// <param name="numberOfPoints">Number of discrete inputs to read.</param>
        /// <param name="clientIdentifier"></param>
        /// <returns>A task that represents the asynchronous read operation.</returns>
        public Task<bool[]> ReadInputsAsync(ushort startAddress, ushort numberOfPoints,string clientIdentifier)
        {
            return base.ReadInputsAsync(Modbus.DefaultIpSlaveUnitId, startAddress, numberOfPoints,clientIdentifier);
        }

        /// <summary>
        ///    Reads contiguous block of holding registers.
        /// </summary>
        /// <param name="startAddress">Address to begin reading.</param>
        /// <param name="numberOfPoints">Number of holding registers to read.</param>
        /// <param name="clientIdentifier"></param>
        /// <returns>Holding registers status.</returns>
        public ushort[] ReadHoldingRegisters(ushort startAddress, ushort numberOfPoints,string clientIdentifier)
        {
            return base.ReadHoldingRegisters(Modbus.DefaultIpSlaveUnitId, startAddress, numberOfPoints,clientIdentifier);
        }

        /// <summary>
        ///    Asynchronously reads contiguous block of holding registers.
        /// </summary>
        /// <param name="startAddress">Address to begin reading.</param>
        /// <param name="numberOfPoints">Number of holding registers to read.</param>
        /// <param name="clientIdentifier"></param>
        /// <returns>A task that represents the asynchronous read operation.</returns>
        public Task<ushort[]> ReadHoldingRegistersAsync(ushort startAddress, ushort numberOfPoints, string clientIdentifier)
        {
            return base.ReadHoldingRegistersAsync(Modbus.DefaultIpSlaveUnitId, startAddress, numberOfPoints,clientIdentifier);
        }

        /// <summary>
        ///    Reads contiguous block of input registers.
        /// </summary>
        /// <param name="startAddress">Address to begin reading.</param>
        /// <param name="numberOfPoints">Number of holding registers to read.</param>
        /// <param name="clientIdentifier"></param>
        /// <returns>Input registers status.</returns>
        public ushort[] ReadInputRegisters(ushort startAddress, ushort numberOfPoints, string clientIdentifier)
        {
            return base.ReadInputRegisters(Modbus.DefaultIpSlaveUnitId, startAddress, numberOfPoints,clientIdentifier);
        }

        /// <summary>
        ///    Asynchronously reads contiguous block of input registers.
        /// </summary>
        /// <param name="startAddress">Address to begin reading.</param>
        /// <param name="numberOfPoints">Number of holding registers to read.</param>
        /// <param name="clientIdentifier"></param>
        /// <returns>A task that represents the asynchronous read operation.</returns>
        public Task<ushort[]> ReadInputRegistersAsync(ushort startAddress, ushort numberOfPoints, string clientIdentifier)
        {
            return base.ReadInputRegistersAsync(Modbus.DefaultIpSlaveUnitId, startAddress, numberOfPoints,clientIdentifier);
        }

        /// <summary>
        ///    Writes a single coil value.
        /// </summary>
        /// <param name="coilAddress">Address to write value to.</param>
        /// <param name="value">Value to write.</param>
        /// <param name="clientIdentifier"></param>
        public void WriteSingleCoil(ushort coilAddress, bool value, string clientIdentifier)
        {
            base.WriteSingleCoil(Modbus.DefaultIpSlaveUnitId, coilAddress, value,clientIdentifier);
        }

        /// <summary>
        ///    Asynchronously writes a single coil value.
        /// </summary>
        /// <param name="coilAddress">Address to write value to.</param>
        /// <param name="value">Value to write.</param>
        /// <param name="clientIdentifier"></param>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        public Task WriteSingleCoilAsync(ushort coilAddress, bool value, string clientIdentifier)
        {
            return base.WriteSingleCoilAsync(Modbus.DefaultIpSlaveUnitId, coilAddress, value,clientIdentifier);
        }

        /// <summary>
        ///     Write a single holding register.
        /// </summary>
        /// <param name="registerAddress">Address to write.</param>
        /// <param name="value">Value to write.</param>
        /// <param name="clientIdentifier"></param>
        public void WriteSingleRegister(ushort registerAddress, ushort value, string clientIdentifier)
        {
            base.WriteSingleRegister(Modbus.DefaultIpSlaveUnitId, registerAddress, value,clientIdentifier);
        }

        /// <summary>
        ///    Asynchronously writes a single holding register.
        /// </summary>
        /// <param name="registerAddress">Address to write.</param>
        /// <param name="value">Value to write.</param>
        /// <param name="clientIdentifier"></param>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        public Task WriteSingleRegisterAsync(ushort registerAddress, ushort value, string clientIdentifier)
        {
            return base.WriteSingleRegisterAsync(Modbus.DefaultIpSlaveUnitId, registerAddress, value,clientIdentifier);
        }

        /// <summary>
        ///     Write a block of 1 to 123 contiguous registers.
        /// </summary>
        /// <param name="startAddress">Address to begin writing values.</param>
        /// <param name="data">Values to write.</param>
        /// <param name="clientIdentifier"></param>
        public void WriteMultipleRegisters(ushort startAddress, ushort[] data, string clientIdentifier)
        {
            base.WriteMultipleRegisters(Modbus.DefaultIpSlaveUnitId, startAddress, data,clientIdentifier);
        }

        /// <summary>
        ///    Asynchronously writes a block of 1 to 123 contiguous registers.
        /// </summary>
        /// <param name="startAddress">Address to begin writing values.</param>
        /// <param name="data">Values to write.</param>
        /// <param name="clientIdentifier"></param>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        public Task WriteMultipleRegistersAsync(ushort startAddress, ushort[] data, string clientIdentifier)
        {
            return base.WriteMultipleRegistersAsync(Modbus.DefaultIpSlaveUnitId, startAddress, data,clientIdentifier);
        }

        /// <summary>
        ///     Force each coil in a sequence of coils to a provided value.
        /// </summary>
        /// <param name="startAddress">Address to begin writing values.</param>
        /// <param name="data">Values to write.</param>
        /// <param name="clientIdentifier"></param>
        public void WriteMultipleCoils(ushort startAddress, bool[] data, string clientIdentifier)
        {
            base.WriteMultipleCoils(Modbus.DefaultIpSlaveUnitId, startAddress, data,clientIdentifier);
        }

        /// <summary>
        ///    Asynchronously writes a sequence of coils.
        /// </summary>
        /// <param name="startAddress">Address to begin writing values.</param>
        /// <param name="data">Values to write.</param>
        /// <param name="clientIdentifier"></param>
        /// <returns>A task that represents the asynchronous write operation</returns>
        public Task WriteMultipleCoilsAsync(ushort startAddress, bool[] data, string clientIdentifier)
        {
            return base.WriteMultipleCoilsAsync(Modbus.DefaultIpSlaveUnitId, startAddress, data,clientIdentifier);
        }

        /// <summary>
        ///     Performs a combination of one read operation and one write operation in a single MODBUS transaction.
        ///     The write operation is performed before the read.
        ///     Message uses default TCP slave id of 0.
        /// </summary>
        /// <param name="startReadAddress">Address to begin reading (Holding registers are addressed starting at 0).</param>
        /// <param name="numberOfPointsToRead">Number of registers to read.</param>
        /// <param name="startWriteAddress">Address to begin writing (Holding registers are addressed starting at 0).</param>
        /// <param name="writeData">Register values to write.</param>
        /// <param name="clientIdentifier"></param>
        public ushort[] ReadWriteMultipleRegisters(
            ushort startReadAddress,
            ushort numberOfPointsToRead,
            ushort startWriteAddress,
            ushort[] writeData,
            string clientIdentifier)
        {
            return base.ReadWriteMultipleRegisters(
                Modbus.DefaultIpSlaveUnitId,
                startReadAddress,
                numberOfPointsToRead,
                startWriteAddress,
                writeData,
                clientIdentifier);
        }

        /// <summary>
        ///    Asynchronously performs a combination of one read operation and one write operation in a single Modbus transaction.
        ///    The write operation is performed before the read.
        /// </summary>
        /// <param name="startReadAddress">Address to begin reading (Holding registers are addressed starting at 0).</param>
        /// <param name="numberOfPointsToRead">Number of registers to read.</param>
        /// <param name="startWriteAddress">Address to begin writing (Holding registers are addressed starting at 0).</param>
        /// <param name="writeData">Register values to write.</param>
        /// <param name="clientIdentifier"></param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public Task<ushort[]> ReadWriteMultipleRegistersAsync(
            ushort startReadAddress,
            ushort numberOfPointsToRead,
            ushort startWriteAddress,
            ushort[] writeData,
            string clientIdentifier)
        {
            return base.ReadWriteMultipleRegistersAsync(
                Modbus.DefaultIpSlaveUnitId,
                startReadAddress,
                numberOfPointsToRead,
                startWriteAddress,
                writeData,
                clientIdentifier);
        }
    }
}
