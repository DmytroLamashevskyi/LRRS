using LRRS.Data.Model.CoreModel;
using LRRS.Queries.DataBase;

//https://www.ezzylearning.net/tutorial/asp-net-core-localization-from-database
namespace LanguageService
{
    public class LanguageService : ILanguageService
    {
        private readonly ApplicationDbContext _context;

        public LanguageService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Language> GetLanguages()
        {
            return _context.Languages.ToList();
        }

        public Language GetLanguageByCulture(string culture)
        {
            return _context.Languages.FirstOrDefault(x =>
                x.Culture.Trim().ToLower() == culture.Trim().ToLower());
        } 
    }
}
