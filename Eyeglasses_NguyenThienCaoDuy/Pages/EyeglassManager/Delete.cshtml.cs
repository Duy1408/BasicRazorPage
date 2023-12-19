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
    public class DeleteModel : PageModel
    {
        private readonly IEyeglassRepo _eyeglass;
        private readonly ILensTypeRepo _lensType;

        public DeleteModel(IEyeglassRepo eyeglass, ILensTypeRepo lensType)
        {
            _eyeglass = eyeglass;
            _lensType = lensType;
        }

        [BindProperty]
      public Eyeglass Eyeglass { get; set; } = default!;

        public  IActionResult OnGet(int id)
        {
            if (id == null || _eyeglass.GetEyeglass() == null)
            {
                return NotFound();
            }

            var eyeglass = _eyeglass.GetEyeglassById(id);

            if (eyeglass == null)
            {
                return NotFound();
            }
            else 
            {
                Eyeglass = eyeglass;
            }
            return Page();
        }

        public IActionResult OnPost(int id)
        {
            if (id == null || _eyeglass.GetEyeglass() == null)
            {
                return NotFound();
            }
            var eyeglass = _eyeglass.GetEyeglassById(id);

            if (eyeglass != null)
            {
                Eyeglass = eyeglass;
             _eyeglass.DeleteEyeglass(eyeglass);
            }

            return RedirectToPage("./Index");
        }
    }
}
