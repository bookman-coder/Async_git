using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
     internal sealed class Dto
    {

        public Dto(string id,string name)
        {
            Id = id;
            Name = name;

        }

        public string Id { get; }
        public string Name { get; }
    }
}
