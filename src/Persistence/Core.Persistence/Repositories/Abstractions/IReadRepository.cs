﻿using Core.Domain.Core;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Core.Persistence.Repositories.Abstractions;

public interface IReadRepository<TAggregate, TKey> : IQuery<TAggregate>
    where TAggregate : AggregateRoot<TKey>
{
    TAggregate Get(
    Expression<Func<TAggregate, bool>> predicate,
    Func<IQueryable<TAggregate>, IIncludableQueryable<TAggregate, object>> include = null,
    bool withDeleted = false,
    bool enableTracking = true);

    Paginate<TAggregate> GetList(
        Expression<Func<TAggregate, bool>> predicate = null,
        Func<IQueryable<TAggregate>, IOrderedQueryable<TAggregate>> orderBy = null,
        Func<IQueryable<TAggregate>, IIncludableQueryable<TAggregate, object>> include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true);

    Paginate<TAggregate> GetListByDynamic(
        DynamicQuery dynamic,
        Expression<Func<TAggregate, bool>> predicate = null,
        Func<IQueryable<TAggregate>, IIncludableQueryable<TAggregate, object>> include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true);

    bool Any(Expression<Func<TAggregate, bool>> predicate = null, bool withDeleted = false, bool enableTracking = true);
}
