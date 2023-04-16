using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPool<T>
{
    void Prewarm(int capacity);
    T Request();
    void Return(T member);
}
