using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Test.Api.Controllers.Abstract;
using Test.Domain.Entities;
using Test.Infrastructure.Ef;
namespace Test.Api.Controllers.Public;

public class SubjectController(DataContext dataContext) : BaseController<Subject>(dataContext)
{
    protected override Subject GetModel(Expression<Func<Subject, bool>> expression)
    {
        var model = dataContext.Set<Subject>()
            .Include(s => s.Questions)
            .SingleOrDefault(expression);
        if (model == null) throw new NullReferenceException();
        return model;
    }
};