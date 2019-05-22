using Agenty.net.Models.AgentyAgent;
using System.Threading.Tasks;

namespace Agenty.net
{
    public interface IAgentyAgentApi
    {
        Task<GetAllAgentsViewModel> GetAllAgentsAsync();
    }
}
