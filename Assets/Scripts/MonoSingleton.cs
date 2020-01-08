using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MonoSingleton<T> : MonoBehaviour where T: MonoSingleton<T>
{
    private static MonoSingleton<T> _instance;

    public static MonoSingleton<T> Instance
    {
        get
        {
            if (_instance == null)

            {
                Debug.LogError($"Instance of type {typeof(T)} is NULL");
            }

            return _instance;
        }
    }

    private void Awake()
    {
        _instance = (T)this;
    }
    

       
    


}
