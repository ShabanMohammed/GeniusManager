using System.ComponentModel.DataAnnotations;

namespace GeniusManager.Application.DTO
{
    public class LookupDto
    {
        public long Id { get; set; }
       [Required(ErrorMessage = "هذا الحقل مطلوب")]
       [MaxLength(50, ErrorMessage = "يجب ألا يتجاوز الطول 100 حرف")]
        public string Name { get; set; } = string.Empty;

        //اضافة امر التحقق من التكرار   

    }
}