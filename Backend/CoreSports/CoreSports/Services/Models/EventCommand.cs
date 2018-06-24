using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace CoreSports.Services.Models
{
    public class EventCommand
    {
        public CommandType Type { get; set; }

        public IList<Event> Models { get; set; }
    }
}
