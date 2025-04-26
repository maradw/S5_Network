using UnityEngine;

public abstract class ScriptableObjectSingleton<T> : ScriptableObject where T : ScriptableObject
{
    private static T _instance = null;

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                T[] results = Resources.FindObjectsOfTypeAll<T>();
                Debug.Log(typeof(T).Name + " encontrados en Resources: " + results.Length);
                if (results.Length == 0)
                {
                    Debug.LogError("SingletonScriptableObject: No se encontró instancia de " + typeof(T).ToString());
                    return null;
                }
                if (results.Length > 1)
                {
                    Debug.LogError("SingletonScriptableObject: Hay más de una instancia de " + typeof(T).ToString());
                    return null;
                }
                _instance = results[0];
            }
            return _instance;
        }
    }

}
