using System.ComponentModel.DataAnnotations;

namespace Global.Shared.Commands.Contracts
{
    public interface IErrorEmailTemplateData
    {
        [Required] public string CreatedAt { get; set; }
        [Required] public string Message { get; set; }
        [Required] public string Source { get; set; }
        [Required] public string TargetSite { get; set; }
        [Required] public string StackTrace { get; set; }
    }
}