using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agenty.net.Models.AgentyJob;

namespace Agenty.net
{
    class AgentyJobApi : IAgentyJobApi
    {
        public AgentyApi AgentyApi { get; private set; }
        public AgentyJobApi(AgentyApi agentyApi)
        {
            AgentyApi = agentyApi;
        }
        public Task<AgentyJobPagingResponse> GetAllJobsAsync()
        {
            return AgentyApi.GetAsync<AgentyJobPagingResponse>("jobs");
        }

        public Task<AgentyJobPagingResponse> GetJobLogsByIdAsync(string jobId)
        {
            return AgentyApi.GetAsync<AgentyJobPagingResponse>($"jobs/{jobId}/logs");
        }

        public Task<AgentyJobPagingResponse> GetJobResultByIdAsync(string jobId)
        {
            return AgentyApi.GetAsync<AgentyJobPagingResponse>($"jobs/{jobId}/result");
        }

        public Task<AgentyJobPagingResponse> GetJobsByAgentIdAsync(string agentId)
        {
            return AgentyApi.GetAsync<AgentyJobPagingResponse>($"jobs?agent_id={agentId}");
        }

        public Task<JobStatus> GetJobStatusByIdAsync(string jobId)
        {
            return AgentyApi.GetAsync<JobStatus>($"jobs/{jobId}");
        }

        public Task<AgentyJobResponse> StartJobAsync(string agentType, string agentId)
        {
            return AgentyApi.PostAsync<StartJobRequestModel, AgentyJobResponse>($"jobs/{agentType}/async", new StartJobRequestModel
            {
                AgentId = agentId
            });
        }

        public Task<AgentyJobResponse> StopJobAsync(string jobId)
        {
            return AgentyApi.GetAsync<AgentyJobResponse>($"jobs/{jobId}/stop");
        }

        public Task<ExportJobResponse> ExportJobResultAsync(string jobId)
        {
            return AgentyApi.GetAsync<ExportJobResponse>($"jobs/{jobId}/export");
        }
    }
}
