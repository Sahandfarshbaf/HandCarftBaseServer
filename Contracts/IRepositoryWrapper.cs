using System;
using System.Collections.Generic;
using System.Text;


namespace Contracts
{
    public interface IRepositoryWrapper
    {

        IApiRepository Api { get; }
        ICatApiRepository CatApi { get; }
        ICatFromRepository CatFrom { get; }
        ICatRoleRepository CatRole { get; }
        ICatStatusRepository CatStatus { get; }
        IColorRepository Color { get; }
        IFormsApiRepository FormsApi { get; }
        IFormsRepository Forms { get; }
        ILocationRepository Location { get; }
        IRoleFormsRepository RoleForms { get; }
        IRoleRepository Role { get; }
        IStatusRepository Status { get; }
        IStatusTypeRepository StatusType { get; }
        ISystemsRepository Systems { get; }
        ITablesRepository Tables { get; }
        ITablesServiceDiscoveryRepository TablesServiceDiscovery { get; }
        IUserRoleRepository UserRole { get; }
        IUsersRepository Users { get; }
        ISellerRepository Seller { get; }
        IProductRepository Product { get; }
        ICatProductRepository CatProduct { get; }



        void Save();
    }
}