using System.Threading.Tasks;

namespace PopularityProgrammingLanguages.Services.IService
{
   public interface ISearch
    {
        string Name { get; }
        Task<long> GetResultTotalAsync(string word);
    }
}
