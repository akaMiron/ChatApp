using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CA.Domain.Entities;

namespace CA.Common.ViewModels
{
    public class MessageViewModel
    {
        public int MessageId { get; set; }
        public string Message1 { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
