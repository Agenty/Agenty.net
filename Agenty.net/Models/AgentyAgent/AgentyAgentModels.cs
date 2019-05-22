using System;
using System.Collections.Generic;

namespace Agenty.net.Models.AgentyAgent
{
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
}
