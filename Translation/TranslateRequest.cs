namespace ConsoleApp33
{
    public class TranslateRequest
    {
        public Data data { get; set; }
        public string source { get; set; }
        public string target { get; set; }
        public string format { get; set; }
        public string q { get; internal set; }
    }
}