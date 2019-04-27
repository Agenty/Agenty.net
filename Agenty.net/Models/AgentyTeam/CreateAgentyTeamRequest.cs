namespace Agenty.net.Models.AgentyTeam
{
    class CreateAgentyTeamRequest : AgentyRequestBase
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public int RoleId { get; set; }
        public string Status { get; set; }
    }
}
