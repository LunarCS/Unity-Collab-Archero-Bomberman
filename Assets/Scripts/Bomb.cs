using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Bomb : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject particlePrefab;
    public string Owner { get; set; }
    [SerializeField] Tilemap destructibleTilemap;
    public bool DoubleBomb { get; set; }
    public float fuseTimer { get; set; }
    Tilemap tilemap;
    GridLayout grid;

    private void Start()
    {
        GameController.Instance.ActiveBombs++;

    }

    private void OnDestroy()
    {
        if (DoubleBomb)
        {
            Attacks.Instance.DropBomb(transform.position, transform.rotation, Mathf.Clamp(fuseTimer - 1, 0.5f, fuseTimer), false);
        }
        Explode();

    }

    private void Explode()
    {
        GameObject ps = Instantiate(particlePrefab);
        ps.transform.position = transform.position;
        Destroy(ps, 2f);
        CheckNearby();
        GameController.Instance.ActiveBombs--;

        void CheckNearby()
        {
            Collider2D[] nearbyObjects = Physics2D.OverlapCircleAll(transform.position, 1f);
            for (int i = 0; i < nearbyObjects.Length; i++)
            {
                Debug.Log(nearbyObjects[i]);
                if (nearbyObjects[i].CompareTag("Destructible"))
                    Destroy(nearbyObjects[i].gameObject);

                if (nearbyObjects[i].CompareTag("Player") && Owner != "Player")
                {
                    // Damage Player
                }
            }
        }
    }

}
