using UnityEngine;
using System.Threading.Tasks;
using System.Threading;

namespace Towers.Generation
{
   public interface IAsyncTowerFactory
    {
        Task<Tower> CreateAsync(Transform tower, CancellationToken cancellationToken);
    }
}
