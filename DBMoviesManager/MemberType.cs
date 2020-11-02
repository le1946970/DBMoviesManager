using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMoviesManager
{
    class MemberType : Member
    {
        public MemberType() : base()
        {
            TypeID = 0;
            TypeName = "";
            TypeDescription = "";
        }
        public MemberType(int typeId, string typeName, string typeDescription, int id, string name, DateTime dob, int memberType) : base(id, name, dob, memberType)
        {
            TypeID = typeId;
            TypeName = typeName;
            TypeDescription = typeDescription;
        }

        public int TypeID { get; set; }
        public string TypeName { get; set; }
        public string TypeDescription { get; set; }
    }
}
