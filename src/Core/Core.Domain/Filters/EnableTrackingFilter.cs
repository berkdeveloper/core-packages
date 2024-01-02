﻿using Core.Domain.Filters.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Core.Domain.Filters;

public class EnableTrackingFilter<TAggregate> : IFilterStrategy<TAggregate> where TAggregate : class
{
    public IQueryable<TAggregate> ApplyFilter(IQueryable<TAggregate> queryable) => queryable.AsNoTracking();
}
