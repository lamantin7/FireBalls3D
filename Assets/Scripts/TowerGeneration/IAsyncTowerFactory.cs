using UnityEngine;
using System.Threading.Tasks;
using System.Threading;

namespace TowerGeneration
{
   public interface IAsyncTowerFactory
    {
        Task<Tower> CreateAsync(Transform tower, CancellationToken cancellationToken);
    }
}
