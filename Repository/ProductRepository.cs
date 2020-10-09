using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(BaseContext repositoryContext)
            : base(repositoryContext)
        {

        }

    }
}
