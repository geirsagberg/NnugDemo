using System;
using Microsoft.AspNetCore.Mvc;

namespace NnugDemo.Web.Controllers
{
    [Route("Values")]
    public class ValuesController : Controller
    {
        [HttpGet]
        public Values GetValues() => new Values {
            Foo = "foo",
            Bar = new Random().Next()
        };
    }

    public class Values
    {
        public string Foo { get; set; } = "";
        public int Bar { get; set; }
    }
}
