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
        public async Task<IActionResult> Index(int department = -1, int position=-1, int pageNumber = 1, int pageSize = 4)
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

        [HttpPost]
        public async Task<IActionResult> Promotion(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if(user == null)
                return NotFound();

            if(user.Position != Positions.Director)
            {
                // promotion by decreasing position enum
                user.Position = (Positions) ((int)user.Position) - 1;
            }
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if(user == null)
                return NotFound();

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
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

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
                return NotFound();
            UserViewModel model = _mapper.Map<UserViewModel>(user);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = _mapper.Map<User>(model);

            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return RedirectToAction("index");
        }

        [HttpGet]
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
