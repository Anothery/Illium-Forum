using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Content
{
    public class MySQLContentRepository : IContentRepository
    {
        private ContentContext db;

        public MySQLContentRepository(ContentContext context)
        {
            db = context;
        }

        public IEnumerable<Subject> GetSubjectList()
        {
            return db.Subjects.OrderBy(p => p.Name);
        }
    }
}
