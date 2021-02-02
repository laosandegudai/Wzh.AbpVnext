using Magicodes.ExporterAndImporter.Core;
using Magicodes.ExporterAndImporter.Excel;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AuditLogging;
using Wzh.AbpVnext;
using Wzh.AbpVnext.Volo.Abp.AuditLogging;

namespace Volo.Abp.AuditLogging
{
    [RemoteService(false)]
    [Authorize(AuditLogPermissions.AuditLogs.Default)]
    public class AuditLogAppService : AbpVnextAppService, IAuditLogAppService
    {
        protected IAuditLogRepository AuditLogRepository { get; }
        public AuditLogAppService(IAuditLogRepository auditLogRepository)
        {
            AuditLogRepository = auditLogRepository;
        }

        public virtual async Task<AuditLogDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<AuditLog, AuditLogDto>(await AuditLogRepository.GetAsync(id));
        }

        public virtual async Task<PagedResultDto<AuditLogDto>> GetListAsync(GetAuditLogDto input)
        {
            var count = await AuditLogRepository.GetCountAsync(
                startTime: input.StartTime,
                endTime: input.EndTime,
                httpMethod: input.HttpMethod,
                url: input.Url,
                userName: input.UserName,
                applicationName: input.ApplicationName,
                correlationId: input.CorrelationId,
                maxExecutionDuration: input.MaxExecutionDuration,
                minExecutionDuration: input.MinExecutionDuration,
                hasException: input.HasException,
                httpStatusCode: input.HttpStatusCode
            );
            var list = await AuditLogRepository.GetListAsync(
                sorting: input.Sorting,
                maxResultCount: input.MaxResultCount,
                skipCount: input.SkipCount,
                startTime: input.StartTime,
                endTime: input.EndTime,
                httpMethod: input.HttpMethod,
                url: input.Url,
                userName: input.UserName,
                applicationName: input.ApplicationName,
                correlationId: input.CorrelationId,
                maxExecutionDuration: input.MaxExecutionDuration,
                minExecutionDuration: input.MinExecutionDuration,
                hasException: input.HasException,
                httpStatusCode: input.HttpStatusCode,
                includeDetails: input.IncludeDetails
            );
            return new PagedResultDto<AuditLogDto>(
                count,
                ObjectMapper.Map<List<AuditLog>, List<AuditLogDto>>(list)
            );
        }

        [Authorize(AuditLogPermissions.AuditLogs.Delete)]
        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        [Authorize(AuditLogPermissions.AuditLogs.Delete)]
        public virtual async Task DeleteManyAsync(params Guid[] ids)
        {
            foreach (var id in ids)
            {
                var auditLog = await AuditLogRepository.GetAsync(id);
                auditLog.EntityChanges.Clear();
                auditLog.Actions.Clear();
                await AuditLogRepository.DeleteAsync(id);
            }
        }
        [AllowAnonymous]
        public async Task<byte[]> ExportExcel(GetAuditLogDto input)
        {
            var list = await AuditLogRepository.GetListAsync(
                sorting: input.Sorting,
                maxResultCount: input.MaxResultCount,
                skipCount: input.SkipCount,
                startTime: input.StartTime,
                endTime: input.EndTime,
                httpMethod: input.HttpMethod,
                url: input.Url,
                userName: input.UserName,
                applicationName: input.ApplicationName,
                correlationId: input.CorrelationId,
                maxExecutionDuration: input.MaxExecutionDuration,
                minExecutionDuration: input.MinExecutionDuration,
                hasException: input.HasException,
                httpStatusCode: input.HttpStatusCode,
                includeDetails: input.IncludeDetails
            );
            var entityDtos = ObjectMapper.Map<List<AuditLog>, List<AuditLogExportDto>>(list);
            IExporter exporter = new ExcelExporter();
            var content = await exporter.ExportAsByteArray(entityDtos);
            return content;
        }
    }
}
