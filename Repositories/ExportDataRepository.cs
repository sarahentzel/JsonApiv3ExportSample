using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GettingStarted.Models;
using JsonApiDotNetCore.Data;
using JsonApiDotNetCore.Internal.Query;
using JsonApiDotNetCore.Models;
using JsonApiDotNetCore.Serialization;
using JsonApiDotNetCore.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GettingStarted.Repositories
{
    public class TestExportRepository : DefaultEntityRepository<TestExport>
    {
        private readonly IJsonApiSerializer _jsonApiSerializer;
        private readonly SampleDbContext _dbContext;
        public TestExportRepository(ILoggerFactory loggerFactory,
            IJsonApiContext jsonApiContext,
            IDbContextResolver contextResolver,
            IJsonApiSerializer jsonApiSerializer) : base(loggerFactory, jsonApiContext, contextResolver)
        {
            _jsonApiSerializer = jsonApiSerializer;
            _dbContext = (SampleDbContext)contextResolver.GetContext();
        }
        public override IQueryable<TestExport> Get()
        {
        
            List<TestExport> entities = new List<TestExport>
            {
                new TestExport()
            };
            TestExport entity = entities.First();
            entity.AllJson = "data: [" + _jsonApiSerializer.Serialize(_dbContext.Articles);
            entity.AllJson += "," + _jsonApiSerializer.Serialize(_dbContext.People);
            entity.AllJson += "]";

            return entities.AsQueryable();
        }
    }
}
