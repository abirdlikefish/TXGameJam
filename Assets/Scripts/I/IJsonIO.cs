using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IJsonIO<T>
{
    void SaveJson(string f_pathPre, string f_name);
    T LoadJson(string f_pathPre, string f_name);
}
