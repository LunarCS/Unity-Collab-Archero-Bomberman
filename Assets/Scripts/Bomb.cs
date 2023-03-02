using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Bomb : MonoBehaviour
{
    // Start is called before the first frame update
    
    public string Owner { get; set; }
    [SerializeField] Tilemap destructibleTilemap;
    public bool DoubleBomb { get; set; }
    public float FuseTimer { get; set; }
    Tilemap tilemap;
    GridLayout grid;

    private void Start()
    {
        BombController.Instance.ActiveBombs++;

    }

    private void OnDestroy()
    {
        BombController.Instance.ActiveBombs--;

    }

}
