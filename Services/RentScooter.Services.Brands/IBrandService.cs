namespace RentScooter.Services.Brands;

public interface IBrandService
{
    Task<IEnumerable<BrandModel>> GetBrands();
}