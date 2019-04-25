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
            var model = new CreateAgentyTeamRequest
            {
                Email = email,
                Name = name,
                RoleId = roleId,
                Status = status
            };

            return AgentyApi.PostAsync<CreateAgentyTeamRequest, AgentyTeamResponse>("team", model);
        }

        public Task<AgentyTeamResponse> DeleteTeamMemberAsync(string memberId)
        {
            return AgentyApi.DeleteAsync<AgentyTeamResponse>($"team/{memberId}");
        }

        public Task<GetAllAgentyTeamResponse> GetAllTeamMembersAsync()
        {
            return AgentyApi.GetAsync<GetAllAgentyTeamResponse>("team");
        }

        public Task<AgentyTeamModel> GetTeamMemberIdAsync(string memberId)
        {
            return AgentyApi.GetAsync<AgentyTeamModel>($"team/{memberId}");
        }

        public Task<AgentyTeamResponse> UpdateTeamMemberAsync(string memberId, int userId, string email, string name, int roleId, string status)
        {
            var model = new AgentyTeamRequest
            {
                UserId = userId,
                Email = email,
                Name = name,
                RoleId = roleId,
                Status = status
            };

            return AgentyApi.PutAsync<AgentyTeamRequest, AgentyTeamResponse>($"team/{memberId}", model);
        }
    }
}
