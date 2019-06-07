using System.Threading.Tasks;
using Agenty.net.Models.AgentyAgent;

namespace Agenty.net
{
    class AgentyAgentApi : IAgentyAgentApi
    {
        public AgentyApi AgentyApi { get; private set; }
        public AgentyAgentApi(AgentyApi agentyApi)
        {
            AgentyApi = agentyApi;
        }
        public Task<AgentyAgentResponse> Clone(string agentId)
        {
            return AgentyApi.GetAsync<AgentyAgentResponse>($"agents/{agentId}/clone");
        }

        public Task<AgentyAgentResponse> Delete(string agentId)
        {
            return AgentyApi.DeleteAsync<AgentyAgentResponse>($"agents/{agentId}");
        }

        public Task<AgentViewModel> GetAgentByAgentIdAsync(string agentId)
        {
            return AgentyApi.GetAsync<AgentViewModel>($"agents/scraping/{agentId}");
        }

        public Task<GetAllAgentsViewModel> GetAllAgentsAsync()
        {
            return AgentyApi.GetAsync<GetAllAgentsViewModel>("agents");
        }
    }
}
