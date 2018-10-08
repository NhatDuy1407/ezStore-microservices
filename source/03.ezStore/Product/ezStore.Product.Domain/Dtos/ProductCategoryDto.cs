using System;

namespace ezStore.Product.Domain.Dtos
{
    public class ProductCategoryDto
    {
        public string Name { get; internal set; }
        public Guid Id { get; internal set; }
        public string CreatedBy { get; internal set; }
        public string UpdatedBy { get; internal set; }
        public DateTime? CreatedDate { get; internal set; }
        public DateTime? UpdatedDate { get; internal set; }
    }
}
