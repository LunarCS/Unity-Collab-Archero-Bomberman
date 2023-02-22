using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject particlePrefab;
    public string owner;

    private void Start()
    {
        GameController.Instance.activeBombs++;
    }

    private void OnDestroy()
    {
        GameObject ps = GameObject.Instantiate(particlePrefab);
        ps.transform.position = transform.position;
        Destroy(ps, 2f);
        Collider2D[] nearbyObjects = Physics2D.OverlapCircleAll(transform.position, 1f);
        for (int i = 0; i < nearbyObjects.Length; i++)
        {
            if (nearbyObjects[i].CompareTag("Destructible"))
                Destroy(nearbyObjects[i].gameObject);

            if (nearbyObjects[i].CompareTag("Player") && owner != "Player")
            {
                // Damage Player
            }
        }
        GameController.Instance.activeBombs--;
    }

}
