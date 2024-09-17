using AutoMapper;
using KindnessAPI.Models;
using KindnessAPI.Models.Dto;
using KindnessAPI.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using System.Net;

namespace KindnessAPI.Controllers.v1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [EnableRateLimiting("fixed")]
    [ApiVersion("1.0")]
    public class ActAPIController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IActRepository _actRepository;
        protected APIResponse _response;


        public ActAPIController(IMapper mapper, IActRepository actRepository)
        {
            _mapper = mapper;
            _actRepository = actRepository;
            _response = new APIResponse();

        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetActs(
    [FromQuery(Name = "difficulty")] string? difficulty,
    [FromQuery(Name = "timeRequired")] string? timeRequired,
    [FromQuery(Name = "locationType")] string? locationType,
    [FromQuery(Name = "impactType")] string? impactType,
    [FromQuery] int pageNumber = 0,
    [FromQuery] int pageSize = 1)
        {
            try
            {
                IEnumerable<Act> acts = await _actRepository.GetAllAsync();

                if (!string.IsNullOrEmpty(difficulty))
                {
                    acts = acts.Where(u => u.Difficulty == difficulty);
                }

                if (!string.IsNullOrEmpty(timeRequired))
                {
                    acts = acts.Where(u => u.TimeRequired == timeRequired);
                }

                if (!string.IsNullOrEmpty(locationType))
                {
                    acts = acts.Where(u => u.LocationType == locationType);
                }

                if (!string.IsNullOrEmpty(impactType))
                {
                    acts = acts.Where(u => u.ImpactType == impactType);
                }

                acts = acts.Skip(pageSize * (pageNumber - 1)).Take(pageSize);

                // Map the filtered result to DTOs
                _response.Result = _mapper.Map<List<ActDto>>(acts);
                _response.IsSuccess = true;
                _response.StatusCode = HttpStatusCode.OK;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                // Handle the exception and return an error response
                _response.IsSuccess = false;
                _response.ErrorMessages.Add(ex.ToString());
            }
            return _response;
        }

        [HttpGet("{id:int}", Name = "GetAct")]
        [ResponseCache(Duration = 30)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> GetAct(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("Id is not valid");
                    return BadRequest(_response);
                }
                Act act = await _actRepository.GetAsync(u => u.Id == id);
                if (act == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("Requested Resource is Not Found");
                    return NotFound(_response);
                }
                _response.Result = _mapper.Map<ActDto>(act);
                _response.IsSuccess = true;
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);

            }
            catch (Exception ex)
            {

                _response.IsSuccess = false;
                _response.ErrorMessages.Add(ex.ToString());
            }
            return _response;

        }
        [HttpGet("random-act")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetRandomAct()
        {
            try
            {
                Act act = await _actRepository.GetRandomAsync();
                if (act == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.ErrorMessages.Add("Act is not found");
                    return NotFound(_response);
                }
                _response.IsSuccess = true;
                _response.StatusCode = HttpStatusCode.OK;
                _response.Result = _mapper.Map<ActDto>(act);
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages.Add(ex.ToString());
            }
            return _response;

        }




        [HttpDelete("{id:int}", Name = "DeleteAct")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> DeleteAct(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("Id is not valid");
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                Act act = await _actRepository.GetAsync(u => u.Id == id);
                if (act == null)
                {
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("Act is not found");
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                await _actRepository.RemoveAsync(act);
                _response.IsSuccess = true;
                _response.StatusCode = HttpStatusCode.NoContent;
                return Ok(_response);

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages.Add(ex.ToString());
            }
            return _response;

        }

        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<APIResponse>> CreateAct([FromBody] ActCreateDto createDto)
        {
            try
            {
                Act act = await _actRepository.GetAsync(u => u.Action.ToLower() == createDto.Action.ToLower());
                if (act != null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessages.Add("Act already exist");
                    return BadRequest(_response);
                }
                Act newAct = _mapper.Map<Act>(createDto);
                await _actRepository.CreateAsync(newAct);
                _response.StatusCode = HttpStatusCode.Created;
                _response.IsSuccess = true;
                _response.Result = _mapper.Map<ActDto>(newAct);
                return CreatedAtRoute("GetAct", new { id = newAct.Id }, _response);

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages.Add(ex.ToString());
            }
            return _response;

        }
        [HttpPut("{id:int}", Name = "UpdateAct")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]

        public async Task<ActionResult<APIResponse>> UpdateAct(int id, [FromBody] ActUpdateDto updateDto)
        {
            try
            {
                if (id == 0 || id != updateDto.Id)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessages.Add("Invalid request");
                    return BadRequest(_response);

                }

                if (await _actRepository.GetAsync(u => u.Id == updateDto.Id, tracked: false) == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.ErrorMessages.Add("Resource not found");
                    return NotFound(_response);
                }

                Act act = _mapper.Map<Act>(updateDto);
                await _actRepository.UpdateAsync(act);
                _response.IsSuccess = true;
                _response.StatusCode = HttpStatusCode.NoContent;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages.Add(ex.ToString());
            }
            return _response;

        }
    }
}
