using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IJsonIO<T>
{
    void SaveJson();
    T LoadJson();
}
