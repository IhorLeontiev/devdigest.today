using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface ICrossPostService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoryId"></param>
        /// <param name="message"></param>
        /// <param name="link"></param>
        /// <param name="tags">
        ///     Tags which should be added to all all posts 
        /// </param>
        /// <returns></returns>
        Task Send(int categoryId,
            string message,
            Uri link,
            [NotNull] IReadOnlyCollection<string> tags);
    }
}