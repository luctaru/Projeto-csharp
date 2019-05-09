using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using PorjetinhoApp.DAO;
using PorjetinhoApp.model;

namespace PorjetinhoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int menu = Menu();
            if(menu == 7)
            {
                SubmenuStake();
            } else if (menu != 0 && menu != 7)
            {
                Submenu(menu);
            }
        }

        public static int Menu()
        {
            Console.WriteLine("\n1-Planos\n2-Usuarios\n3-Tipos de Planos\n4-Status de Planos\n5-Historico de Planos\n6-Historico de Usuarios\n7-Interessados\n0-Sair");
            int menu = Int32.Parse(Console.ReadLine());
            
            Console.Clear();
            switch (menu)
            {
                case 1:
                    Console.WriteLine("PLANOS");
                    return menu;
                    break;
                case 2:
                    Console.WriteLine("USUARIOS");
                    return menu;
                    break;
                case 3:
                    Console.WriteLine("TIPOS");
                    return menu;
                    break;
                case 4:
                    Console.WriteLine("STATUS");
                    return menu;
                    break;
                case 5:
                    Console.WriteLine("HISTORICO DE PLANOS");
                    ReadPlanHistory();
                    return menu;
                case 6:
                    Console.WriteLine("HISTORICO DE USUARIOS");
                    ReadUserHistory();
                    return menu;
                case 7:
                    Console.WriteLine("RELACOES ENTRE PLANOS E INTERESSADOS");
                    return menu;
                case 0:
                    return 0;
                default:
                    return menu;
                    break;
            }
        }

        public static void Submenu(int menu)
        {
            Console.WriteLine("\n1-Consultar Todos\n2-Consultar um\n3-Inserir Dados\n4-Atualizar Dados\n5-Excluir\n0-Voltar");
            int sub = Int32.Parse(Console.ReadLine());
            switch (sub)
            {
                case 1:
                    Read(menu);
                    break;
                case 2:
                    ReadOne(menu);
                    break;
                case 3:
                    Insert(menu);
                    break;
                case 4:
                    Update(menu);
                    break;
                case 5:
                    Exclude(menu);
                    break;
                case 0:
                    Console.Clear();
                    int aux = Menu();
                    if (aux == 7)
                    {
                        SubmenuStake();
                    } else if(aux != 7 && aux != 0)
                    {
                        Submenu(aux);
                    }
                    break;
                default:
                    Console.WriteLine("DIGITE UM VALOR VALIDO");
                    break;
            }
        }

        public static void SubmenuStake()
        {
            Console.WriteLine("\n1-Consultar Todos\n2-Consultar por usuario\n3-Consultar por plano\n4-Inserir usuario interessado em plano\n5-Excluir\n0-Voltar");
            int sub = Int32.Parse(Console.ReadLine());
            switch (sub)
            {
                case 1:
                    ReadRelations();
                    break;
                case 2:
                    ReadByUser();
                    break;
                case 3:
                    ReadByPlan();
                    break;
                case 4:
                    InsertRelation();
                    break;
                case 5:
                    ExcludeRelation();
                    break;
                case 0:
                    Console.Clear();
                    int aux = Menu();
                    if (aux == 7)
                    {
                        SubmenuStake();
                    }
                    else if (aux != 7 && aux != 0)
                    {
                        Submenu(aux);
                    }
                    break;
                default:
                    Console.WriteLine("DIGITE UM VALOR VALIDO");
                    break;
            }
        }

        private static IList<Plan> planList = new List<Plan>();

        private static IList<User> userList = new List<User>();

        private static IList<PlanType> typeList = new List<PlanType>();

        private static IList<PlanStatus> statusList = new List<PlanStatus>();

        private static IList<PlanHistory> planHistorysList = new List<PlanHistory>();

        private static IList<UserHistory> userHistoryList = new List<UserHistory>();

        private static IList<PlanStakeholder> planStakeList = new List<PlanStakeholder>();

        public static IList<Plan> ListPlan
        {
            get
            {
                return new ReadOnlyCollection<Plan>(planList);
            }
        }

        public static IList<User> ListUser
        {
            get
            {
                return new ReadOnlyCollection<User>(userList);
            }
        }

        public static IList<PlanType> ListType
        {
            get
            {
                return new ReadOnlyCollection<PlanType>(typeList);
            }
        }

        public static IList<PlanStatus> ListStatus
        {
            get
            {
                return new ReadOnlyCollection<PlanStatus>(statusList);
            }
        }

        public static IList<PlanHistory> ListPlanHistory
        {
            get
            {
                return new ReadOnlyCollection<PlanHistory>(planHistorysList);
            }
        }

        public static IList<UserHistory> ListUserHistory
        {
            get
            {
                return new ReadOnlyCollection<UserHistory>(userHistoryList);
            }
        }

        public static IList<PlanStakeholder> ListPlanStake
        {
            get
            {
                return new ReadOnlyCollection<PlanStakeholder>(planStakeList);
            }
        }

        public static void ReadPlanHistory()
        {
            Console.Clear();
            PlanHistoryDAO ph = new PlanHistoryDAO();

            Console.WriteLine("\nHistórico de planos");
            planHistorysList = ph.getHistory();
            foreach (var item in ListPlanHistory)
            {
                Console.WriteLine("\n" + item);
            }
            SubmenuStake();
        }

        public static void ReadUserHistory()
        {
            Console.Clear();
            UserHistoryDAO uh = new UserHistoryDAO();

            Console.WriteLine("\nHistórico de planos");
            userHistoryList = uh.getHistory();
            foreach (var item in ListUserHistory)
            {
                Console.WriteLine("\n" + item);
            }

            SubmenuStake();
        }

        public static void ReadRelations()
        {
            Console.Clear();
            PlanStakeholderDAO psk = new PlanStakeholderDAO();

            Console.WriteLine("\nRelacoes de planos e interessados");
            planStakeList = psk.getRelations();
            foreach (var item in planStakeList)
            {
                Console.WriteLine(item);
            }
            SubmenuStake();
        }

        public static void ReadByUser()
        {
            Console.Clear();

            UserDAO userDAO = new UserDAO();
            PlanStakeholderDAO psk = new PlanStakeholderDAO();

            userList = userDAO.getUser();

            Console.WriteLine("\nEscolha o usuario: ");
            
            foreach (var item in userList)
            {
                Console.WriteLine(item.Id + "-" + item.Name);
            }
            Console.WriteLine("0-Cancelar");
            int userId = Int32.Parse(Console.ReadLine());
            if(userId == 0)
            {
                Console.WriteLine("OPERACAO CANCELADA!");
                SubmenuStake();
                return;
            }
            Console.Clear();
            planStakeList = psk.getByUserId(userId);

            foreach(var item in planStakeList)
            {
                Console.WriteLine("\n" + item);
            }
            SubmenuStake();
        }

        public static void ReadByPlan()
        {
            Console.Clear();

            PlanDAO planDAO = new PlanDAO();
            PlanStakeholderDAO psk = new PlanStakeholderDAO();

            planList = planDAO.getPlans();

            Console.WriteLine("\nEscolha o plano: ");

            foreach (var item in planList)
            {
                Console.WriteLine(item.Id + "-" + item.Name);
            }
            Console.WriteLine("0-Cancelar");
            int planId = Int32.Parse(Console.ReadLine());
            if (planId == 0)
            {
                Console.WriteLine("OPERACAO CANCELADA!");
                SubmenuStake();
                return;
            }
            Console.Clear();
            planStakeList = psk.getByPlanId(planId);

            foreach (var item in planStakeList)
            {
                Console.WriteLine("\n" + item);
            }
            SubmenuStake();
        }

        public static void ExcludeRelation()
        {
            Console.Clear();

            PlanStakeholderDAO psk = new PlanStakeholderDAO();

            planStakeList = psk.getRelations();

            Console.WriteLine("\nEscolha qual relacao deseja remover: ");

            foreach (var item in planStakeList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("0-Cancelar");
            int stakeId = Int32.Parse(Console.ReadLine());
            if (stakeId == 0)
            {
                Console.WriteLine("OPERACAO CANCELADA!");
                SubmenuStake();
                return;
            }
            Console.Clear();

            psk.exclude(stakeId);
            SubmenuStake();
        }

        public static void InsertRelation()
        {
            Console.Clear();

            PlanDAO planDAO = new PlanDAO();
            UserDAO userDAO = new UserDAO();
            PlanStakeholderDAO psk = new PlanStakeholderDAO();

            planList = planDAO.getPlans();
            userList = userDAO.getUser();

            Console.WriteLine("\nEscolha o plano a ser relacionado: ");

            foreach (var item in planList)
            {
                Console.WriteLine(item.Id + "-" + item.Name);
            }
            
            int planId = Int32.Parse(Console.ReadLine());
            Console.Clear();

            Console.WriteLine("\nEscolha o usuario interessado no plano: ");

            foreach (var item in userList)
            {
                Console.WriteLine(item.Id + "-" + item.Name);
            }

            int userId = Int32.Parse(Console.ReadLine());

            Console.Clear();

            PlanStakeholder ps = new PlanStakeholder(0, planDAO.getOnePlan(planId), userDAO.getResponsible(userId));

            Console.WriteLine("\nConfirme seus dados: ");
            Console.WriteLine(ps);
            Console.WriteLine("\n1-Sim\n2-Nao");
            int confirm = Int32.Parse(Console.ReadLine());
            if (confirm == 1)
            {
                psk.insert(ps);
            }
            else
            {
                Console.WriteLine("\nOperacao cancelada!");
            }

            SubmenuStake();
        }

        public static void Read(int op)
        {
            Console.Clear();
            PlanDAO p = new PlanDAO();
            UserDAO u = new UserDAO();
            PlanTypeDAO pt = new PlanTypeDAO();
            PlanStatusDAO ps = new PlanStatusDAO();

            switch (op)
            {
                case 1:
                    Console.WriteLine("\nTodos os planos");
                    planList = p.getPlans();
                    foreach(var item in ListPlan)
                    {
                        Console.WriteLine("\n"+item);
                    }
                    break;
                case 2:
                    Console.WriteLine("\nTodos os usuarios");
                    userList = u.getUser();
                    foreach (var item in ListUser)
                    {
                        Console.WriteLine("\n" + item);
                    }
                    break;
                case 3:
                    Console.WriteLine("\nTodos os Tipos");
                    typeList = pt.getType();
                    foreach (var item in ListType)
                    {
                        Console.WriteLine("\n" + item);
                    }
                    break;
                case 4:
                    Console.WriteLine("\nTodos os Status");
                    statusList = ps.getStatus();
                    foreach (var item in ListStatus)
                    {
                        Console.WriteLine("\n" + item);
                    }
                    break;
            }

            Submenu(op);
        }

        public static void ReadOne(int op)
        {
            Console.Clear();
            PlanDAO p = new PlanDAO();
            UserDAO u = new UserDAO();
            PlanTypeDAO pt = new PlanTypeDAO();
            PlanStatusDAO ps = new PlanStatusDAO();

            string resp = "";
            string aux = "";

            switch (op)
            {
                case 1:
                    Console.WriteLine("\nDigite o nome do plano");
                    resp = Console.ReadLine();
                    planList = p.getPlans();
                    aux = string.Join(" ", planList.Where(i => i.Name.Contains(resp)).ToList());
                    Console.WriteLine("\n"+ aux);
                    break;
                case 2:
                    Console.WriteLine("\nDigite o nome do usuario");
                    resp = Console.ReadLine();
                    userList = u.getUser();
                    aux = string.Join(" ", userList.Where(i => i.Name.Contains(resp)).ToList());
                    Console.WriteLine("\n" + aux);
                    break;
                case 3:
                    Console.WriteLine("\nDigite o nome do Tipo de Plano");
                    resp = Console.ReadLine();
                    typeList = pt.getType();
                    aux = string.Join(" ", typeList.Where(i => i.Name.Contains(resp)).ToList());
                    Console.WriteLine("\n" + aux);
                    break;
                case 4:
                    Console.WriteLine("\nDigite o nome do Status do Plano");
                    resp = Console.ReadLine();
                    statusList = ps.getStatus();
                    aux = string.Join(" ", statusList.Where(i => i.Name.Contains(resp)).ToList());
                    Console.WriteLine("\n" + aux);
                    break;
            }

            Submenu(op);
        }

        public static void Insert(int op)
        {
            Console.Clear();
            PlanDAO p = new PlanDAO();
            UserDAO u = new UserDAO();
            PlanTypeDAO pt = new PlanTypeDAO();
            PlanStatusDAO ps = new PlanStatusDAO();
            
            string aux = "";
            int confirm = 0;
            int exists = 0;

            switch (op)
            {
                case 1:
                    planList = p.getPlans();
                    typeList = pt.getType();
                    userList = u.getUser();
                    statusList = ps.getStatus();
                    Console.WriteLine("\nInsira o nome do plano: ");
                    string planResp = Console.ReadLine();
                    
                    foreach(var item in planList)
                    {
                        if (item.Name.Contains(planResp))
                        {
                            Console.WriteLine("\nJa existe um plano com esse nome");
                            exists = 1;
                            break;
                        }
                    }
                    if(exists == 1)
                    {
                        break;
                    }
                    Console.Clear();

                    Console.WriteLine("\nEscolha um tipo de plano: ");
                    foreach(var item in typeList)
                    {
                        Console.WriteLine(item.Id+"-"+item.Name);
                    }
                    int typeId = Int32.Parse(Console.ReadLine());
                    Console.Clear();

                    Console.WriteLine("\nEscolha um responsavel: ");
                    foreach (var item in userList)
                    {
                        Console.WriteLine(item.Id + "-" + item.Name);
                    }
                    int userId = Int32.Parse(Console.ReadLine());
                    Console.Clear();

                    Console.WriteLine("\nEscolha um status para o plano: ");
                    foreach (var item in statusList)
                    {
                        Console.WriteLine(item.Id + "-" + item.Name);
                    }
                    int statusId = Int32.Parse(Console.ReadLine());
                    Console.Clear();

                    Console.WriteLine("\nInsira a data de inicio do plano: ");
                    DateTime stDate = DateTime.Parse(Console.ReadLine());
                    Console.Clear();

                    Console.WriteLine("\nInsira a data de fim do plano: ");
                    DateTime edDate = DateTime.Parse(Console.ReadLine());
                    Console.Clear();

                    Console.WriteLine("\nInsira uma descrição do projeto: ");
                    string desc = Console.ReadLine();
                    Console.Clear();

                    Console.WriteLine("\nInsira o custo do plano: ");
                    decimal ct = Decimal.Parse(Console.ReadLine());
                    Console.Clear();

                    Plan pInsert = new Plan(planResp, 0, pt.getOneType(typeId), u.getResponsible(userId), ps.getOneStatus(statusId), stDate, edDate, desc, ct);

                    Console.WriteLine("\nConfirme seus dados: ");
                    Console.WriteLine(pInsert);
                    Console.WriteLine("\n1-Sim\n2-Nao");
                    confirm = Int32.Parse(Console.ReadLine());
                    if(confirm == 1)
                    {
                        p.insertPlan(pInsert);
                    } else
                    {
                        Console.WriteLine("\nOperacao cancelada!");
                    }
                    break;
                case 2:
                    userList = u.getUser();
                    Console.WriteLine("\nInsira o nome do usuario: ");
                    string userName = Console.ReadLine();

                    foreach (var item in userList)
                    {
                        if (item.Name.Contains(userName))
                        {
                            Console.WriteLine("\nJa existe um usuario com esse nome");
                            exists = 1;
                            break;
                        }
                    }
                    if (exists == 1)
                    {
                        break;
                    }
                    Console.Clear();

                    Console.WriteLine("\nEscolha se o usuario pode criar planos: \n1-Sim\n2-Nao");
                    int auxUser = Int32.Parse(Console.ReadLine());
                    bool canCreate = false;
                    if (auxUser == 1)
                    {
                        canCreate = true;
                    } else
                    {
                        canCreate = false;
                    }
                    Console.Clear();

                    User uInsert = new User(userName, 0, DateTime.Now, DateTime.Now, canCreate, false);

                    Console.WriteLine("\nConfirme seus dados: ");
                    Console.WriteLine(uInsert);
                    Console.WriteLine("\n1-Sim\n2-Nao");
                    confirm = Int32.Parse(Console.ReadLine());
                    if (confirm == 1)
                    {
                        u.insertUser(uInsert);
                    }
                    else
                    {
                        Console.WriteLine("\nOperacao cancelada!");
                    }

                    break;
                case 3:
                    typeList = pt.getType();
                    Console.WriteLine("\nInsira o nome do usuario: ");
                    string typeName = Console.ReadLine();

                    foreach (var item in typeList)
                    {
                        if (item.Name.Contains(typeName))
                        {
                            Console.WriteLine("\nJa existe um tipo de plano com esse nome");
                            exists = 1;
                            break;
                        }
                    }
                    if (exists == 1)
                    {
                        break;
                    }
                    Console.Clear();

                    PlanType typeInsert = new PlanType(typeName, 0);

                    Console.WriteLine("\nConfirme seus dados: ");
                    Console.WriteLine(typeInsert);
                    Console.WriteLine("\n1-Sim\n2-Nao");
                    confirm = Int32.Parse(Console.ReadLine());
                    if (confirm == 1)
                    {
                        pt.insertType(typeInsert);
                    }
                    else
                    {
                        Console.WriteLine("\nOperacao cancelada!");
                    }
                    break;
                case 4:
                    statusList = ps.getStatus();
                    Console.WriteLine("\nInsira o nome do status: ");
                    string statusName = Console.ReadLine();

                    foreach (var item in statusList)
                    {
                        if (item.Name.Contains(statusName))
                        {
                            Console.WriteLine("\nJa existe um status de plano com esse nome");
                            exists = 1;
                            break;
                        }
                    }
                    if (exists == 1)
                    {
                        break;
                    }
                    Console.Clear();

                    PlanStatus stInsert = new PlanStatus(statusName, 0);

                    Console.WriteLine("\nConfirme seus dados: ");
                    Console.WriteLine(stInsert);
                    Console.WriteLine("\n1-Sim\n2-Nao");
                    confirm = Int32.Parse(Console.ReadLine());
                    if (confirm == 1)
                    {
                        ps.insertStatus(stInsert);
                    }
                    else
                    {
                        Console.WriteLine("\nOperacao cancelada!");
                    }
                    break;
            }

            Submenu(op);
        }

        public static void Update(int op)
        {
            Console.Clear();
            PlanDAO p = new PlanDAO();
            UserDAO u = new UserDAO();
            PlanTypeDAO pt = new PlanTypeDAO();
            PlanStatusDAO ps = new PlanStatusDAO();
            
            string aux = "";
            int confirm = 0;
            int exists = 0;

            switch (op)
            {
                case 1:
                    planList = p.getPlans();
                    typeList = pt.getType();
                    userList = u.getUser();
                    statusList = ps.getStatus();
                    Console.WriteLine("\nInsira o nome do plano a ser modificado: ");
                    string planName = Console.ReadLine();
                    int idType;
                    int idUser;
                    int idStatus;
                    DateTime sDate;
                    DateTime eDate;
                    string desc;
                    decimal cost;

                    Plan original = new Plan();

                    foreach (var item in planList)
                    {
                        if (item.Name.Contains(planName))
                        {
                            original = item;
                            exists = 1;
                            break;
                        }
                    }
                    if (exists == 0)
                    {
                        Console.WriteLine("\nNao existe um plano com esse nome");
                        break;
                    }
                    Console.Clear();

                    Console.WriteLine("\nQuer modificar o nome do plano?");
                    Console.WriteLine("\n1-Sim\n2-Nao");
                    confirm = Int32.Parse(Console.ReadLine());
                    if (confirm == 1)
                    {
                        Console.WriteLine("\nDigite o novo nome: ");
                        planName = Console.ReadLine();
                    } else
                    {
                        planName = original.Name;
                    }
                    Console.Clear();

                    Console.WriteLine("\nQuer modificar o tipo do plano?");
                    Console.WriteLine("\n1-Sim\n2-Nao");
                    confirm = Int32.Parse(Console.ReadLine());
                    if (confirm == 1)
                    {
                        Console.WriteLine("\nEscolha o novo tipo: ");
                        foreach(var item in typeList)
                        {
                            Console.WriteLine(item.Id + "-" + item.Name);
                        }
                        idType = Int32.Parse(Console.ReadLine());

                    } else
                    {
                        idType = original.Type.Id;
                    }
                    Console.Clear();

                    Console.WriteLine("\nQuer modificar o responsavel do plano?");
                    Console.WriteLine("\n1-Sim\n2-Nao");
                    confirm = Int32.Parse(Console.ReadLine());
                    if (confirm == 1)
                    {
                        Console.WriteLine("\nEscolha o novo responsavel: ");
                        foreach (var item in userList)
                        {
                            Console.WriteLine(item.Id + "-" + item.Name);
                        }
                        idUser = Int32.Parse(Console.ReadLine());

                    } else
                    {
                        idUser = original.Responsible.Id;
                    }
                    Console.Clear();

                    Console.WriteLine("\nQuer modificar o status do plano?");
                    Console.WriteLine("\n1-Sim\n2-Nao");
                    confirm = Int32.Parse(Console.ReadLine());
                    if (confirm == 1)
                    {
                        Console.WriteLine("\nEscolha o novo status: ");
                        foreach (var item in statusList)
                        {
                            Console.WriteLine(item.Id + "-" + item.Name);
                        }
                        idStatus = Int32.Parse(Console.ReadLine());

                    } else
                    {
                        idStatus = original.Status.Id;
                    }
                    Console.Clear();

                    Console.WriteLine("\nQuer modificar a data de inicio do plano?");
                    Console.WriteLine("\n1-Sim\n2-Nao");
                    confirm = Int32.Parse(Console.ReadLine());
                    if (confirm == 1)
                    {
                        Console.WriteLine("\nEscolha a nova data: ");
                        sDate = DateTime.Parse(Console.ReadLine());
                    } else
                    {
                        sDate = original.StartDate;
                    }
                    Console.Clear();

                    Console.WriteLine("\nQuer modificar a data de fim do plano?");
                    Console.WriteLine("\n1-Sim\n2-Nao");
                    confirm = Int32.Parse(Console.ReadLine());
                    if (confirm == 1)
                    {
                        Console.WriteLine("\nEscolha a nova data: ");
                        eDate = DateTime.Parse(Console.ReadLine());
                    }
                    else
                    {
                        eDate = original.EndDate;
                    }
                    Console.Clear();

                    Console.WriteLine("\nQuer modificar a descricao do plano?");
                    Console.WriteLine("\n1-Sim\n2-Nao");
                    confirm = Int32.Parse(Console.ReadLine());
                    if (confirm == 1)
                    {
                        Console.WriteLine("\nDigite a nova descricao: ");
                        desc = Console.ReadLine();
                    } else
                    {
                        desc = original.Description;
                    }
                    Console.Clear();

                    Console.WriteLine("\nQuer modificar o custo do plano?");
                    Console.WriteLine("\n1-Sim\n2-Nao");
                    confirm = Int32.Parse(Console.ReadLine());
                    if (confirm == 1)
                    {
                        Console.WriteLine("\nEscolha o novo custo: ");
                        cost = Decimal.Parse(Console.ReadLine());
                    } else
                    {
                        cost = original.Cost;
                    }
                    Console.Clear();

                    Plan pInsert = new Plan(planName, original.Id, pt.getOneType(idType), u.getResponsible(idUser), ps.getOneStatus(idStatus), sDate, eDate, desc, cost);

                    Console.WriteLine("\nConfirme seus dados: ");
                    Console.WriteLine(pInsert);
                    Console.WriteLine("\n1-Sim\n2-Nao");
                    confirm = Int32.Parse(Console.ReadLine());
                    if (confirm == 1)
                    {
                        p.updatePlan(pInsert);
                    }
                    else
                    {
                        Console.WriteLine("\nOperacao cancelada!");
                    }

                    break;
                    //---------------------------------------------------------------------------------------------------------------------------------------
                case 2:
                    userList = u.getUser();
                    Console.WriteLine("\nInsira o nome do usuario a ser modificado: ");
                    string userName = Console.ReadLine();

                    User userOriginal = new User();

                    foreach (var item in userList)
                    {
                        if (item.Name.Contains(userName))
                        {
                            userOriginal = item;
                            exists = 1;
                            break;
                        }
                    }
                    if (exists == 0)
                    {
                        Console.WriteLine("\nNao existe um usuario com esse nome");
                        break;
                    }
                    Console.Clear();

                    Console.WriteLine("\nQuer modificar o nome do usuario?");
                    Console.WriteLine("\n1-Sim\n2-Nao");
                    confirm = Int32.Parse(Console.ReadLine());
                    if(confirm == 1)
                    {
                        Console.WriteLine("\nDigite o novo nome: ");
                        userName = Console.ReadLine();
                    } else
                    {
                        userName = userOriginal.Name;
                    }
                    Console.Clear();

                    Console.WriteLine("\nQuer modificar se o usuario pode criar planos?");
                    Console.WriteLine("\n1-Sim\n2-Nao");
                    confirm = Int32.Parse(Console.ReadLine());
                    int auxUser = 0;
                    bool canCreate = false;
                    if (confirm == 1)
                    {
                        Console.WriteLine("\nEscolha se o usuario pode criar planos: \n1-Sim\n2-Nao");
                        auxUser = Int32.Parse(Console.ReadLine());
                        if (auxUser == 1)
                        {
                            canCreate = true;
                        }
                        else
                        {
                            canCreate = false;
                        }
                    } else
                    {
                        canCreate = userOriginal.CanCreatePlan;
                    }
                    Console.Clear();

                    Console.WriteLine("\nQuer modificar se o usuario vai ser removido?");
                    Console.WriteLine("\n1-Sim\n2-Nao");
                    confirm = Int32.Parse(Console.ReadLine());
                    int auxRemoved = 0;
                    bool remo = false;
                    if (confirm == 1)
                    {
                        Console.WriteLine("\nEscolha se o usuario vai ser removido: \n1-Sim\n2-Nao");
                        auxRemoved = Int32.Parse(Console.ReadLine());
                        if (auxRemoved == 1)
                        {
                            remo = true;
                        }
                        else
                        {
                            remo = false;
                        }
                    }
                    else
                    {
                        remo = userOriginal.Removed;
                    }
                    Console.Clear();

                    User uInsert = new User(userName, userOriginal.Id, userOriginal.RegisterDate, DateTime.Now, canCreate, remo);

                    Console.WriteLine("\nConfirme seus dados: ");
                    Console.WriteLine(uInsert);
                    Console.WriteLine("\n1-Sim\n2-Nao");
                    confirm = Int32.Parse(Console.ReadLine());
                    if (confirm == 1)
                    {
                        u.insertUser(uInsert);
                    }
                    else
                    {
                        Console.WriteLine("\nOperacao cancelada!");
                    }

                    break;
                case 3:
                    typeList = pt.getType();
                    Console.WriteLine("\nInsira o nome do usuario a ser modificado: ");
                    string typeName = Console.ReadLine();

                    PlanType ptOriginal = new PlanType();

                    foreach (var item in typeList)
                    {
                        if (item.Name.Contains(typeName))
                        {
                            ptOriginal = item;
                             exists = 1;
                            break;
                        }
                    }
                    if (exists == 0)
                    {
                        Console.WriteLine("\nNao existe um tipo de plano com esse nome");
                        break;
                    }
                    Console.Clear();

                    Console.WriteLine("\nQuer modificar o nome do tipo de plano?");
                    Console.WriteLine("\n1-Sim\n2-Nao");
                    confirm = Int32.Parse(Console.ReadLine());
                    if (confirm == 1)
                    {
                        Console.WriteLine("\nDigite o novo nome do tipo de plano: ");
                        typeName = Console.ReadLine();
                    } else
                    {
                        typeName = ptOriginal.Name;
                    }
                    Console.Clear();

                    PlanType typeInsert = new PlanType(typeName, ptOriginal.Id);

                    Console.WriteLine("\nConfirme seus dados: ");
                    Console.WriteLine(typeInsert);
                    Console.WriteLine("\n1-Sim\n2-Nao");
                    confirm = Int32.Parse(Console.ReadLine());
                    if (confirm == 1)
                    {
                        pt.insertType(typeInsert);
                    }
                    else
                    {
                        Console.WriteLine("\nOperacao cancelada!");
                    }
                    break;
                case 4:
                    statusList = ps.getStatus();
                    Console.WriteLine("\nInsira o nome do status: ");
                    string statusName = Console.ReadLine();

                    PlanStatus psOriginal = new PlanStatus();

                    foreach (var item in statusList)
                    {
                        if (item.Name.Contains(statusName))
                        {
                            psOriginal = item;
                            exists = 1;
                            break;
                        }
                    }
                    if (exists == 0)
                    {
                        Console.WriteLine("\nNao existe um status de plano com esse nome");
                        break;
                    }
                    Console.Clear();

                    Console.WriteLine("\nQuer modificar o nome do status?");
                    Console.WriteLine("\n1-Sim\n2-Nao");
                    confirm = Int32.Parse(Console.ReadLine());
                    if (confirm == 1)
                    {
                        Console.WriteLine("\nDigite o novo nome do status: ");
                        statusName = Console.ReadLine();
                    } else
                    {
                        statusName = psOriginal.Name;
                    }
                    Console.Clear();

                    PlanStatus stInsert = new PlanStatus(statusName, psOriginal.Id);

                    Console.WriteLine("\nConfirme seus dados: ");
                    Console.WriteLine(stInsert);
                    Console.WriteLine("\n1-Sim\n2-Nao");
                    confirm = Int32.Parse(Console.ReadLine());
                    if (confirm == 1)
                    {
                        ps.insertStatus(stInsert);
                    }
                    else
                    {
                        Console.WriteLine("\nOperacao cancelada!");
                    }
                    break;
            }

            Submenu(op);
        }

        public static void Exclude(int op)
        {
            Console.Clear();
            PlanDAO p = new PlanDAO();
            UserDAO u = new UserDAO();
            PlanTypeDAO pt = new PlanTypeDAO();
            PlanStatusDAO ps = new PlanStatusDAO();

            string resp = "";

            switch (op)
            {
                case 1:
                    Console.WriteLine("\nDigite o nome do plano a ser excluído");
                    resp = Console.ReadLine();
                    planList = p.getPlans();
                    if(planList.Where(i => i.Name.Contains(resp)).Count() > 0)
                    {
                        foreach (var item in planList.Where(i => i.Name.Contains(resp)))
                        {
                            p.excludePlan(item.Id);
                        }
                    } else
                    {
                        Console.WriteLine("\nPlano nao existe!");
                    }
                    
                    break;
                case 2:
                    Console.WriteLine("\nDigite o nome do usuario a ser excluído");
                    resp = Console.ReadLine();
                    userList = u.getUser();
                    if (userList.Where(i => i.Name.Contains(resp)).Count() > 0)
                    {
                        foreach (var item in userList.Where(i => i.Name.Contains(resp)))
                        {
                            u.excludeUser(item.Id);
                        }
                    } else
                    {
                        Console.WriteLine("\nUsuario nao existe!");
                    }
                    break;
                case 3:
                    Console.WriteLine("\nDigite o nome do Tipo de Plano a ser excluído");
                    resp = Console.ReadLine();
                    typeList = pt.getType();
                    if (typeList.Where(i => i.Name.Contains(resp)).Count() > 0)
                    {
                        foreach (var item in typeList.Where(i => i.Name.Contains(resp)))
                        {
                            pt.excludeType(item.Id);
                        }
                    } else
                    {
                        Console.WriteLine("\nTipo de Plano nao existe!");
                    }
                    break;
                case 4:
                    Console.WriteLine("\nDigite o nome do Status do Plano a ser excluído");
                    resp = Console.ReadLine();
                    statusList = ps.getStatus();
                    if (statusList.Where(i => i.Name.Contains(resp)).Count() > 0)
                    {
                        foreach (var item in statusList.Where(i => i.Name.Contains(resp)))
                        {
                            ps.excludeStatus(item.Id);
                        }
                    } else
                    {
                        Console.WriteLine("\nStatus de Plano nao existe!");
                    }
                    break;
            }

            Submenu(op);
        }
    }
}
