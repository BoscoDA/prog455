namespace Week1.Models
{
    public class MovieQuoteModel
    {
        public string Quote { get; set; }
        public string Character { get; set; }
        public int Id { get; set; }

        protected static int quoteCount;
            
        public MovieQuoteModel()
        {
            Id = quoteCount++;
        }
    }
}
