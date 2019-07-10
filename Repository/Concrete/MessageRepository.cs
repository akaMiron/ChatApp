using CA.Domain.Entities;
using Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Repository.Concrete
{
    public class MessageRepository : GenericRepository<Message>, IMessageRepository
    {
        public MessageRepository(Entities context) : base(context)
        {
        }

        public IEnumerable<Message> GetMessagesWithAuthors(int pageIndex, int pageSize = 10)
        {
            return Entities.Message
                .Include(c => c.User)
                .OrderBy(c => c.UserId)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public Entities Entities
        {
            get { return Context as Entities; }

        }
    }
}
