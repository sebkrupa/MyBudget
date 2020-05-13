using Dapper;
using MyBudgetAPI.Model;
using System.Collections.Generic;
using System.Linq;

namespace MyBudgetAPI.Read
{
    public class Category : Interfaces.Query.Read<Model.Category>
    {
    }
}
