using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BusinessObject
{
    public partial class Eyeglass
    {
        public int EyeglassesId { get; set; }
        [Required(ErrorMessage = "EyeglassesName is required")]
        [StringLength(120, MinimumLength = 10, ErrorMessage = "The length of eyeglasses name is from 10 to 120 character")]
        public string EyeglassesName { get; set; } = null!;
        [Required(ErrorMessage = "EyeglassesDiscription is required")]
        [StringLength(300, MinimumLength = 10, ErrorMessage = "The length of eyeglasses description is from 10 to 300 character")]
        public string? EyeglassesDescription { get; set; }
        public string? FrameColor { get; set; }
        public decimal? Price { get; set; }
        [Required(ErrorMessage = "Please input Quantity")]
        [Range(0, 999, ErrorMessage = "Quantity must greater or equal than 0 and less or equal than 999")]
        public int? Quantity { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? LensTypeId { get; set; }

        public virtual LensType? LensType { get; set; }
    }
}
