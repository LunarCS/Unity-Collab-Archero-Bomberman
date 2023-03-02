using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeContainer : MonoBehaviour
{
    private static UpgradeContainer instance;
    public static UpgradeContainer Instance { get { return instance; } }

    public List<Upgrade> upgrades;

    public Upgrade Health = new Upgrade();

    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        instance = this;
    }

    private void Start()
    {
        upgrades = new List<Upgrade>();
    }


}
