using System.Collections.Generic;

namespace Agenty.net.Models.AgentyTeam
{
    public class GetAllAgentyTeamResponse
    {
        public int Total { get; set; }
        public int Limit { get; set; }
        public int Offset { get; set; }
        public int Returned { get; set; }
        public List<AgentyTeamModel> Result { get; set; }
    }
}
