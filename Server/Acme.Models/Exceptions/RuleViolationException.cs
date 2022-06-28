namespace Acme.Models.Exceptions;

public class RuleViolationException : Exception
{
    public RuleViolationException(string userFriendlyMessage)
    {
        UserFriendlyMessage = userFriendlyMessage;
    }

    public RuleViolationException(string? technicalErrorMessage, string userFriendlyMessage) : base(technicalErrorMessage)
    {
        UserFriendlyMessage = userFriendlyMessage;
    }

    public RuleViolationException(string? technicalErrorMessage, string userFriendlyMessage, Exception? innerException) : base(technicalErrorMessage, innerException)
    {
        UserFriendlyMessage = userFriendlyMessage;
    }

    public string UserFriendlyMessage { get; set; }
}