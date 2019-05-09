using System;
using System.Collections.Generic;
using System.Text;

namespace PorjetinhoApp.model
{
    class UserHistory
    {
        private int id;
        private User user;
        private Boolean status;
        private Boolean createNewPlan;
        private DateTime date;

        public override string ToString()
        {
            string statusAux = "";
            string createNewAux = "";
            if (!status)
            {
                statusAux = "Removido";
            } else
            {
                statusAux = "Ativo";
            }
            if (!createNewPlan)
            {
                createNewAux = "Sem permissao";
            } else
            {
                createNewAux = "Com permissao";
            }

            return $"ID: {id}, Usuario: {user.Name}, Status: {statusAux}, Criar Novos Planos: {createNewAux}, Data: {date}";
        }

        public UserHistory(int id, User user, Boolean status, Boolean createNewPlan, DateTime date)
        {
            this.id = id;
            this.user = user;
            this.status = status;
            this.createNewPlan = createNewPlan;
            this.date = date;
        }

        public int Id { get => id; set => id = value; }

        public User User { get => user; set => user = value; }

        public Boolean Status { get => status; set => status = value; }

        public Boolean CreateNew { get => createNewPlan; set => createNewPlan = value; }

        public DateTime StartDate { get => date; set => date = value; }
    }

}
