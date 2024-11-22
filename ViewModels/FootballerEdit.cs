﻿using System.ComponentModel.DataAnnotations;
using Test66bit.Enums;

namespace Test66bit.ViewModels
{
    public class FootballerEdit
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Имя обязательно для заполнения")]
        [StringLength(50, ErrorMessage = "Имя не может превышать 50 символов")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Фамилия обязательна для заполнения")]
        [StringLength(50, ErrorMessage = "Фамилия не может превышать 50 символов")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Пол обязателен для выбора")]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Дата рождения обязательна для указания")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Необходимо указать название команды")]
        [StringLength(100, ErrorMessage = "Название команды не может превышать 100 символов")]
        public string TeamName { get; set; }

        [Required(ErrorMessage = "Страна обязательна для выбора")]
        public Country Country { get; set; }
    }
}
