using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "SwordBehaviours/TeleportStrike")]
public class TeleportBehaviour : ItemBehaviour

{
    public float distance;
    public override void OnUsePlayerEffect(GameObject player)
    {
        player.transform.position += player.transform.forward * distance;
    }
}
