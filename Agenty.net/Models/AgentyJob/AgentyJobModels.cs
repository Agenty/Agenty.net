using System;

namespace Agenty.net.Models.AgentyJob
{
    public class AgentyJobResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string JobId { get; set; }
    }


    public class JobStatus
    {
        public int JobId { get; set; }
        public string AgentId { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public int PagesTotal { get; set; }
        public int PagesProcessed { get; set; }
        public int PagesSuccessed { get; set; }
        public int PagesFailed { get; set; }
        public int PagesCredit { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime StartedAt { get; set; }
        public object CompletedAt { get; set; }
        public object StoppedAt { get; set; }
        public bool IsScheduled { get; set; }
        public object Error { get; set; }
    }

    public class AgentyJobPagingResponse
    {
        public int Total { get; set; }
        public int Limit { get; set; }
        public int Offset { get; set; }
        public int Returned { get; set; }
        public dynamic[] Result { get; set; }
    }

    public class ExportJobResponse
    {
        public string Downloadlink { get; set; }
    }

    public class StartJobRequestModel : AgentyRequestBase
    {
        public string AgentId { get; set; }
    }
}