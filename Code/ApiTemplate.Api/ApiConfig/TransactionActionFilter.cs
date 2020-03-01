using Microsoft.AspNetCore.Mvc.Filters;
using ApiTemplate.Core.Infrastructure.EntityFramework.Contexts;
using System;

namespace ApiTemplate.Api.ApiConfig
{
    public class TransactionActionFilter : IActionFilter
    {
        private readonly ApiTemplateContext _dbContext;

        public TransactionActionFilter(ApiTemplateContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (_dbContext.Database.CurrentTransaction == null)
                _dbContext.Database.BeginTransaction();
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception == null)
            {
                try
                {
                    _dbContext.SaveChanges();
                    _dbContext.Database.CommitTransaction();
                }
                catch (Exception ex)
                {
                    context.Exception = ex;
                    context.Result = null;
                }
            }
        }
    }
}