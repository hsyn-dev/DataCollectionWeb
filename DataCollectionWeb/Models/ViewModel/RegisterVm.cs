using System.ComponentModel.DataAnnotations;

namespace DataCollectionWeb.Models.ViewModel
{
    public class RegisterVm
    {
     
        //public int UserId { get; set; }
        [Required(ErrorMessage = "این فیلد اجباری است ")]

        [StringLength(50)]
        public string? Age { get; set; }

        [Required(ErrorMessage = "این فیلد اجباری است ")]
        [StringLength(50)]
        public string? Gender { get; set; }
        [Required(ErrorMessage = "این فیلد اجباری است ")]



        [StringLength(200)]
        public string? Lof { get; set; }
    }
}
