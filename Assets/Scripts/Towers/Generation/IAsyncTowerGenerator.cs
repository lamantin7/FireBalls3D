using UnityEngine;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace Towers.Generation
{
   public interface IAsyncTowerGenerator
    {
        Task<Tower> CreateAsync(Transform tower);
    }
  
}
