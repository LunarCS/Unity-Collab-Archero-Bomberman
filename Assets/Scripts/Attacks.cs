using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour
{
    private static Attacks instance;
    public static Attacks Instance { get { return instance; } }
    public float fuseTimer;
    public bool doubleBomb;
    [SerializeField] GameObject bombPrefab;

    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        instance = this;
    }
    public void DropBomb()
    {
        if (GameController.Instance.activeBombs >= GameController.Instance.maxBombs)
        {
            return;
        }

        bool originalMultipleBombValue = doubleBomb;
        float originalFuseTimer = fuseTimer;

    instantiateAgain:
        GameObject bomb = Instantiate(bombPrefab, transform.position, Quaternion.identity);
        Bomb bombClass = bomb.GetComponent<Bomb>();
        Destroy(bomb, fuseTimer);
        if (doubleBomb)
        {
            doubleBomb = false;
            fuseTimer -= 1f;
            goto instantiateAgain;
        }
        doubleBomb = originalMultipleBombValue;
        fuseTimer = originalFuseTimer;
    }
}
