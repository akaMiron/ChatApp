using CA.Domain.Entities;
using System.Collections.Generic;

namespace CA.Common.ViewModels
{
    public class ChatView
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public IEnumerable<Message> Messages { get; set; }
    }
}
