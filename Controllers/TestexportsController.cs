using GettingStarted.Models;
using JsonApiDotNetCore.Controllers;
using JsonApiDotNetCore.Services;

namespace GettingStarted
{
    public class TestexportsController : JsonApiController<TestExport>
    {
        public TestexportsController(
          IJsonApiContext jsonApiContext,
          IResourceService<TestExport> resourceService)
          : base(jsonApiContext, resourceService)
        { }
    }
}
