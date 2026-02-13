using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RFQ.Application.Interface;
using RFQ.Application.Provider;
using RFQ.Domain.Helper;
using RFQ.Domain.Models;
using RFQ.Domain.RequestDto;

namespace RFQ.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class MasterUserActivityLogController : ControllerBase
    {
        private readonly IMasterUserActivityLogService _masterUserActivityLogService;
        private readonly IMapper _mapper;
        private readonly ILogger<MasterUserActivityLogController> _logger;

        public MasterUserActivityLogController(IMasterUserActivityLogService masterUserActivityLogService, IMapper mapper, ILogger<MasterUserActivityLogController> logger)
        {
            _masterUserActivityLogService = masterUserActivityLogService;
            _mapper = mapper;
            _logger = logger;
        }

        //[HttpGet("GetAllMasterUserActivityLog")]
        //public async Task<ActionResult<IEnumerable<MasterUserActivityLog>>> GetAllMasterUserActivityLog()
        //{
        //    try
        //    {
        //        _logger.LogInformation("Requesting MasterUserActivityLog Details...");
        //        var master = await _masterUserActivityLogService.GetAllMasterUserActivityLog();
        //        return Ok(master);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.StackTrace);
        //        return Ok(ex);
        //    }
        //}

        [HttpPost("GetAllMasterUserActivityLogList")]
        public async Task<ActionResult> GetAllMasterUserActivityLogList([FromBody] PagingParam pagingParam)
        {
            try
            {
                _logger.LogInformation("Get All MasterUserActivityLog Details....");
                var activityLog = await _masterUserActivityLogService.GetAllMasterUserActivityLogList(pagingParam);
                if (activityLog == null)
                {
                    NotFound("MasterUserActivityLog unavailable");
                }
                return Ok(activityLog);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpGet("GetMasterUserActivityLog/{id}")]
        public async Task<ActionResult<MasterUserActivityLog>> GetMasterUserActivityLogById(int id)
        {
            try
            {
                _logger.LogInformation("Get MasterUserActivityLog Details....");
                var log = await _masterUserActivityLogService.GetMasterUserActivityLogById(id);
                if (log == null)
                {
                    return NotFound("MasterUserActivityLog not Found");
                }
                return Ok(log);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpPost("AddMasterUserActivityLog")]
        public async Task<ActionResult<MasterUserActivityLog>> AddMasterUserActivityLog(MasterUserActivityLogDto log)
        {
            try
            {
                _logger.LogInformation("Add MasterUserActivityLog Details....");
                if (!ModelState.IsValid)
                {
                    var messages = ModelState
                      .SelectMany(modelState => modelState.Value.Errors)
                      .Select(err => err.ErrorMessage)
                      .ToList();

                    return BadRequest(messages);
                }
                var result = _mapper.Map<MasterUserActivityLog>(log);
                await _masterUserActivityLogService.AddMasterUserActivityLog(result);
                return Ok("Add MasterUserActivityLog Successfully..");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }


        [HttpPut("UpdateMasterUserActivityLog/{id}")]
        public async Task<ActionResult> UpdateMasterUserActivityLog(int id, MasterUserActivityLogDto log)
        {
            try
            {
                _logger.LogInformation("Update MasterUserActivityLog Details....");
                if (!ModelState.IsValid)
                {
                    var messages = ModelState
                      .SelectMany(modelState => modelState.Value.Errors)
                      .Select(err => err.ErrorMessage)
                      .ToList();

                    return BadRequest(messages);
                }
                var result = _mapper.Map<MasterUserActivityLog>(log);
                result.UserActivityLogId = id;
                await _masterUserActivityLogService.UpdateMasterUserActivityLog(result);
                return Ok("Update MasterUserActivityLog Successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }

        [HttpPut("DeleteMasterUserActivityLog/{id}")]
        public async Task<ActionResult> DeleteMasterUserActivityLog(int id)
        {
            try
            {
                _logger.LogInformation("Delete MasterUserActivityLog Details....");
                await _masterUserActivityLogService.DeleteMasterUserActivityLog(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Ok(ex);
            }
        }
    }
}
