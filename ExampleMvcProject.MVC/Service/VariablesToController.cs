using ExampleMvcProject.MVC.Controllers;
using ExampleMvcProject.MVC.Entities;
using ExampleMvcProject.MVC.Interfaces;

namespace ExampleMvcProject.MVC.Service
{
    public class VariablesToController : IVariablesToController
    {
        private BookstoreDbContext _dbContext;
        public VariablesToController(BookstoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Dictionary<string, string> Get()
        {
            string basketCount = _dbContext.baskets.Count().ToString();
            Dictionary<string, string> variableDict = new Dictionary<string, string>();

            variableDict.Add("basketCount", basketCount);

            if (variableDict["basketCount"] == null) variableDict["basketCount"] = "0";

            return variableDict;
        }
    }
}
