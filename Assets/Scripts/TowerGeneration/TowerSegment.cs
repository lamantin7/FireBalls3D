using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSegment : MonoBehaviour
{
    public void SetMaterial(Material material)=>GetComponent<MeshRenderer>().sharedMaterial = material;
    

}
