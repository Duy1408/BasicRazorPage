using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject;
using Repo.Interface;

namespace Eyeglasses_NguyenThienCaoDuy.Pages.EyeglassManager
{
    public class IndexModel : PageModel
    {
        private readonly IEyeglassRepo _eyeglass;

        public IndexModel(IEyeglassRepo eyeglass)
        {
           _eyeglass = eyeglass;
        }

        public IList<Eyeglass> Eyeglass { get;set; } = default!;


        public  void OnGet()
        {
            if (_eyeglass.GetEyeglass() != null)
            {
                Eyeglass = _eyeglass.GetEyeglass().OrderByDescending(c => c.CreatedDate).ToList();
                
            }
        }
    }
}
