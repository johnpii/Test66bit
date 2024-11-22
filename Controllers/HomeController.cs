using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Diagnostics;
using Test66bit.Hubs;
using Test66bit.Interfaces.Services;
using Test66bit.Models;
using Test66bit.ViewModels;

namespace Test66bit.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFootballerService _footballerService;
        private readonly ITeamService _teamService;
        private readonly IMapper _mapper;
        private readonly IHubContext<Test66bitHub> _test66bitHub;

        public HomeController(ILogger<HomeController> logger, IFootballerService footballerService, ITeamService teamService, IMapper mapper, IHubContext<Test66bitHub> test66bitHub)
        {
            _logger = logger;
            _footballerService = footballerService;
            _teamService = teamService;
            _mapper = mapper;
            _test66bitHub = test66bitHub;
        }

        public async Task<IActionResult> Index()
        {
            var teams = await _teamService.GetAllTeamsAsync();
            ViewBag.Teams = teams;
            return View("Add");
        }

        [HttpPost]
        public async Task<IActionResult> Add(FootballerAdd footballer)
        {
            if (ModelState.IsValid)
            {
                Team team = null;
                if (footballer.TeamName == "NewTeam" && footballer.NewTeamName == null)
                {
                    ViewBag.Error = "Имя команды не может быть пустым";
                    var teams = await _teamService.GetAllTeamsAsync();
                    ViewBag.Teams = teams;
                    ViewBag.IsNewTeamSelected = true;
                    footballer.TeamName = string.Empty;
                    return View("Add", footballer);
                }
                if (footballer.NewTeamName != null)
                {
                    team = _teamService.FindTeamByName(footballer.NewTeamName);
                    if (team == null)
                    {
                        var newTeam = new Team { Name = footballer.NewTeamName };
                        team = _teamService.AddTeam(newTeam);
                    }
                }
                else
                {
                    team = _teamService.FindTeamByName(footballer.TeamName);
                    if (team == null)
                    {
                        ViewBag.Error = "Некорректное значение названия команды";
                        return View(footballer);
                    }
                }

                var convertedFootballer = _mapper.Map<Footballer>(footballer);
                convertedFootballer.Team = team;
                _footballerService.AddFootballer(convertedFootballer);

                await _test66bitHub.Clients.All.SendAsync("newFootballer", new
                {
                    id = convertedFootballer.Id,
                    firstName = convertedFootballer.FirstName,
                    lastName = convertedFootballer.LastName,
                    gender = convertedFootballer.Gender.ToString(),
                    dateOfBirth = convertedFootballer.DateOfBirth,
                    team = new { name = convertedFootballer.Team.Name },
                    country = convertedFootballer.Country.ToString()
                });

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Error = "Некорректное значение";
                return View(footballer);
            }
        }


        public async Task<IActionResult> List()
        {
            var teams = await _teamService.GetAllTeamsAsync();
            ViewBag.Teams = teams;
            var footbalers = await _footballerService.GetAllFootballersAsync();
            return View("List", footbalers);
        }

        [HttpPost]
        public IActionResult Edit(FootballerEdit footballer)
        {
            if (ModelState.IsValid)
            {
                var team = _teamService.FindTeamByName(footballer.TeamName);
                if (team == null)
                {
                    ViewBag.Error = "Некорректное значение названия команды";
                    return RedirectToAction("List", "Home");
                }
                var convertedFootballer = _mapper.Map<Footballer>(footballer);
                convertedFootballer.Team = team;
                _footballerService.EditFootballer(convertedFootballer);
                return RedirectToAction("List", "Home");
            }
            else
            {
                ViewBag.Error = "Некорректное значение";
                return RedirectToAction("List", "Home");
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
