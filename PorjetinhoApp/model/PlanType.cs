using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorjetinhoApp
{
    class PlanType
    {
        private string name;
        private int id;

        public PlanType() { }

        public PlanType(string name, int id)
        {
            this.name = name;
            this.id = id;
        }

        public string Name { get => name; set => name = value; }
        public int Id { get => id; set => id = value; }

        public override string ToString()
        {
            return "[PlanType: " + this.name + ", ID: " + this.id + "]";
        }

    }
}
