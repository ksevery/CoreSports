using System.IO;
using CoreSports.Services.Models;

namespace CoreSports.Services.Contracts
{
    public interface IMappingService
    {
        EventCommand MapToEvents(Stream documentStream);
    }
}
