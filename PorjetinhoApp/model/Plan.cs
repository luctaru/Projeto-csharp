using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorjetinhoApp
{
    class Plan
    {
        private int id;
        private string name;
        private PlanType type;
        private User responsible;
        private PlanStatus status;
        private DateTime startDate;
        private DateTime endDate;
        private string description;
        private decimal cost;

        private IDictionary<int, User> dictionaryStakeholder = new Dictionary<int, User>();

        public IDictionary<int, User> DictionaryStakeholder
        {
            get
            {
                return new ReadOnlyDictionary<int, User>(dictionaryStakeholder);
            }
        }

        internal void searchStakeholders(int id)
        {
            PlanDAO c = new PlanDAO();
            this.dictionaryStakeholder = c.getStakeholders(id);
        }

        public override string ToString()
        {
            return $"Plano: {name}, Tipo: {type}, Status: {status},Interessados: {string.Join(", ", dictionaryStakeholder.Values)}";
        }

        public Plan(string name, int id, PlanType type, User responsible,
            PlanStatus status, DateTime startDate, DateTime endDate, string description,
            decimal cost)
        {
            this.name = name;
            this.id = id;
            this.type = type;
            this.responsible = responsible;
            this.status = status;
            this.startDate = startDate;
            this.endDate = endDate;
            this.description = description;
            this.cost = cost;

            this.searchStakeholders(this.id);
        }

        public Plan() { }

        public string Name { get => name; set => name = value; }
        public int Id { get => id; set => id = value; }

        public PlanType Type { get => type; set => type = value; }

        public User Responsible { get => responsible; set => responsible = value; }

        public PlanStatus Status { get => status; set => status = value; }

        public DateTime StartDate { get => startDate; set => startDate = value; }

        public DateTime EndDate { get => endDate; set => endDate = value; }

        public string Description { get => description; set => description = value; }

        public decimal Cost { get => cost; set => cost = value; }
    }
}
