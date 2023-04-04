using UnityEngine;
using System.Threading.Tasks;

namespace TowerGeneration
{
    internal interface IAsyncTowerFactory
    {
        Task<Tower> CreateAsync(Transform tower);
    }
}
