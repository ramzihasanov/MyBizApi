using AutoMapper;
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
        private readonly IWebHostEnvironment _env;

        public WorkersController(AppDbContext appDb, IMapper mapper,IWebHostEnvironment env)
        {
            _appDb = appDb;
            _mapper = mapper;
            this._env = env;
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
        public IActionResult Create([FromForm]WorkerCreateDto dto)
        {
            var worker = _mapper.Map<Worker>(dto);
            worker.CreateDate = DateTime.UtcNow.AddHours(4);
            worker.UpdateDate =DateTime.UtcNow.AddHours(4);
            worker.IsDeleted = false;

            if (dto.ImageFile != null && dto.ImageFile.Length < 1048576 && !(dto.ImageFile.ContentType != "image/png" && dto.ImageFile.ContentType != "image/jpeg"))
            {
                string fileNmae = Helper.GetFileName(_env.WebRootPath, "upload", dto.ImageFile);

                string path = Path.Combine(_env.WebRootPath, "upload", worker.ImageUrl);
                worker.ImageUrl = fileNmae;
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
        public IActionResult Update([FromForm]int id, WorkerUpdateDto dto)
        {
            var worker = _appDb.Workers.Find(id);
            if (worker == null)
            {
                return NotFound();
            }

            worker = _mapper.Map(dto, worker);
          

            if (dto.ImageFile != null && dto.ImageFile.Length < 1048576 && !(dto.ImageFile.ContentType != "image/png" && dto.ImageFile.ContentType != "image/jpeg"))
            {
                string fileNmae = Helper.GetFileName(_env.WebRootPath, "upload", dto.ImageFile);

                string path = Path.Combine(_env.WebRootPath, "upload", worker.ImageUrl);

               

                worker.ImageUrl = fileNmae;
            }

            else
            {
                throw new Exception();

            }
            

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