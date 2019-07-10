using CA.Domain.Entities;
using System.Collections.Generic;

namespace Repository.Abstract
{
    public interface IMessageRepository : IRepository<Message>
    {
        IEnumerable<Message> GetMessagesWithAuthors(int pageIndex, int pageSize = 10);
    }
}
