using Agenty.net.Models.AgentyTeam;
using System.Threading.Tasks;

namespace Agenty.net
{
    public interface IAgentyTeamApi
    {
        Task<AgentyTeamResponse> CreateTeamMemberAsync(string email, string name, int roleId, string status);
        Task<AgentyTeamModel> GetTeamMemberIdAsync(string memberId);
        Task<AgentyTeamResponse> UpdateTeamMemberAsync(string memberId, int userId, string email, string name, int roleId, string status);
        Task<GetAllAgentyTeamResponse> GetAllTeamMembersAsync();
        Task<AgentyTeamResponse> DeleteTeamMemberAsync(string memberId);
    }
}
