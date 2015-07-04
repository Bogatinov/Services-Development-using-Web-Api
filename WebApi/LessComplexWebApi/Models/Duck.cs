namespace LessComplexWebApi.Models
{
    public class Duck
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public Quaak Calling { get; set; }
    }

    public enum Quaak
    {
        Qweeet,
        Quack
    }
}