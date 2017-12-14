using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoriApi.Domain.Events
{
    public class LoanInterviewStarted : IEvent
    {
        public override Events EventId => Events.LoanInterviewStarted;
    }
}
