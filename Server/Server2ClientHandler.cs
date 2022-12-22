﻿using Microsoft.Extensions.Logging;
using Shared;
using Server.OSApi;

namespace Server
{
    /// <summary>
    /// Responds with physical cores count and process modules count.
    /// <br/>
    /// Not ideal name, but pretty straightforward,
    /// sinse this handler serves the second part of the task.
    /// </summary>
    internal class Server2ClientHandler : SimpleClientHandler
    {
        public Server2ClientHandler(ILogger logger) : base(logger) { }


        protected override int CreateAndWriteResponse(MessageWriter writer, byte code)
        {
            var header = new MessageHeader(code, DateTime.Now);

            var physicalCores = OperatingSystemApi.Current.GetPhysicalCoresCount();
            var modulesCount = OperatingSystemApi.Current.GetProcessModulesCount();

            writer.Write(header);
            writer.Write(physicalCores);
            writer.Write(modulesCount);
            return writer.CurrentPosition;
        }
    }
}