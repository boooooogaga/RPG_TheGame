using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Items/Poison", fileName = "Poison")]
public class PoisonData : ItemData // тут ничего писать не нужно, класс для создания мечей через скриптбл обджект
{
    public List<PoisonBehaviour> behaviours;// сюда кидаем все способности и эффекты через испектор скриптами
}