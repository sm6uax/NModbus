using System;
using NModbus.Device;
using NModbus.IO;

namespace NModbus
{
    /// <summary>
    /// Extension methods for the IModbusFactory interface.
    /// </summary>
    public static class FactoryExtensions
    {
        /// <summary>
        /// Creates an RTU master.
        /// </summary>
        /// <param name="factory"></param>
        /// <param name="streamResource"></param>
        /// <param name="operationCb"></param>
        /// <returns></returns>
        public static IModbusSerialMaster CreateRtuMaster(this IModbusFactory factory, IStreamResource streamResource, Action<string,int,int> operationCb)
        {
            IModbusRtuTransport transport = factory.CreateRtuTransport(streamResource, operationCb);

            return new ModbusSerialMaster(transport);
        }

        /// <summary>
        /// Creates an ASCII master.
        /// </summary>
        /// <param name="factory"></param>
        /// <param name="streamResource"></param>
        /// <param name="operationCb"></param>
        /// <returns></returns>
        public static IModbusSerialMaster CreateAsciiMaster(this IModbusFactory factory, IStreamResource streamResource, Action<string,int,int> operationCb)
        {
            IModbusAsciiTransport transport = factory.CreateAsciiTransport(streamResource, operationCb);

            return new ModbusSerialMaster(transport);
        }

        /// <summary>
        /// Creates an RTU slave network.
        /// </summary>
        /// <param name="factory"></param>
        /// <param name="streamResource"></param>
        /// <param name="operationCb"></param>
        /// <returns></returns>
        public static IModbusSlaveNetwork CreateRtuSlaveNetwork(this IModbusFactory factory, IStreamResource streamResource, Action<string,int,int> operationCb)
        {
            IModbusRtuTransport transport = factory.CreateRtuTransport(streamResource, operationCb);

            return factory.CreateSlaveNetwork(transport, operationCb);
        }

        /// <summary>
        /// Creates an ASCII slave network.
        /// </summary>
        /// <param name="factory"></param>
        /// <param name="streamResource"></param>
        /// <param name="operationCb"></param>
        /// <returns></returns>
        public static IModbusSlaveNetwork CreateAsciiSlaveNetwork(this IModbusFactory factory, IStreamResource streamResource, Action<string,int,int> operationCb)
        {
            IModbusAsciiTransport transport = factory.CreateAsciiTransport(streamResource, operationCb);

            return factory.CreateSlaveNetwork(transport, operationCb);
        }
           
    }
}