using Microsoft.AspNetCore.Mvc;
using SimransBooks.DataAccess.Repository.IRepository;
using SimransBooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimransBookStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Upsert(int? id)      //action method for upsert
        {
            Category category = new Category();     //using SimransBooks.Models
            if (id == null)
            {
                // this is for create
                return View(category);
            }
                // this is for edit
                category = _unitOfWork.Category.Get(id.GetValueOrDefault());
                if (category == null)
                {
                    return NotFound();
                }
                return View();
            }

        //API calls here 
        #region API CALLS
        public IActionResult GetAll()
        {
            // return not found();
            var allObj = _unitOfWork.Category.GetAll();
            return Json(new { data = allObj });
        }
        #endregion
    }
}
