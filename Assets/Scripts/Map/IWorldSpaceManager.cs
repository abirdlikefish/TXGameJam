using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWorldSpaceManager
{
    public bool AddCube(BaseCube cube);
    public bool RemoveCube(BaseCube cube);
    public List<BaseCube> GetCubes();
    public BaseCube FindByPosition(Vector3Int position);
}
