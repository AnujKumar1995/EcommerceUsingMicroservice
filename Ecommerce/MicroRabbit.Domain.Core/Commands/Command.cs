
#region Import Packages

using MicroRabbit.Domain.Core.Events;
using System;

#endregion

namespace MicroRabbit.Domain.Core.Commands
{
    public abstract class Command : Message
    {

        public DateTime Timestamp { get; protected set; }

        protected Command()
        {
            Timestamp = DateTime.Now;
        }
    }
}