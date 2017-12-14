using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoriApi.Domain.Events;

namespace LoriApi.Domain
{
    public class CreateConversationDto
    {
        public string Name { get; set; }
        public int Language { get; set; }
        public int BusinessEventId { get; set; }
    }
}
