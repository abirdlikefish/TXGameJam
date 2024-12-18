using UnityEngine;
//单例
//需要被继承 xxx : Singleton<xxx,Ixxx>,Ixxx
//获取单例 xxx.Instance
public class Singleton<T,TI> : MonoBehaviour where T : Singleton<T,TI>,TI
{
    [Header("Singleton")]
    static T instance;
    public static TI Instance
    {
        get
        {
            if(instance == null)
            {
                //instance = Instantiate(Resources.Load<T>("Prefabs/" + typeof(T).Name));
                instance = new GameObject(typeof(T).Name).AddComponent<T>();
                instance.Init();
            }
            return instance;
        }
    }
    protected virtual void Init(){ Debug.Log(name + " Init"); }
    private void OnValidate()
    {
#if UNITY_EDITOR
        if(!Application.isPlaying && GetComponent<T>())
            gameObject.name = typeof(T).Name;
#endif
    }
}