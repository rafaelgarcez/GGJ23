using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelInfo", menuName = "ScriptableObjects/LevelInfo", order = 2)]
public class LevelInfo : SerializedScriptableObject
{
    public int NumberOfExits;

    public string TreeName;
    public int StartNodeIndex;

    public int SecondStartNodeIndex;
    public string SecondTreeName;

    public NodeInfo[] nodeInfosList;

}
