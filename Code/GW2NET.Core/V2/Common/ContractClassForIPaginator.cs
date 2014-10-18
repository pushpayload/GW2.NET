// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContractClassForIPaginator.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the ContractClassForIPaginator type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Common
{
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.Threading;
    using System.Threading.Tasks;

    [ContractClassFor(typeof(IPaginator<>))]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", 
        Justification = "Only used by the Code Contracts for .NET extension.")]
    internal abstract class ContractClassForIPaginator<T> : IPaginator<T>
    {
        public ICollectionPage<T> GetPage(int page)
        {
            Contract.Requires(page >= 0);
            Contract.Ensures(Contract.Result<ICollectionPage<T>>() != null);
            throw new System.NotImplementedException();
        }

        public ICollectionPage<T> GetPage(int page, int pageSize)
        {
            Contract.Requires(page >= 0);
            Contract.Requires(pageSize > 0);
            Contract.Ensures(Contract.Result<ICollectionPage<T>>() != null);
            throw new System.NotImplementedException();
        }

        public Task<ICollectionPage<T>> GetPageAsync(int page)
        {
            Contract.Requires(page >= 0);
            Contract.Ensures(Contract.Result<Task<ICollectionPage<T>>>() != null);
            Contract.Ensures(Contract.Result<Task<ICollectionPage<T>>>().Result != null);
            throw new System.NotImplementedException();
        }

        public Task<ICollectionPage<T>> GetPageAsync(int page, CancellationToken cancellationToken)
        {
            Contract.Requires(page >= 0);
            Contract.Ensures(Contract.Result<Task<ICollectionPage<T>>>() != null);
            Contract.Ensures(Contract.Result<Task<ICollectionPage<T>>>().Result != null);
            throw new System.NotImplementedException();
        }

        public Task<ICollectionPage<T>> GetPageAsync(int page, int pageSize)
        {
            Contract.Requires(page >= 0);
            Contract.Requires(pageSize > 0);
            Contract.Ensures(Contract.Result<Task<ICollectionPage<T>>>() != null);
            Contract.Ensures(Contract.Result<Task<ICollectionPage<T>>>().Result != null);
            throw new System.NotImplementedException();
        }

        public Task<ICollectionPage<T>> GetPageAsync(int page, int pageSize, CancellationToken cancellationToken)
        {
            Contract.Requires(page >= 0);
            Contract.Requires(pageSize > 0);
            Contract.Ensures(Contract.Result<Task<ICollectionPage<T>>>() != null);
            Contract.Ensures(Contract.Result<Task<ICollectionPage<T>>>().Result != null);
            throw new System.NotImplementedException();
        }
    }
}