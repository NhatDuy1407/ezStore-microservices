using RKSystem.DataAccess.MongoDB.Entities;
using RKSystem.UserService.Models;

namespace RKSystem.UserService.Data.Entities
{
    public class Function : BaseIntEntity<FunctionDto>
    {
        protected override void UpdateDomain(FunctionDto data, string userId)
        {
            this.ParentId = data.ParentId;
            this.Code = data.Code;
            this.Name = data.Name;
            this.Icon = data.Icon;
            this.Module = data.Module;
            this.Url = data.Url;
            this.DefaultPermission = data.DefaultPermission;
            this.IsSitepmap = data.IsSitepmap;
        }

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