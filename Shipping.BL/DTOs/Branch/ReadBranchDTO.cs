namespace Shipping.BL.DTOs.Branch
{
    public class ReadBranchDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public bool IsDeleted { get; set; }
    }
}
