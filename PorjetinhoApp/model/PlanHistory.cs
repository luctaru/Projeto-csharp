using System;
using System.Collections.Generic;
using System.Text;

namespace PorjetinhoApp.model
{
    class PlanHistory
    {
        private int id;
        private Plan plan;
        private PlanStatus status;
        private DateTime date;

        public override string ToString()
        {
            return $"ID: {id}, Plano: {plan.Name}, Status: {status.Name}, Data: {date}";
        }

        public PlanHistory(int id, Plan plan, PlanStatus status, DateTime date)
        {
            this.id = id;
            this.plan = plan;
            this.status = status;
            this.date = date;
        }

        public int Id { get => id; set => id = value; }

        public Plan Plan { get => plan; set => plan = value; }

        public PlanStatus Status { get => status; set => status = value; }

        public DateTime StartDate { get => date; set => date = value; }
    }

    
}
