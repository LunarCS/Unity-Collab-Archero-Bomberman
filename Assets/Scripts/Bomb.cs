using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Bomb : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject particlePrefab;
    public string owner;
    public Tilemap destructibleTilemap;
    public bool doubleBomb;
    public float fuseTimer;
    Tilemap tilemap;
    GridLayout grid;

    private void Start()
    {
        GameController.Instance.activeBombs++;

    }

    private void OnDestroy()
    {
        if (doubleBomb)
        {
            Attacks.Instance.DropBomb(transform.position, transform.rotation, Mathf.Clamp(fuseTimer - 1, 0.5f, fuseTimer), false);
        }
        Explode();

    }

    private void Explode()
    {
        GameObject ps = GameObject.Instantiate(particlePrefab);
        ps.transform.position = transform.position;
        Destroy(ps, 2f);
        CheckNearby();
        GameController.Instance.activeBombs--;

        void CheckNearby()
        {
            Collider2D[] nearbyObjects = Physics2D.OverlapCircleAll(transform.position, 1f);
            for (int i = 0; i < nearbyObjects.Length; i++)
            {
                Debug.Log(nearbyObjects[i]);
                if (nearbyObjects[i].CompareTag("Destructible"))
                    Destroy(nearbyObjects[i].gameObject);

                if (nearbyObjects[i].CompareTag("Player") && owner != "Player")
                {
                    // Damage Player
                }
            }
        }
    }

}
