using System;
using System.ComponentModel.DataAnnotations;

namespace CA.Common.ViewModels
{
    public class MessageView
    {
        public DateTime PostedTime { get; set; }

        [Required(ErrorMessage = "Введите сначала сообщение")]
        [MaxLength(500, ErrorMessage = "Максимальная длина сообщения 500 символов")]
        public string Message { get; set; }
        //public User User { get; set; }
        public int UserId { get; set; }
    }
}
