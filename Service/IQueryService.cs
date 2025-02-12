namespace Service
{
    public interface IQueryService<in Tin, out Tout> where Tin : IQuery
    {
        Tout Execute(Tin obj);
    }
}
