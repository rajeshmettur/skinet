using System;
using System.Security.Cryptography.X509Certificates;
using Core.Entities;

namespace Core.Specification;

public class BrandListSpecification : BaseSpecification<Product, string>
{
    public BrandListSpecification() {
        SelectExpression(x => x.Brand);
        ApplyDistinct();
    }

}
