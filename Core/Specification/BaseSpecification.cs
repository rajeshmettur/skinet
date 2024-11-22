using System;
using System.Dynamic;
using System.Linq.Expressions;
using Core.Interfaces;

namespace Core.Specification;

public class BaseSpecification<T>(Expression<Func<T, bool>> criteria) : ISpecification<T>
{
    public BaseSpecification() : this(null!) {}
  
    public Expression<Func<T, bool>> Criteria => criteria;

    public Expression<Func<T, object>>? OrderBy {get; private set; }

    public Expression<Func<T, object>>? OrderByDescending { get; private set; }

    public bool IsDistinct {get; private set;}

    public int Take  {get; private set;}

    public int Skip  {get; private set;}

    public bool IsPagingEnabled  {get; private set;}

    protected void AddOrderByDescending(Expression<Func<T, object>> orderByDescExpression) {
        OrderByDescending = orderByDescExpression;
    }

    protected void AddOrderBy(Expression<Func<T, object>> orderByExpression)
    {
        OrderBy = orderByExpression;
    }

    protected void ApplyDistinct(){
        IsDistinct = true;
    }

    protected void ApplyPagination(int skip, int take) {
        Take = take;
        Skip = skip;
        IsPagingEnabled = true;
    }

    public IQueryable<T> ApplyCriteria(IQueryable<T> query)
    {
        if(criteria != null)
        {
            query = query.Where(criteria);
        }
        return query;
    }
}



public class BaseSpecification<T, TResult>(Expression<Func<T, bool>> criteria)
: BaseSpecification<T>(criteria), ISpecification<T, TResult>
{
    public BaseSpecification() : this(null!) {}
    public Expression<Func<T, TResult>>? Select {get; private set; }

    protected void SelectExpression(Expression<Func<T,TResult>> selectExpression) {
        Select = selectExpression;
    }
}
