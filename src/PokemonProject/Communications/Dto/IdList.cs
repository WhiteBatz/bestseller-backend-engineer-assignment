using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Communications.Dto
{
    [CollectionDataContract]
    public class IdList : List<int>
    {
        public IdList()
        {
        }

        public IdList(IEnumerable<int> ids) : base(ids)
        {
        }
    }
}
