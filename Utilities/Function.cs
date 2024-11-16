namespace CarRental.Utilities
{
    public class Function
    {
        public string TitleToAlias(string Title)
        {
            return SlugGenerator.SlugGenerator.GenerateSlug(Title);
        }
    }
}
