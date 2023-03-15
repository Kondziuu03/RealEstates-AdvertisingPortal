
namespace RealEstates.UI.Models;

public class MediatorValidateResponse<T>
{
    public bool isValid { get; set; }
    public T Model { get; set; }
}
