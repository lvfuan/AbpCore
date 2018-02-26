using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Controllers;
using Abp.Domain.Repositories;
using AbpCore.Models;
using Hangfire;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AbpCore.Web.Host.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class DemoController : AbpController
    {
        private readonly IRepository<TestModel> _repository;
        public DemoController(IRepository<TestModel> repository)
        {
            this._repository = repository;
        }
        [HttpPost]
        public IActionResult Index([FromBody]TestModel model)
        {
            //this._repository.Insert(model);
            //var test = this._repository.GetAll().ToList();
            RecurringJob.AddOrUpdate(() =>  Console.WriteLine("我是任务"),Cron.Daily );
            return View();
        }
    }
}