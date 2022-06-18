using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFTemplateService
{
    /// <summary>
    /// https://www.kambu.pl/blog/how-to-generate-pdf-from-html-in-net-core-applications/
    /// </summary>
    public interface ITemplateService
    {
        Task<string> RenderAsync<TViewModel>(string templateFileName, TViewModel viewModel);
    }
}
