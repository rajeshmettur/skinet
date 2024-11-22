using System;
using Core.Entities;

namespace Core.Specification;

public class ProductSpecification : BaseSpecification<Product> 
{
    public ProductSpecification(ProductSpecParams specParams) : base(x => 
        (string.IsNullOrEmpty(specParams.Search) || x.Name.ToLower().Contains(specParams.Search)) &&
        (!specParams.Brands.Any() || specParams.Brands.Contains(x.Brand)) &&
        (!specParams.Types.Any() || specParams.Types.Contains(x.Type)) 
    )
    {

        ApplyPagination(specParams.PageSize * (specParams.PageIndex -1), specParams.PageSize);
        // AddOrderBy(x => x.Name);
        switch (specParams.Sort)
        {
            case "priceAsc":
                  AddOrderBy(x => x.Price);
                 break;
            case "priceDesc":
                 AddOrderByDescending(x => x.Price);
                 break;
            default:
                    AddOrderBy(x => x.Name);
                    break;
        }
    }
}
