using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    private static GameController instance;
    public static GameController Instance { get { return instance; } }

    public int ActiveBombs { get; set; }
    public int MaxBombs { get; set; }
    // Start is called before the first frame update
    void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        instance = this;
    }
    private void Start()
    {
        MaxBombs = 3;
    }
}
