using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score_Singleton : MonoBehaviour
{
   public static Score_Singleton Instance { get; private set; }

    public float High_Score = 0.0f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else 
        {
            Destroy(gameObject);
        }
    }
}
