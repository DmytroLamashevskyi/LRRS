using LRRS.Data.Model.CoreModel;
using LRRS.Queries.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://www.ezzylearning.net/tutorial/asp-net-core-localization-from-database
namespace LanguageService
{
    public class LocalizationService : ILocalizationService
    {
        private readonly ApplicationDbContext _context;

        public LocalizationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public StringResource GetStringResource(string resourceKey, int languageId)
        {
            return _context.StringResources.FirstOrDefault(x =>
                    x.Key.Trim().ToLower() == resourceKey.Trim().ToLower()
                    && x.LanguageId == languageId);
        }
    }
}
