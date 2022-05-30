using AutoMapper;
using cloudscribe.Pagination.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StaffSystem.Core.Interfaces;
using StaffSystem.Core.ProjectAggregate.Identity;
using StaffSystem.Infrastructure.Data;
using StaffSystem.Web.Models;

namespace StaffSystem.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserFilterService _userFilterService;
        private readonly AppDbContext _context;
        public readonly IMapper _mapper;

        public UsersController(
            IUserFilterService userFilterService,
            AppDbContext appDbContext,
            IMapper mapper
            )
        {
            _userFilterService = userFilterService;
            _context = appDbContext;
            _mapper = mapper;

        }
        [HttpGet]
        public async Task<IActionResult> Index(int department = -1, int position=-1, int pageNumber = 1, int pageSize = 1)
        {
            ViewBag.DeparmentFilter = department;
            ViewBag.Position = position;
            int excludeRecords = (pageSize * pageNumber) - pageSize;
            await _userFilterService.FilterAsync(department, position);

            var users = await _userFilterService.FilterAsync(department, position);
            var usersCount = users.Count();
            users = users
                .Skip(excludeRecords)
                .Take(pageSize);


            var result = new PagedResult<User>
            {
                Data = users.AsNoTracking().ToList(),
                TotalItems = usersCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            return View(new UsersViewModel
            {
                Users = result
            });
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Promotion(string id)
        {
            return null;
        }

        [HttpPost("{id}")]
        public async  Task<IActionResult> Delete(string id)
        {
            return null;
        }

        [HttpGet]
        public async Task <IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(UserViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            
            // map all params because User entity additional fields are specified as nullable
            var user = _mapper.Map<User>(model);
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update()
        {
            return null;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Profile(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return NotFound();

            var userViewModel = _mapper.Map<UserViewModel>(user);
            return View(userViewModel);
        }

    }
}
