using UnityEngine;
using System.Threading.Tasks;

namespace TowerGeneration
{
   public interface IAsyncTowerFactory
    {
        Task<Tower> CreateAsync(Transform tower);
    }
}
