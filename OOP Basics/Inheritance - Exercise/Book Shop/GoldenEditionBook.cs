
namespace Book_Shop
{
    using System.Text;

    public class GoldenEditionBook : Book
    {
        public GoldenEditionBook(string author, string title, decimal price) : base(author, title, price)
        {
        }

        public override decimal Price
        {
            get
            {
                return base.Price * 1.3m;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("Type: ").AppendLine(this.GetType().Name)
                .Append("Title: ").AppendLine(base.Title)
                .Append("Author: ").AppendLine(base.Author)
                .Append("Price: ").Append($"{this.Price:f1}")
                .AppendLine();

            return sb.ToString();
        }
    }
}