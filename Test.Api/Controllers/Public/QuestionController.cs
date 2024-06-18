using Test.Api.Controllers.Abstract;
using Test.Domain.Entities;
using Test.Infrastructure.Ef;

namespace Test.Api.Controllers.Public;

public class QuestionController(DataContext dataContext) : BaseController<Question>(dataContext);