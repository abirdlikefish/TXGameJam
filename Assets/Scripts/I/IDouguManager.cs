using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDouguManager
{
    public void GenerateRandomDouguSphere();
    public void GenerateDouguSphere(Type type, Vector3 pos, int cId);
    public bool AddSth(GameObject go);
    public bool RemoveSth(GameObject go);
    public bool HasAny(Vector3 pos);
    public bool Has<T1>(Vector3 pos) where T1 : MonoBehaviour;
    public bool HasEither<T1, T2>(Vector3 pos) where T1 : MonoBehaviour where T2 : MonoBehaviour;

    public void OnEnterLevel();
    public void OnExitLevel();
    public void OnEnterTinyLevel();
    public void OnExitTinyLevel();
}
