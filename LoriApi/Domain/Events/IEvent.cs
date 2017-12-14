using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoriApi.Domain.Events
{
    public abstract class IEvent
    {
        public abstract Events EventId { get; }
    }
}
