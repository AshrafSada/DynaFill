namespace DynaFill.XUnitTests.SampleModels
{
    public class AuditModel
    {
        public DateTime CreatedAt { get; set; } = default!;
        public DateTime UpdatedAt { get; set; } = default!;

        public string CreatedBy { get; set; } = null!;
    }
}
