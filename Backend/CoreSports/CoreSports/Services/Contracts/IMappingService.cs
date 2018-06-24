using System.Collections.Generic;
using System.IO;
using Models;

namespace CoreSports.Services.Contracts
{
    public interface IMappingService
    {
        IEnumerable<Event> MapToEvents(Stream documentStream);
    }
}
