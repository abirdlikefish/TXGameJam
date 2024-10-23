using UnityEngine;
//单例
//需要被继承 xxx : Singleton<xxx>
//获取单例 xxx.Instance
public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    [Header("Singleton")]
    static T instance;
    public static T Instance
    {
        get
        {
            if(instance == null)
                instance = Instantiate(Resources.Load<T>("Prefabs/" + typeof(T).Name));
            return instance;
        }
    }
    private void OnValidate()
    {
#if UNITY_EDITOR
        if(!Application.isPlaying && GetComponent<T>())
            gameObject.name = typeof(T).Name;
#endif
    }
}