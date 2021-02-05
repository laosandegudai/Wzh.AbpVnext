using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Data;

namespace Wzh.AbpVnext.AuditLogging
{
    public class AuditLogActionDto : EntityDto<Guid>, IHasExtraProperties
    {
        public string ServiceName { get; set; }
        public string MethodName { get; set; }
        public string Parameters { get; set; }
        public DateTime ExecutionTime { get; set; }
        public int ExecutionDuration { get; set; }
        public Dictionary<string, object> ExtraProperties { get; set; }

        ExtraPropertyDictionary IHasExtraProperties.ExtraProperties => throw new NotImplementedException();
    }
}
