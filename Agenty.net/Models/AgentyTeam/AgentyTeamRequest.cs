namespace Agenty.net.Models.AgentyTeam
{
    public class UpdateAgentyTeamRequest : AgentyRequestBase
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public int RoleId { get; set; }
        public string Status { get; set; }
    }
}
