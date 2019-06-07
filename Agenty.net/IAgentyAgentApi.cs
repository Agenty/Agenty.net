using Agenty.net.Models.AgentyAgent;
using System.Threading.Tasks;

namespace Agenty.net
{
    public interface IAgentyAgentApi
    {
        Task<GetAllAgentsViewModel> GetAllAgentsAsync();
        Task<AgentViewModel> GetAgentByAgentIdAsync(string agentId);
        Task<AgentyAgentResponse> Clone(string agentId);
        Task<AgentyAgentResponse> Delete(string agentId);
    }
}
