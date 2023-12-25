using AutoMapper.Execution;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBiz.DAL;
using MyBiz.DTOs.Worker;
using MyBiz.Entities;
using MyBiz.Helpers;

namespace MyBiz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkersController : ControllerBase
    {
        private readonly AppDbContext _appDb;
        private readonly IMapper _mapper;

        public WorkersController(AppDbContext appDb, IMapper mapper)
        {
            _appDb = appDb;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var worker = _appDb.Workers.ToList();
            var workerDtos = worker.Select(worker => _mapper.Map<WorkerGetDto>(worker));
            return Ok(workerDtos);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var worker = _appDb.Workers.FirstOrDefault(x => x.Id == id);
            if (worker == null)
            {
                return NotFound();
            }

            var workerDtos = _mapper.Map<WorkerGetDto>(worker);
            return Ok(workerDtos);
        }

        [HttpPost]
        public IActionResult Create(WorkerCreateDto dto)
        {
            var worker = _mapper.Map<Worker>(dto);
            worker.CreateDate = DateTime.UtcNow.AddHours(4);
            worker.UpdateDate =DateTime.UtcNow.AddHours(4);
            worker.IsDeleted = false;

            if (dto.ImageFile != null && dto.ImageFile.Length < 1048576 && !(dto.ImageFile.ContentType != "image/png" && dto.ImageFile.ContentType != "image/jpeg"))
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "upload");
                string FileName = Helper.GetFileName(path, "upload", dto.ImageFile);
                var filePath = Path.Combine(path, FileName);
                worker.ImageUrl = filePath;
            }
            else
            {
                throw new Exception();
            }

            _appDb.Workers.Add(worker);
            _appDb.SaveChanges();

            return Ok(worker);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, WorkerUpdateDto dto)
        {
            var worker = _appDb.Workers.Find(id);
            if (worker == null)
            {
                return NotFound();
            }

            worker = _mapper.Map(dto, worker);
          

            if (dto.ImageFile != null && dto.ImageFile.Length < 1048576 && !(dto.ImageFile.ContentType != "image/png" && dto.ImageFile.ContentType != "image/jpeg"))
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "upload");
                string FileName = Helper.GetFileName(path, "upload", dto.ImageFile);
                var filePath = Path.Combine(path, FileName);
                worker.ImageUrl = filePath;
            }

            else
            {
                throw new Exception();

            }
            //worker.Name=dto.Name;
            //worker.About = dto.About;
            //worker.PositionId=dto.PositionId;
            //worker.TwitUrl=dto.TwitUrl;
            //worker.InstaUrl = dto.InstaUrl;
            //worker.FaceUrl = dto.FaceUrl;
            //worker.LinkedinUrl = dto.LinkedinUrl;

            worker.UpdateDate = DateTime.UtcNow.AddHours(4);
            _appDb.SaveChanges();

            return Ok(worker);
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var worker = _appDb.Workers.Find(id);
            worker.IsDeleted = true;
            _appDb.SaveChanges();
            return NoContent();
        }

    }
}