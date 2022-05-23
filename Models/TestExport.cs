using JsonApiDotNetCore.Models;

namespace GettingStarted.Models
{
    public class TestExport : Identifiable
    {
        public TestExport() : base()
        {
            StringId = "1";
        }
        [Attr]
        public string AllJson { get; set; }

    }
   
}
