using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public float initialGameSpeed = 5.0f;
    public float gameSpeedIncrease = 0.1f;
    public float gameSpeed = 1.0f;

    private Spawner spawner;
    
    // Start is called before the first frame update
    void Start()
    {
        spawner = FindAnyObjectByType<Spawner>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
