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
    public void DropBomb(Vector3 pos, Quaternion rotation, float fuseTimer, bool doubleBomb)
    {
        if (GameController.Instance.activeBombs >= GameController.Instance.maxBombs)
        {
            return;
        }

        GameObject bomb = Instantiate(bombPrefab, pos, rotation);
        Bomb bombClass = bomb.GetComponent<Bomb>();
        bombClass.doubleBomb = doubleBomb;
        bombClass.fuseTimer = fuseTimer;
        Destroy(bomb, fuseTimer);
    }
}
