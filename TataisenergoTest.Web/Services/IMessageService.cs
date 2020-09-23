using System.Threading.Tasks;

namespace TataisenergoTest.Web.Services
{
    public interface IMessageService
    {
        Task<string> EncryptMessage(string content);
    }
}