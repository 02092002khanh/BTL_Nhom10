using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CharacterDatabase : ScriptableObject
{
    public Character[] _character;

    public int _characterCount
    {
        get
        {
            return _character.Length;
        }
    }
    
    public Character GetCharacter(int index)
    {
        return _character[index];
    }
}
