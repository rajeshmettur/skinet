using System;
using Core.Entities;

namespace Core.Specification;

public class TypeSpecification: BaseSpecification<Product, string>
{
    public TypeSpecification() {
        SelectExpression(x => x.Type);
        ApplyDistinct();
    }
}
