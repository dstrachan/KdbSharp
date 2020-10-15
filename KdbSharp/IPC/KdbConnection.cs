using KdbSharp.Data;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace KdbSharp.IPC
{
    public class KdbConnection : IDisposable
    {
        public string Host { get; }
        public int Port { get; }
        public string Username { get; }
        public string Password { get; }
        public KdbCapability Capability { get; private set; }
        public bool IsOpen { get; private set; }

        private KdbReader _reader;
        private KdbWriter _writer;

        private TcpClient _client;
        private Stream _stream;

        public KdbConnection(string host, int port, KdbCapability capability = KdbCapability.V3_0_WithCompression)
            : this(host, port, string.Empty, string.Empty, capability)
        {
        }

        public KdbConnection(string host, int port, string username, string password, KdbCapability capability = KdbCapability.V3_0_WithCompression)
        {
            Host = host;
            Port = port;
            Username = username;
            Password = password;
            Capability = capability;
        }

        public void Open()
        {
            if (IsOpen)
            {
                return;
            }

            var address = Dns.GetHostEntry(Host).AddressList.Where(x => x.AddressFamily != AddressFamily.InterNetworkV6).First();
            _client = new TcpClient();
            _client.Connect(address, Port);
            _stream = _client.GetStream();
            _stream.Write(Encoding.ASCII.GetBytes($"{Username}:{Password}").Concat(new byte[] { (byte)Capability, 0 }).ToArray());
            var response = new byte[2];
            if (_stream.Read(response, 0, 1) != 1)
            {
                throw new Exception("Connection denied.");
            }
            Capability = (KdbCapability)response[0];

            _reader = new KdbReader(_stream);
            _writer = new KdbWriter(_stream);

            IsOpen = true;
        }

        public void Close()
        {
            if (!IsOpen)
            {
                return;
            }

            _client.Close();
            IsOpen = false;
        }

        public IKdbType Send(IKdbType data)
        {
            _writer.Write(data, KdbMessageType.Sync);
            return _reader.Read();
        }

        public IKdbType Send(string input)
        {
            var message = new KdbCharVector(input.ToCharArray());
            _writer.Write(message, KdbMessageType.Sync);
            return _reader.Read();
        }

        public void SendAsync(string input)
        {
            var message = new KdbCharVector(input.ToCharArray());
            _writer.Write(message, KdbMessageType.Async);
        }

        public void Dispose() => Close();
    }
}
