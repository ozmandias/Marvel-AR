using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="CharacterInfo", menuName="Data/CharacterInfo", order=1)]
public class CharacterInfo : ScriptableObject {
    public string name = "";
    public string wiki = "";
    public List<History> history = new List<History>();
    public PowerGrid powers;
}