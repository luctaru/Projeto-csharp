using System;
using System.Collections.Generic;
using System.Text;

namespace PorjetinhoApp.model
{
    class PlanStakeholder
    {
        private int id;
        private Plan plan;
        private User user;

        public PlanStakeholder() { }

        public PlanStakeholder(int id, Plan plan, User user)
        {
            this.id = id;
            this.plan = plan;
            this.user = user;
        }

        public int Id { get => id; set => id = value; }

        public Plan Plan { get => plan; set => plan = value; }

        public User User { get => user; set => user = value; }

        public override string ToString()
        {
            return "ID: "+ this.id +", Plano: " + this.plan.Name + ", Usuario Interessado: " + this.user.Name;
        }
    }
}
