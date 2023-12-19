using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObject;
using Repo.Interface;

namespace Eyeglasses_NguyenThienCaoDuy.Pages.EyeglassManager
{
    public class CreateModel : PageModel
    {
        private readonly IEyeglassRepo _eyeglass;
        private readonly ILensTypeRepo _lensType;

        public CreateModel(IEyeglassRepo eyeglass, ILensTypeRepo lensType)
        {
           _eyeglass = eyeglass;
            _lensType = lensType;
        }

        public IActionResult OnGet()
        {
        ViewData["LensTypeId"] = new SelectList(_lensType.GetLensType(), "LensTypeId", "LensTypeName");
            return Page();
        }

        [BindProperty]
        public Eyeglass Eyeglass { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _eyeglass.GetEyeglass() == null || Eyeglass == null)
            {
                return Page();
            }

            _eyeglass.AddNewEyeglass(Eyeglass);

            return RedirectToPage("./Index");
        }
    }
}
