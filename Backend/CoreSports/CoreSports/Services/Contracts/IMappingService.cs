using System.Collections.Generic;
using System.IO;
using Models;

namespace CoreSports.Services.Contracts
{
    public interface IMappingServicecs
    {
        IEnumerable<Event> MapToEvents(Stream documentStream);
    }
}
