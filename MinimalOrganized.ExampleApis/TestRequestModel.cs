using System.ComponentModel.DataAnnotations;

namespace MinimalOrganized.ExampleApis
{
    public class TestRequestModel
    {
        [Required(AllowEmptyStrings = false)]
        [MaxLength(100)]
        public string? Description { get; set; }
    }
}
