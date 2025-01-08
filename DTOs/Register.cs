﻿using System.ComponentModel.DataAnnotations;
namespace JWTApiPractice.DTOs
{


    public sealed record Register
    {

        [Required(ErrorMessage = "Kullanıcı adı zorunludur")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Kullanıcı adı 3-50 karakter arasında olmalıdır")]
        [RegularExpression(@"^[a-zA-Z0-9._]+$", ErrorMessage = "Kullanıcı adı sadece harf, rakam, nokta ve alt çizgi içerebilir")]
        public string UserName { get; init; } = string.Empty;

        [Required(ErrorMessage = "E-posta adresi zorunludur")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz")]
        [StringLength(100, ErrorMessage = "E-posta adresi 100 karakterden uzun olamaz")]
        public string Email { get; init; } = string.Empty;

        [Required(ErrorMessage = "Şifre zorunludur")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Şifre en az 6 karakter olmalıdır")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{6,}$",
            ErrorMessage = "Şifre en az bir büyük harf, bir küçük harf, bir rakam ve bir özel karakter içermelidir")]
        public string Password { get; init; } = string.Empty;

        [Required(ErrorMessage = "Şifre tekrarı zorunludur")]
        [Compare("Password", ErrorMessage = "Şifreler eşleşmiyor")]
        public string ConfirmPassword { get; init; } = string.Empty;

        [Required(ErrorMessage = "Ad alanı zorunludur")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Ad 2-50 karakter arasında olmalıdır")]
        [RegularExpression(@"^[a-zA-ZğüşıöçĞÜŞİÖÇ\s]+$", ErrorMessage = "Ad sadece harf içerebilir")]
        public string FirstName { get; init; } = string.Empty;

        [Required(ErrorMessage = "Soyad alanı zorunludur")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Soyad 2-50 karakter arasında olmalıdır")]
        [RegularExpression(@"^[a-zA-ZğüşıöçĞÜŞİÖÇ\s]+$", ErrorMessage = "Soyad sadece harf içerebilir")]
        public string LastName { get; init; } = string.Empty;

        [Required(ErrorMessage = "Doğum tarihi zorunludur")]
        [DataType(DataType.Date)]
        [Display(Name = "Doğum Tarihi")]
        [Range(typeof(DateTime), "1900-01-01", "2010-12-31", ErrorMessage = "Geçerli bir doğum tarihi giriniz")]
        public DateTime BirthDate { get; init; }

        [Phone(ErrorMessage = "Geçerli bir telefon numarası giriniz")]
        [RegularExpression(@"^(\+90|0)?[1-9][0-9]{9}$", ErrorMessage = "Geçerli bir telefon numarası giriniz")]
        public string? PhoneNumber { get; init; }

        [Required(ErrorMessage = "Kullanıcı sözleşmesini kabul etmelisiniz")]
        [Range(typeof(bool), "true", "true", ErrorMessage = "Kullanıcı sözleşmesini kabul etmelisiniz")]
        public bool AcceptTerms { get; init; }

        [StringLength(200, ErrorMessage = "Adres 200 karakterden uzun olamaz")]
        public string? Address { get; init; }

        public DateTime RegisterDate { get; init; } = DateTime.UtcNow;
  
        public string? IpAddress { get; init; }
    }
}