using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehaviour : ScriptableObject //общий класс для прописывания всяких способностей для шмоток
{
    public virtual void OnUsePlayerEffect(GameObject player) { }
    public virtual void OnUseEnemyEffect(GameObject enemy) { }
    public virtual void OnUpdate(GameObject player, GameObject target) { }
}
