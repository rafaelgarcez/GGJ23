using System;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "NodeInfo", menuName = "ScriptableObjects/NodeInfo", order = 1)]
public class NodeInfo : SerializedScriptableObject
{

    [SerializeField] Sprite nodeSprite;
    [SerializeField] bool isImmovable;
    [SerializeField] Dictionary<byte, byte> EntriesAndExits;

    [Header("End Node")]

    [SerializeField] bool isEndNode;
    [SerializeField] byte endNodeEntry;


    public Sprite GetNodeSprite()
    {
        return nodeSprite;
    }

    public bool CheckIfIsImmovable() => isImmovable;

    public bool CheckIfIsEndNode() => isEndNode;

    public bool ContaisEntry(byte entry)
    {
        return EntriesAndExits.ContainsKey(entry);
    }

    public byte ReturnNeighbourIndex(byte entry)
    {
        return EntriesAndExits[entry];
    }

    public byte GetEndEntryIndex()
    {
        return endNodeEntry;
    }

}


