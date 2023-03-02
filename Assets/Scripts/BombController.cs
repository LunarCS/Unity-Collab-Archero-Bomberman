using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    public static BombController Instance { get; private set; }

    [SerializeField] GameObject bombPrefab;
    [SerializeField] GameObject particlePrefab;
    Player player;
    public int ActiveBombs { get; set; }
    public int MaxBombs { get; set; }

    [SerializeField] ParticleSystem explosion;
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
    }

    public void DropBomb(Vector3 pos, float fuseTimer, bool doubleBomb)
    {
        if (ActiveBombs >= MaxBombs)
        {
            return;
        }
        float gridX = Mathf.Round(pos.x + 0.5f) - 0.5f;
        float gridY = Mathf.Round(pos.y + 0.5f) - 0.5f;



        GameObject bomb = Instantiate(bombPrefab, new Vector2(gridX, gridY), Quaternion.identity);
        Bomb bombClass = bomb.GetComponent<Bomb>();
        bombClass.DoubleBomb = doubleBomb;
        bombClass.FuseTimer = fuseTimer;
        GameObject ps = Instantiate(particlePrefab);
        ps.transform.position = bomb.transform.position;

        Explode(bomb.transform.position, Vector2.up, ExplosionRadius, 1f);
        Explode(bomb.transform.position, Vector2.right, ExplosionRadius, 1f);
        Explode(bomb.transform.position, Vector2.down, ExplosionRadius, 1f);
        Explode(bomb.transform.position, Vector2.left, ExplosionRadius, 1f);
        Destroy(bomb, fuseTimer);
    }

    void Explode(Vector2 position, Vector2 direction, int length, float explosionTime)
    {
        if (length <= 0)
            return;

        position += direction;
        GameObject ps = Instantiate(particlePrefab);
        ps.transform.position = transform.position;
        Destroy(ps, explosionTime);
        Explode(position, direction, length - 1, explosionTime);


    }





}
