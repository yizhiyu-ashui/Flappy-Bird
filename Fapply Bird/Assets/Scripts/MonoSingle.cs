using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 单例模式
/// scy/2018-09-14
/// </summary>
public abstract class MonoSingle<T>: MonoBehaviour
where T : MonoBehaviour
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            return _instance;
        }
    }

    protected virtual void Awake()
    {
        _instance = this as T;
    }
}
