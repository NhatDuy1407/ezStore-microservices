using System;

namespace ezStore.WareHouse.API.ViewModels
{
    public class WareHouseViewModel
    {
        public Guid Id { get; internal set; }
        public string Name { get; internal set; }
        public string CreatedBy { get; internal set; }
        public string UpdatedBy { get; internal set; }
        public DateTime? CreatedDate { get; internal set; }
        public DateTime? UpdatedDate { get; internal set; }
    }
}
