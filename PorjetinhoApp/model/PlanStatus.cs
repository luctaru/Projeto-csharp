using System;
using System.Collections.Generic;
using System.Text;

namespace PorjetinhoApp
{
    class PlanStatus
    {
        private string name;
        private int id;

        public PlanStatus(string name, int id)
        {
            this.name = name;
            this.id = id;
        }

        public PlanStatus() { }

        public string Name { get => name; set => name = value; }
        public int Id { get => id; set => id = value; }

        public override string ToString()
        {
            return "Status: " + this.name + ", ID: " + this.id;
        }
    }
}
