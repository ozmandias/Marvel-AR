using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName="CharacterInfo", menuName="Data/CharacterInfo", order=1)]
public class CharacterInfo : ScriptableObject {
    public string name = "";
    public string wiki = "";
    public Sprite powerGrid;
    public List<History> history = new List<History>();
    public PowerGrid powers;
}