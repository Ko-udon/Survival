using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]

public class GameData
{
    public bool viewedTutorial;
    public string stage;
    public string characterType;

    public float hp;
    public int level;
    public int exp;

    public List<string> ownSkill;
    public int ballLV;
    public int knockbackLV;
    public int tauntLV;
    public int nautilusLV;
    public int virusLV;
}
