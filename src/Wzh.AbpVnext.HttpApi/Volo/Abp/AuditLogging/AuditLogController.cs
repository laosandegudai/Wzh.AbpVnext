using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Wzh.AbpVnext.Controllers;

namespace Volo.Abp.AuditLogging
{
    [RemoteService(Name = AuditLogRemoteServiceConsts.RemoteServiceName)]
    [ControllerName("AuditLogging")]
    [Area("auditlogging")]
    [Route("/api/audit-logging/audit-logs")]
    public class AuditLogController : AbpVnextController
    {
        protected IAuditLogAppService AuditLogAppService { get; }
        public AuditLogController(IAuditLogAppService auditLogAppService)
        {
            AuditLogAppService = auditLogAppService;
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return AuditLogAppService.DeleteAsync(id);
        }

        [HttpDelete]
        [Route("delete-many")]
        public virtual Task DeleteManyAsync(Guid[] ids)
        {
            return AuditLogAppService.DeleteManyAsync(ids);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<AuditLogDto> GetAsync(Guid id)
        {
            return AuditLogAppService.GetAsync(id);
        }

        [HttpGet]
        public virtual Task<PagedResultDto<AuditLogDto>> GetListAsync(GetAuditLogDto input)
        {
            return AuditLogAppService.GetListAsync(input);
        }
        [HttpGet]
        [Route("export-excel")]
        public async Task<IActionResult> ExportExcel(GetAuditLogDto input)
        {
            var content = await AuditLogAppService.ExportExcel(input);
            var memoryStream = new MemoryStream(content);
            return new FileStreamResult(memoryStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
            {
                FileDownloadName = "AuditLog.xlsx"
            };
        }
    }
}
