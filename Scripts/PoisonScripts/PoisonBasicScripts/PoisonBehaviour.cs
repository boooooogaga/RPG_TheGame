using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PoisonBehaviour : ScriptableObject
{
    public abstract void OnUse(GameObject player);
    public virtual void OnUpdate(GameObject player) { }
}
