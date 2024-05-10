using System.Collections.Concurrent;

namespace TNN.Service
{
    public interface ITokenServices
    {
        ConcurrentDictionary<int, string> TokenStorages { get; set; }
        void AddToken(int idUser, string token);
        void RemoveToken(int idUser);
    }
    public class TokenServices : ITokenServices
    {
        public ConcurrentDictionary<int, string> TokenStorages { get; set; } = new ConcurrentDictionary<int, string>();

        public void AddToken(int idUser, string token)
        {
            TokenStorages.TryAdd(idUser, token);
        }

        public void RemoveToken(int idUser)
        {
            TokenStorages.TryRemove(idUser, out _);
        }
    }
}
