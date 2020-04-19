namespace Domain.Model
{
    public class Pagination
    {
        public int Limit { get; set; }
        public int Skip { get; set; }

        public Pagination()
        {
            Limit = 20;
            Skip = 0;
        }
    }
}