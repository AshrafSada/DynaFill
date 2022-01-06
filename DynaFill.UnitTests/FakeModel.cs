using System;

namespace DynaFill.UnitTests
{
    public class FakeModel
    {
        public int FakeId { get; set; }
        public string FakeName { get; set; }
        public decimal FakeDecimal { get; set; }
        public DateTime FakeDatetime { get; set; }
        public DateTimeOffset FakeDateTimeOffset { get; set; }
        public bool FakeBoolean { get; set; }
    }
}
