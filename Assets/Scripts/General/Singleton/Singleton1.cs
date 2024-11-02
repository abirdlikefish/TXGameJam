using UnityEngine;
//单例
//需要被继承 xxx : Singleton<xxx,Ixxx>,Ixxx
//获取单例 xxx.Instance
public class Singleton1<T> : MonoBehaviour where T : Singleton1<T>
{
    [Header("Singleton")]
    static T instance;
    public static T Instance
    {
        get
        {
            if(instance == null)
            {
                instance = Instantiate(Resources.Load<T>("Prefabs/" + typeof(T).Name));
            }
            return instance;
        }
    }
    public virtual void Init(){ Debug.Log(name + " Init 1"); }
    private void OnValidate()
    {
#if UNITY_EDITOR
        if(!Application.isPlaying && GetComponent<T>())
            gameObject.name = typeof(T).Name;
#endif
    }
}