using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyBiz.DAL;
using MyBiz.DTOs.Position;
using MyBiz.Entities;

namespace MyBiz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionsController : ControllerBase
    {
        private readonly AppDbContext _appDb;
        private readonly IMapper _mapper;

        public PositionsController(AppDbContext appDb, IMapper mapper)
        {
            _appDb = appDb;
            _mapper = mapper;
        }
        [HttpGet("")]
        public IActionResult GetAll()
        {
            var positions = _appDb.Positions.ToList();
            var positionsdto = positions.Select(positions => _mapper.Map<PositionGetDto>(positions));
            return Ok(positionsdto);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var positions = _appDb.Positions.FirstOrDefault(x => x.Id == id);

            PositionGetDto positionsdto = _mapper.Map<PositionGetDto>(positions);
            return Ok(positionsdto);

        }

        [HttpPost]
        public IActionResult Create(PositionCreateDto dto)
        {
            var position = _mapper.Map<Position>(dto);
            position.CreateDate = DateTime.UtcNow.AddHours(4);
            position.UpdateDate = DateTime.UtcNow.AddHours(4);
            position.IsDeleted = false;
            _appDb.Positions.Add(position);
            _appDb.SaveChanges();
            return Ok(position);
        }
        [HttpPut("{id}")]
        public IActionResult Update( PositionUpdateDto dto)
        {
            var position = _appDb.Positions.Find(dto.Id);
            if (position == null) return NotFound();
            position = _mapper.Map(dto, position);
            position.UpdateDate = DateTime.UtcNow.AddHours(4);
            _appDb.SaveChanges();
            return Ok(position);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var position = _appDb.Positions.Find(id);
            position.IsDeleted=true;
            position.DeletedDate = DateTime.UtcNow.AddHours(4);
            _appDb.SaveChanges();
            return NoContent();
        }
    }
}
