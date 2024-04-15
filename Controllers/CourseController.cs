using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PC_WebApp4.Models;
using PC_WebApp4.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_WebApp4.Controllers
{
    public class CourseController : Controller
    {
        private readonly CourseService _course_service;
        private readonly IConfiguration configuration;

        public CourseController(CourseService _svc, IConfiguration config)
        {
            _course_service = _svc;
            configuration = config;
        }

        public IActionResult Index()
        {
            IEnumerable<Course> _course_list = _course_service.GetCourses(configuration.GetConnectionString("SqlConnection"));
            return View(_course_list);
        }
    }
}
