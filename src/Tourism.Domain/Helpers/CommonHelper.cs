using System.ComponentModel;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Tourism.Domain.Helper;

public static class CommonHelper
{
    public static string GetDescription(this Enum source)
    {
        var field = source.GetType().GetField(source.ToString());
        var attribute = field?.GetCustomAttribute<DescriptionAttribute>();
        return attribute != null ? attribute.Description : source.ToString();
    }
    public static string StripHTML(string htmlString)
    {
        if (!string.IsNullOrEmpty(htmlString))
        {
            htmlString = Regex.Replace(htmlString, @"<(.|\n)*?>", string.Empty);
            htmlString = Regex.Replace(htmlString, @"&nbsp;", " ");
            htmlString = Regex.Replace(htmlString, @"&amp;", "&");
            htmlString = Regex.Replace(htmlString, @"&lt;", "<");
            htmlString = Regex.Replace(htmlString, @"&gt;", ">");
            htmlString = Regex.Replace(htmlString, @"&quot;", @"""");
            htmlString = Regex.Replace(htmlString, @"&apos;;", @"''");
            htmlString = Regex.Replace(htmlString, @"&cent;", "¢");
            htmlString = Regex.Replace(htmlString, @"&pound;", "£");
            htmlString = Regex.Replace(htmlString, @"&yen;", @"¥");
            htmlString = Regex.Replace(htmlString, @"&euro;", @"€");
            htmlString = Regex.Replace(htmlString, @"&copy;", "©");
            htmlString = Regex.Replace(htmlString, @"&reg;", "®");
            return htmlString;
        }
        return string.Empty;
    }
}