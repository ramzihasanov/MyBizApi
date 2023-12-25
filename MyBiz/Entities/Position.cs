namespace MyBiz.Entities
{
    public class Position:BaseEntity
    {
        public string Name { get; set; }
        public List<Worker> Workers { get; set; }
    }
}
