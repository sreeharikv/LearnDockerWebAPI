using System.ComponentModel.DataAnnotations;

namespace LearnDockerTest.API.Data;

public class ReferralSource : BaseEntity
{
    [StringLength(50)]
    public string Name { get; set; } = null!;
}
