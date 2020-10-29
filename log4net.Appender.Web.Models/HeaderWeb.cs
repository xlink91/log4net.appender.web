namespace log4net.Appender.Web.Models
{
    public class HeaderWeb
    {
        public HeaderWeb()
        {
        }

        public HeaderWeb(string key, string value)
        {
            Key = key;
            Value = value;
        }

        public string Key { get; set; }
        public string Value { get; set; }
    }
}
