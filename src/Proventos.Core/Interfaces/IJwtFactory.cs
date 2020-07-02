using Proventos.Core.Dtos;
using System.Threading.Tasks;

namespace Proventos.Core.Interfaces
{
    public interface IJwtFactory
    {
        Task<Token> GenerateEncodedToken(string id, string userName);
    }
}
