using System.Threading.Tasks;
namespace ForumApi.Domain.IRepositories
{
    public interface IUnit_Of_Work
    {
         Task CompleteAsync();
    }
}