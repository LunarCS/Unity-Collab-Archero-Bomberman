using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class BombController : MonoBehaviour
{
    public static BombController Instance { get; private set; }

    [SerializeField] GameObject bombPrefab;
    [SerializeField] Explosion particleManager;
    [SerializeField] LayerMask layer;
    [SerializeField] Tilemap destructibleTileMap;

    Player player;
    public int ActiveBombs { get; set; }
    public int MaxBombs { get; set; }

    public int ExplosionRadius { get; set; }

    private void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        Instance = this;
    }

    private void Start()
    {
        player = GetComponentInParent<Player>();
        MaxBombs = 3;
        ExplosionRadius = 3;
    }

    public IEnumerator DropBomb(Vector3 pos, float fuseTimer, bool doubleBomb)
    {

        float gridX = Mathf.Round(pos.x) + 0.5f;
        float gridY = Mathf.Round(pos.y) + 0.5f;
        Vector2 bombGridPostion = new Vector2(gridX, gridY);




        GameObject bomb = Instantiate(bombPrefab, bombGridPostion, Quaternion.identity);
        Bomb bombClass = bomb.GetComponent<Bomb>();
        bombClass.DoubleBomb = doubleBomb;
        bombClass.FuseTimer = fuseTimer;
        yield return new WaitForSeconds(fuseTimer);
        Explode(bomb.transform.position, Vector2.up, ExplosionRadius, 1f);
        Explode(bomb.transform.position, Vector2.right, ExplosionRadius, 1f);
        Explode(bomb.transform.position, Vector2.down, ExplosionRadius, 1f);
        Explode(bomb.transform.position, Vector2.left, ExplosionRadius, 1f);
        Destroy(bomb);

    }

    void Explode(Vector2 position, Vector2 direction, int length, float explosionTime)
    {
        if (length <= 0)
            return;
        if (Physics2D.OverlapBox(position, Vector2.one / 2, 0f, layer))
        {
            ClearDestructible(position);
            return;
        }

        Explosion ps = Instantiate(particleManager);
        ps.transform.position = position;
        ps.ParticleChoice(0, explosionTime);
        position += direction;
        Explode(position, direction, length - 1, explosionTime);


    }

    private void ClearDestructible(Vector2 position)
    {
        Vector3Int cell = destructibleTileMap.WorldToCell(position);
        TileBase tile = destructibleTileMap.GetTile(cell);
        if (tile != null)
        {
            destructibleTileMap.SetTile(cell, null);
        }
    }
}
