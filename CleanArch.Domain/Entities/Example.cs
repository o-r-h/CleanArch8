using CleanArch.Domain.Common;


namespace CleanArch.Domain.Entities
{
    public partial class Example : BaseEntity
    {
       
        public string NameExample { get; set; } = string.Empty;
        public decimal? PriceExample { get; set; }
        
    }
}
