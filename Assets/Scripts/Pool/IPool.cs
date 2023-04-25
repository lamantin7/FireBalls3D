using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Pool
{


    public interface IPool<T>
    {
        void Prewarm(int capacity);
        T Request();
        void Return(T member);

    }
}
