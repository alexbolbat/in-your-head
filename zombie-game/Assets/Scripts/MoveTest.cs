using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZSG.Behaviour;
using ZSG.Objects;

public class MoveTest : MonoBehaviour
{
    public Attackable attackable;
    public Character target;

    private void Start()
    {
        attackable.SetTarget(target);
    }
}
