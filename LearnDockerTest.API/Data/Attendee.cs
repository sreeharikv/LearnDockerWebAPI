using System.ComponentModel.DataAnnotations;

namespace LearnDockerTest.API.Data;

public class Attendee : BaseEntity
{
    [MaxLength(50)]
    public string FirstName { get; set; } = null!;
    [MaxLength(50)]
    public string LastName { get; set; } = null!;
    [MaxLength(150)]
    public string EmailAddress { get; set; } = null!;
    [MaxLength(14)]
    public string PhoneNumber { get; set; } = null!;
    [MaxLength(150)]
    public string CompanyName { get; set; } = null!;

    public ReferralSource? ReferralSource { get; set; }
    public Guid ReferralSourceId { get; set; }

    public JobRole? JobRole { get; set; }
    public Guid JobRoleId { get; set; }


    public Gender? Gender { get; set; }
    public Guid GenderId { get; set; }

}
