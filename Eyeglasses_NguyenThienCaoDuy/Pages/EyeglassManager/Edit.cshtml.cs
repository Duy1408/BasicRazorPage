using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObject;
using Repo.Interface;

namespace Eyeglasses_NguyenThienCaoDuy.Pages.EyeglassManager
{
    public class EditModel : PageModel
    {
        private readonly IEyeglassRepo _eyeglass;
        private readonly ILensTypeRepo _lensType;

        public EditModel(IEyeglassRepo eyeglass, ILensTypeRepo lensType)
        {
            _eyeglass = eyeglass;
            _lensType = lensType;
        }

        [BindProperty]
        public Eyeglass Eyeglass { get; set; } = default!;

        public IActionResult OnGet(int id)
        {
            if (id == null || _eyeglass.GetEyeglass() == null)
            {
                return NotFound();
            }

            var eyeglass =  _eyeglass.GetEyeglass().Where(c => c.EyeglassesId == id).FirstOrDefault();
            if (eyeglass == null)
            {
                return NotFound();
            }
            Eyeglass = eyeglass;
           ViewData["LensTypeId"] = new SelectList(_lensType.GetLensType(), "LensTypeId", "LensTypeName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            _eyeglass.UpdateEyeglass(Eyeglass);
            return RedirectToPage("./Index");
        }

       
    }
}
