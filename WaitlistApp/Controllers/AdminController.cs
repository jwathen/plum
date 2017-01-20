using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using WaitlistApp.Models;

namespace WaitlistApp.Controllers
{
    [Authorize(Users = "1")]
    public partial class AdminController : AppControllerBase
    {
        [HttpGet, Route("admin/log")]
        public virtual ActionResult ViewLog()
        {
            var model = Connection.Query<LogEntry>("select top 100 * from Log with(nolock) order by Id desc");
            return View(model);
        }
    }
}