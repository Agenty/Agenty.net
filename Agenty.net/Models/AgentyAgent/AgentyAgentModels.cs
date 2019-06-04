using System;
using System.Collections.Generic;

namespace Agenty.net.Models.AgentyAgent
{
    public class AgentyAgentResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string Type { get; set; }
        public string AgentId { get; set; }
    }
    public class GetAllAgentsViewModel
    {
        public int Offset { get; set; }
        public int Limit { get; set; }
        public int Total { get; set; }
        public List<AgentViewModel> Result { get; set; }
    }

    public class AgentViewModel
    {
        public string AgentId { get; set; }
        public string ProjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public int Version { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string CronExpression { get; set; }
        public string ScheduleDescription { get; set; }
        public DateTime NextAutoRunAt { get; set; }
        public int AccessGroupId { get; set; }
        public ConfigModel Config { get; set; }
    }

    public class ConfigModel
    {
        public string Sourceurl { get; set; }
        public List<CollectionModel> Collections { get; set; }
        public EngineViewModel Engine { get; set; }
        public string Waitafterpageload { get; set; }
        public LoginModel Login { get; set; }
        public dynamic Logout { get; set; }
        public PaginationModel Pagination { get; set; }
        public HeaderModel Header { get; set; }
        public AutoRedirectModel Autoredirect { get; set; }
        public FailedRetryModel Failedretry { get; set; }
        public ProxyModel Proxy { get; set; }
        public ThrottlingModel Throttling { get; set; }
        public FormsubmitModel Formsubmit { get; set; }
        public ProfilesModel Profiles { get; set; }
        public object Meta { get; set; }
        public InputModel Input { get; set; }
    }

    public class CollectionModel
    {
        public string Name { get; set; }
        public List<FieldModel> Fields { get; set; }
    }

    public class FieldModel
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Selector { get; set; }
        public string Extract { get; set; }
        public string Attribute { get; set; }
        public string From { get; set; }
        public bool Visible { get; set; }
        public bool Cleantrim { get; set; }
        public bool JoinResult { get; set; }
        public List<FunctionModel> Postprocessing { get; set; }
    }

    public class FunctionModel
    {
        public string Function { get; set; }
        public List<ParameterModel> Parameters { get; set; }
    }

    public class ParameterModel
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }

    public class EngineViewModel
    {
        public string Name { get; set; }
        public bool Loadjavascript { get; set; }
        public bool Loadimages { get; set; }
        public int Timeout { get; set; }
        public ViewPortModel Viewport { get; set; }
    }
    public class ViewPortModel
    {
        public int Width { get; set; }
        public int Height { get; set; }
    }

    public class LoginModel
    {
        public bool Enabled { get; set; }
        public string Type { get; set; }
        public dynamic[] Data { get; set; }
    }
    public class PaginationModel
    {
        public bool Enabled { get; set; }
        public string Type { get; set; }
        public string Selector { get; set; }
        public int Maxpages { get; set; }
    }
    public class HeaderModel
    {
        public string Method { get; set; }
        public string Encoding { get; set; }
        public KeyValuePair<string, string>[] Data { get; set; }
    }

    public class AutoRedirectModel
    {
        public bool Enabled { get; set; }
        public int Maxautoredirect { get; set; }
    }


    public class FailedRetryModel
    {
        public bool Enabled { get; set; }
        public int Maxtry { get; set; }
        public int Tryinterval { get; set; }
        public int Timeout { get; set; }
    }


    public class ProxyModel
    {
        public bool Enabled { get; set; }
        public string Type { get; set; }
        public string Reference { get; set; }
    }


    public class ThrottlingModel
    {
        public bool Enabled { get; set; }
        public string Type { get; set; }
        public int Seconds { get; set; }
    }

    public class FormsubmitModel
    {
        public bool Enabled { get; set; }
        public object[] Data { get; set; }
    }


    public class ProfilesModel
    {
        public bool Enabled { get; set; }
        public object[] Data { get; set; }
    }


    public class InputModel
    {
        public string Type { get; set; }
        public object Reference { get; set; }
    }

}
