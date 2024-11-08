using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public LevelManager LevelManager { get; private set; }

    void Awake()
    {
        // Menonaktifkan semua object child
        foreach (Transform child in transform)
        {
            if (child.GetComponent<Canvas>() != null || child.GetComponent<UnityEngine.UI.Image>() != null)
            {
                child.gameObject.SetActive(false);
            }
        }

        // Singleton pattern
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;
        LevelManager = GetComponentInChildren<LevelManager>();

        // Menandai object agar tidak dihancurkan saat berpindah scene
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(GameObject.Find("Camera"));
    }
}

