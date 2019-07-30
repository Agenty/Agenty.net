using Agenty.net.Models.AgentyJob;
using System.Threading.Tasks;

namespace Agenty.net
{
    public interface IAgentyJobApi
    {
        Task<AgentyJobResponse> StartJobAsync(string agentType, string agentId);
        Task<AgentyJobResponse> StopJobAsync(string jobId);
        Task<JobStatus> GetJobStatusByIdAsync(string jobId);
        Task<AgentyJobPagingResponse> GetJobResultByIdAsync(string jobId);
        Task<AgentyJobPagingResponse> GetJobLogsByIdAsync(string jobId);
        Task<AgentyJobPagingResponse> GetAllJobsAsync();
        Task<AgentyJobPagingResponse> GetJobsByAgentIdAsync(string agentId);
        Task<ExportJobResponse> ExportJobResultAsync(string jobId);
    }
}