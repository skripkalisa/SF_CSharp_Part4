namespace API.Contracts.Tags;

public class AddTagRequest
{
  // [Required]
  // [RegularExpression(@"^\w+$", ErrorMessage = "Special characters are not allowed")]
  // [StringLength(20, MinimumLength = 2)]
  public string? TagName { get; set; }
}