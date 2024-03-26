
namespace api.Interfaces
{
    public interface ISimulatorRepository
    {
        Task<decimal> SimulateAsync(DateTime untilDate);
    }
}