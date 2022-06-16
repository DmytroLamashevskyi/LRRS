using LRRS.Data.Model.CoreModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://www.ezzylearning.net/tutorial/asp-net-core-localization-from-database
namespace LanguageService
{
    public interface ILocalizationService
    {
        StringResource GetStringResource(string resourceKey, int languageId);
    }
}
