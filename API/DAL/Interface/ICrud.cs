using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface ICrud<CLASS, ID, RESULT>
    {
        RESULT Add(CLASS data);
        bool Delete(ID id);
        List<CLASS> GetAll();
        CLASS Get(ID id);
        RESULT Update(CLASS data);
    }
}
