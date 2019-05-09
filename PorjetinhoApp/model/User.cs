using System;
using System.Collections.Generic;
using System.Text;

namespace PorjetinhoApp
{
    class User
    {
        private string name;
        private int id;
        private DateTime registerDate;
        private DateTime lastChangedDate;
        private Boolean canCreatePlan;
        private Boolean removed;

        public User() { }

        public User(string name, int id, DateTime registerDate, DateTime lastChangedDate, Boolean canCreatePlan, Boolean removed)
        {
            this.name = name;
            this.id = id;
            this.registerDate = registerDate;
            this.lastChangedDate = lastChangedDate;
            this.canCreatePlan = canCreatePlan;
            this.removed = removed;
        }

        public string Name { get => name; set => name = value; }

        public int Id { get => id; set => id = value; }

        public DateTime RegisterDate { get => registerDate; set => registerDate = value; }

        public DateTime LastChangeDate { get => lastChangedDate; set => lastChangedDate = value; }

        public Boolean CanCreatePlan { get => canCreatePlan; set => canCreatePlan = value; }
        
        public Boolean Removed { get => removed; set => removed = value; }

        public override string ToString()
        {
            return "Usuario: " + this.name + ", ID: " + this.id;
        }
    }
}
