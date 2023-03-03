using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Entity
{
    protected GameObject abilityPrefab;
    protected float abilityRate;
    protected int xp;

    private void OnDestroy()
    {
        if (Player.Instance != null)
            Level.Instance.GainXP(xp);
    }



}
