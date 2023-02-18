using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    // Start is called before the first frame update

    private void Start()
    {
        GameController.Instance.activeBombs++;
    }

    private void OnDestroy()
    {
        GameController.Instance.activeBombs--;
    }

}
