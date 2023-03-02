using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour
{
    private static Attacks instance;
    public static Attacks Instance { get { return instance; } }
    public bool doubleBomb;
    [SerializeField] GameObject bombPrefab;

    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        instance = this;
    }

}
