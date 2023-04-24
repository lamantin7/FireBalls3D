using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Factory {
    public interface IFactory <out T>
    {
        T Create();
    }
}
