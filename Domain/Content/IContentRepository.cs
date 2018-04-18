using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Content
{
    public interface IContentRepository
    {
        IEnumerable<Subject> GetSubjectList();
    }
}
