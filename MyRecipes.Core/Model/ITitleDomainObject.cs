namespace MyRecipes.Core.Model
{
    public interface ITitleDomainObject : IDomainObject
    {
        string Title { get; set; }
    }
}
