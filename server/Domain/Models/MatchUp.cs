namespace Domain.Models
{
    public class MatchUp<T>
    {
        public T Home { get; set; }
        public T Away { get; set; }
    }
}