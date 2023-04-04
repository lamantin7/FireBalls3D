using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


namespace TowerGeneration
{
    [CreateAssetMenu(fileName = "TowerFactory", menuName = "ScriptableObjects/Tower/Factory")]
    public class SOTowerFactory : ScriptableObject, IAsyncTowerFactory
    {
        Task<Tower>  CreateAsync(Transform tower)
        {
            return null;
        }

        Task<Tower> IAsyncTowerFactory.CreateAsync(Transform tower)
        {
            throw new NotImplementedException();
        }
    }
}
