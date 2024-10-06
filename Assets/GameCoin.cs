using UnityEngine;
using System.Collections.Generic;
using System.Collections;
public class PersistentCanvas : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}