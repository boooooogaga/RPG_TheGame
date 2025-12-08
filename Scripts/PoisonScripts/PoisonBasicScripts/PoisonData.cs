using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Items/Poison", fileName = "Poison")]
public abstract class PoisonData : ScriptableObject
{
    public List<PoisonBehaviour> behaviours;// свойства для меча
}