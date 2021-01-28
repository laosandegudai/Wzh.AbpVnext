using Magicodes.ExporterAndImporter.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Wzh.AbpVnext.Volo.Abp.AuditLogging
{
    public class AuditLogExportDto 
    {
        [ExporterHeader(DisplayName = "状态码")]
        public int? HttpStatusCode { get; set; }
        [ExporterHeader(DisplayName = "comments")]
        public string Comments { get; set; }
        [ExporterHeader(DisplayName = "异常信息")]
        public string Exceptions { get; set; }
        [ExporterHeader(DisplayName = "请求地址")]
        public string Url { get; set; }
        [ExporterHeader(DisplayName = "请求方法")]
        public string HttpMethod { get; set; }
        [ExporterHeader(DisplayName = "浏览器信息")]
        public string BrowserInfo { get; set; }
        [ExporterHeader(DisplayName = "correlationId")]
        public string CorrelationId { get; set; }
        [ExporterHeader(DisplayName = "客户端ID")]
        public string ClientId { get; set; }
        [ExporterHeader(DisplayName = "客户端名称")]
        public string ClientName { get; set; }
        [ExporterHeader(DisplayName = "客户端IP")]
        public string ClientIpAddress { get; set; }
        [ExporterHeader(DisplayName = "耗时(毫秒)")]
        public int ExecutionDuration { get; set; }
        [ExporterHeader(DisplayName = "请求时间", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime ExecutionTime { get; set; }
        [ExporterHeader(DisplayName = "impersonatorTenantId")]
        public Guid? ImpersonatorTenantId { get; set; }
        [ExporterHeader(DisplayName = "impersonatorUserId")]
        public Guid? ImpersonatorUserId { get; set; }
        [ExporterHeader(DisplayName = "租户名称")]
        public string TenantName { get; set; }
        [ExporterHeader(DisplayName = "租户ID")]
        public Guid? TenantId { get; set; }
        [ExporterHeader(DisplayName = "用户名称")]
        public string UserName { get; set; }
        [ExporterHeader(DisplayName = "用户ID")]
        public Guid? UserId { get; set; }
        [ExporterHeader(DisplayName = "服务名称")]
        public string ApplicationName { get; set; }
    }
}
