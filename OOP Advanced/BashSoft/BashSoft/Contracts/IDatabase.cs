namespace BashSoft.Contracts
{
    public interface IDatabase:IRequester,IFilteredTaker,IOrderedTaker
    {
        void UnloadData();

        void LoadData(string fileName);
    }
}
