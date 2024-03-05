
using api.Dtos.Dropdown;

namespace api.Interfaces
{
    public interface IDropdownRepository
    {
        Task<List<DropdownDto>> GetSubCategories();
    }
}
