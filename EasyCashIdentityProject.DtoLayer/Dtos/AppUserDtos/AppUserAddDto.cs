using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIdentityProject.DtoLayer.Dtos.AppUserDtos
{
    public class AppUserAddDto
    {
        //[Required(ErrorMessage ="Ad alanı zorunludur.")]
        //[Display(Name ="İsim:")]
        //[MaxLength(30,ErrorMessage ="En Fazla 30 karakter olabilir.")]
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
    //ad,soyad,username,confirmpassaword
}
