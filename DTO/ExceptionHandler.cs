using System.Collections;
using System.Text;

namespace Shared.DTO.Package
{
    public static class ExceptionHandler
    {
        public static string FormatExceptionsDetails(Exception ex)
        {
            var exceptionDetails = new StringBuilder();

            exceptionDetails.AppendLine("Exception Details:");
            exceptionDetails.AppendLine("--------------------------------------------------");
            exceptionDetails.AppendLine($"Message: {ex.Message}");
            exceptionDetails.AppendLine($"Type: {ex.GetType()}");
            exceptionDetails.AppendLine($"Source: {ex.Source}");
            exceptionDetails.AppendLine($"Target Site: {ex.TargetSite}");
            exceptionDetails.AppendLine($"Help Link: {ex.HelpLink}");

            if (ex.Data != null && ex.Data.Count > 0)
            {
                exceptionDetails.AppendLine("Additional Data:");
                foreach (DictionaryEntry de in ex.Data)
                {
                    exceptionDetails.AppendLine($"  {de.Key}: {de.Value}");
                }
            }

            exceptionDetails.AppendLine("Stack Trace:");
            exceptionDetails.AppendLine(ex.StackTrace);

            if (ex.InnerException != null)
            {
                Exception inner = ex.InnerException!;
                while (true)
                {
                    exceptionDetails.AppendLine("--------------------------------------------------");
                    exceptionDetails.AppendLine("Inner Exception Details:");
                    exceptionDetails.AppendLine($"Message: {inner.Message}");
                    exceptionDetails.AppendLine($"Type: {inner.GetType()}");
                    exceptionDetails.AppendLine($"Source: {inner.Source}");
                    exceptionDetails.AppendLine($"Target Site: {inner.TargetSite}");
                    exceptionDetails.AppendLine($"Help Link: {inner.HelpLink}");

                    if (inner.Data != null && inner.Data.Count > 0)
                    {
                        exceptionDetails.AppendLine("Additional Data:");
                        foreach (DictionaryEntry de in inner.Data)
                        {
                            exceptionDetails.AppendLine($"  {de.Key}: {de.Value}");
                        }
                    }

                    exceptionDetails.AppendLine("Stack Trace:");
                    exceptionDetails.AppendLine(inner.StackTrace);
                    if (inner.InnerException != null)
                    {
                        inner = inner.InnerException;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            exceptionDetails.AppendLine("--------------------------------------------------");

            return exceptionDetails.ToString();
        }
    }
}