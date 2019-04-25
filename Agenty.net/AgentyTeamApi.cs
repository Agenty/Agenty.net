using System;
using System.Threading.Tasks;
using Agenty.net.Models.AgentyTeam;

namespace Agenty.net
{
    class AgentyTeamApi : IAgentyTeamApi
    {
        public AgentyTeamApi(AgentyApi agentyApi)
        {
            AgentyApi = agentyApi;
        }
        public AgentyApi AgentyApi { get; private set; }
        public Task<AgentyTeamResponse> CreateTeamMemberAsync(string email, string name, int roleId, string status)
        {
            throw new NotImplementedException();
        }

        public Task<AgentyTeamResponse> DeleteTeamMemberAsync(string memberId)
        {
            throw new NotImplementedException();
        }

        public Task<GetAllAgentyTeamResponse> GetAllTeamMembersAsync()
        {
            return AgentyApi.GetAsync<GetAllAgentyTeamResponse>("team");
        }

        public Task<AgentyTeamModel> GetTeamMemberIdAsync(string memberId)
        {
            throw new NotImplementedException();
        }

        public Task<AgentyTeamResponse> UpdateTeamMemberAsync(string memberId, int userId, string email, string name, int roleId, string status)
        {
            throw new NotImplementedException();
        }
    }
}
