using System;
using System.Collections.Generic;
using NModbus.Device.MessageHandlers;
using System.Linq;
using System.Net.Sockets;
using NModbus.Extensions;
using NModbus.Data;
using NModbus.Device;
using NModbus.IO;
using NModbus.Logging;

namespace NModbus
{
    public class ModbusFactory : IModbusFactory
    {
        /// <summary>
        /// The "built-in" message handlers.
        /// </summary>
        private static readonly IModbusFunctionService[] BuiltInFunctionServices = 
        {
            new ReadCoilsService(),
            new ReadInputsService(),
            new ReadHoldingRegistersService(),
            new ReadInputRegistersService(),
            new DiagnosticsService(),
            new WriteSingleCoilService(),
            new WriteSingleRegisterService(),
            new WriteMultipleCoilsService(),
            new WriteMultipleRegistersService(),
            new ReadWriteMultipleRegistersService(),
        };

        private readonly IDictionary<byte, IModbusFunctionService> _functionServices;

        /// <summary>
        /// Create a factory which uses the built in standard slave function handlers.
        /// </summary>
        public ModbusFactory()
        {
            _functionServices = BuiltInFunctionServices.ToDictionary(s => s.FunctionCode, s => s);

            Logger = NullModbusLogger.Instance;
        }

        /// <summary>
        /// Create a factory which optionally uses the built in function services and allows custom services to be added.
        /// </summary>
        /// <param name="functionServices">User provided function services.</param>
        /// <param name="includeBuiltIn">If true, the built in function services are included. Otherwise, all function services will come from the functionService parameter.</param>
        /// <param name="logger">Logger</param>
        public ModbusFactory(
            IEnumerable<IModbusFunctionService> functionServices = null, 
            bool includeBuiltIn = true, 
            IModbusLogger logger = null)
        {
            Logger = logger ?? NullModbusLogger.Instance;

            //Determine if we're including the built in services
            if (includeBuiltIn)
            {
                //Make a dictionary out of the built in services
                _functionServices = BuiltInFunctionServices
                    .ToDictionary(s => s.FunctionCode, s => s);
            }
            else
            {
                //Create an empty dictionary
                _functionServices = new Dictionary<byte, IModbusFunctionService>();
            }

            if (functionServices != null)
            {
                //Add and replace the provided function services as necessary.
                foreach (IModbusFunctionService service in functionServices)
                {
                    //This will add or replace the service.
                    _functionServices[service.FunctionCode] = service;
                }
            }
        }

        public IModbusSlave CreateSlave(byte unitId, ISlaveDataStore dataStore = null, Action<string> operationCb=null)
        {
            if (dataStore == null)
                dataStore = new DefaultSlaveDataStore();

            return new ModbusSlave(unitId, dataStore, GetAllFunctionServices());
        }

        public IModbusSlaveNetwork CreateSlaveNetwork(IModbusRtuTransport transport, Action<string> operationCb)
        {
            return new ModbusSerialSlaveNetwork(transport, this, Logger, operationCb);
        }

        public IModbusSlaveNetwork CreateSlaveNetwork(IModbusAsciiTransport transport, Action<string> operationCb)
        {
            return new ModbusSerialSlaveNetwork(transport, this, Logger, operationCb);
        }

        public IModbusSlaveNetwork CreateSlaveNetwork(TcpListener tcpListener,Action<string> operationCb)
        {
            return new ModbusTcpSlaveNetwork(tcpListener, this, Logger, operationCb);
        }

        public IModbusSlaveNetwork CreateSlaveNetwork(UdpClient client, Action<string> operationCb)
        {
            return new ModbusUdpSlaveNetwork(client, this, Logger, operationCb);
        }

        public IModbusRtuTransport CreateRtuTransport(IStreamResource streamResource, Action<string> operationCb)
        {
            return new ModbusRtuTransport(streamResource, this, Logger, operationCb);
        }

        public IModbusAsciiTransport CreateAsciiTransport(IStreamResource streamResource, Action<string> operationCb)
        {
            return new ModbusAsciiTransport(streamResource, this, Logger, operationCb);
        }

        public IModbusLogger Logger { get; }

        public IModbusFunctionService[] GetAllFunctionServices()
        {
            return _functionServices
                .Values
                .ToArray();
        }

        public IModbusSerialMaster CreateMaster(IModbusSerialTransport transport, Action<string> operationCb)
        {
            return new ModbusSerialMaster(transport);
        }

        public IModbusMaster CreateMaster(UdpClient client, Action<string> operationCb)
        {
            var adapter = new UdpClientAdapter(client);

            var transport = new ModbusIpTransport(adapter, this, Logger);

            return new ModbusIpMaster(transport);
        }

        public IModbusMaster CreateMaster(TcpClient client, Action<string> operationCb)
        {
            var adapter = new TcpClientAdapter(client);

            var transport = new ModbusIpTransport(adapter, this, Logger);

            return new ModbusIpMaster(transport);
        }

        public IModbusFunctionService GetFunctionService(byte functionCode)
        {
            return _functionServices.GetValueOrDefault(functionCode);
        }
    }
}