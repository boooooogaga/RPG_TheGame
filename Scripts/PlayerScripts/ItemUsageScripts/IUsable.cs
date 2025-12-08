using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IUsable // общий класс для того чтобы прописывать поведение для предметов в руках
    //если предмет будет использоваться в руках то нужно добавить наследование этого класса в класс предмета и после перезаписать функции которые здесь
{
    void Use();
    Sprite GetFovSprite();
}
