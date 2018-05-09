using Microservice.Core.DataAccess.Entities;

namespace Microservice.Service.UserService.Models
{
    public class FunctionDto : BaseIntModel
    {
        public int? ParentId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Module { get; set; }
        public string Url { get; set; }
        public int DefaultPermission { get; set; }
        public bool IsSitepmap { get; set; }
    }
}
