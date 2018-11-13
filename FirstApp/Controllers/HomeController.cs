using FirstApp.Models;
using Microsoft.AspNetCore.Mvc;
using NLog;
using Services.Interfaces;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace FirstApp.Controllers
{
    public class HomeController : Controller
    {
        private ITB1Service _tB1Service;
        private ILogger _logger;
        public HomeController(ITB1Service tB1Service, ILogger logger)
        {
            this._tB1Service = tB1Service;
            this._logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                this._logger.Error("aaaaa");
                //var connectionString = "User Id=dev03;Password=Abc12303;Data Source=10.59.0.14:1521/PDB01";
                //var uow = new UnitOfWork(connectionString);
                ////uow.BeginTransaction();
                //await this._unitOfWork.TB1Repository.InsertAsync(new TB1
                //{
                //    Name = "hh"
                //});
                //uow.Commit();

                //var list = await uow.TB1Repository.GetAll();
                var a = this._tB1Service.GetAll();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
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
