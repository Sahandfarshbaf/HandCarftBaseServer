using System;
using System.Collections.Generic;
using System.Text;
using Contracts;
using Entities;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private BaseContext _repoContext;
        public IApiRepository _api;
        public ICatApiRepository _catApi;
        public ICatFromRepository _catFrom;
        public ICatRoleRepository _catRole;
        public ICatStatusRepository _catStatus;
        public IColorRepository _color;
        public IFormsApiRepository _formsApi;
        public IFormsRepository _forms;
        public ILocationRepository _location;
        public IRoleFormsRepository _roleForms;
        public IRoleRepository _role;
        public IStatusRepository _status;
        public IStatusTypeRepository _statusType;
        public ISystemsRepository _systems;
        public ITablesRepository _tables;
        public ITablesServiceDiscoveryRepository _tablesServiceDiscovery;
        public IUserRoleRepository _userRole;
        public IUsersRepository _users;
        public ISellerRepository _seller;
        public IProductRepository _product;
        public ICatProductRepository _catProduct;



        public IApiRepository Api => _api ??= new ApiRepository(_repoContext);
        public ICatApiRepository CatApi => _catApi ??= new CatApiRepository(_repoContext);
        public ICatFromRepository CatFrom => _catFrom ??= new CatFromRepository(_repoContext);
        public ICatRoleRepository CatRole => _catRole ??= new CatRoleRepository(_repoContext);
        public ICatStatusRepository CatStatus => _catStatus ??= new CatStatusRepository(_repoContext);
        public IColorRepository Color => _color ??= new ColorRepository(_repoContext);
        public IFormsApiRepository FormsApi => _formsApi ??= new FormsApiRepository(_repoContext);
        public IFormsRepository Forms => _forms ??= new FormsRepository(_repoContext);
        public ILocationRepository Location => _location ??= new LocationRepository(_repoContext);
        public IRoleFormsRepository RoleForms => _roleForms ??= new RoleFormsRepository(_repoContext);
        public IRoleRepository Role => _role ??= new RoleRepository(_repoContext);
        public IStatusRepository Status => _status ??= new StatusRepository(_repoContext);
        public IStatusTypeRepository StatusType => _statusType ??= new StatusTypeRepository(_repoContext);
        public ISystemsRepository Systems => _systems ??= new SystemsRepository(_repoContext);
        public ITablesRepository Tables => _tables ??= new TablesRepository(_repoContext); 
        public ITablesServiceDiscoveryRepository TablesServiceDiscovery => _tablesServiceDiscovery ??= new TablesServiceDiscoveryRepository(_repoContext);
        public IUserRoleRepository UserRole => _userRole ??= new UserRoleRepository(_repoContext);
        public IUsersRepository Users => _users ??= new UsersRepository(_repoContext);
        public ISellerRepository Seller => _seller ??= new SellerRepository(_repoContext);
        public IProductRepository Product => _product ??= new ProductRepository(_repoContext);
        public ICatProductRepository CatProduct => _catProduct ??= new CatProductRepository(_repoContext);



        public RepositoryWrapper(BaseContext repositoryContext)
        {
            _repoContext = repositoryContext;

        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
