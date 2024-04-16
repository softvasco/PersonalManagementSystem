using Shared.Dtos.Dropdown;

namespace api.Interfaces
{
    public interface IDropdownRepository
    {
        Task<List<DropdownDto>> GetSubCategories();
        Task<List<DropdownDto>> GetSourceAccountOrCardCode();
        Task<List<DropdownDto>> GetDestinationAccountOrCardCode();
        Task<List<DropdownDto>> GetEarnings();
        Task<List<DropdownDto>> GetExpenses();
        Task<List<DropdownDto>> GetCredits();
        Task<List<DropdownDto>> GetCategories();
    }
}
