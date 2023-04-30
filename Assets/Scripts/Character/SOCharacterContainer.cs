using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterConatiner", menuName = "ScriptableObjects/Character/CharacterContainer")]
public class SOCharacterContainer : ScriptableObject
{
    public Character CharacterPrefab;

    public Character Create(Transform parent)=>
        Instantiate(CharacterPrefab, parent);
}
