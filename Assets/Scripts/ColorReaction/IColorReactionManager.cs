using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IColorReactionManager
{
    public void AddNewColorReaction(int color , int reactionID);
    public void CleanColorReaction();
    public void InvokeColorReaction(int color , Vector3Int position);

}
