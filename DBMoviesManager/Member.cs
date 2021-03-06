﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMoviesManager
{
    class Member
    {
        public Member()
        {
            ID = 0;
            Name = "";
            Dob = default;
            MemberType = 0;
        }
        public Member(int id, string name, DateTime dob, int memberType)
        {
            ID = id;
            Name = name;
            Dob = dob;
            MemberType = memberType;
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime Dob { get; set; }
        public int MemberType { get; set; }
    }
}
