using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class SaveLevelInfo : MonoBehaviour
{
#if UNITY_EDITOR

    [SerializeField] NodeInfo rock;
    [SerializeField] NodeController nodeController;
    [SerializeField] LevelInfo levelInfo;


    [Button]
    void SaveLevelInfoNodes()
    {
        Debug.Log("PopulateLevelInfoNodes Start");
        levelInfo.nodeInfosList = null;
        levelInfo.nodeInfosList = new NodeInfo[40];

        for (int i = 0; i < 40; i++)
        {
            Debug.Log(i);
            levelInfo.nodeInfosList[i] = nodeController.NodeList[i].currentNodeInfo;
        }

        Debug.Log("PopulateLevelInfoNodes End");
    }

    [Button]
    void ShowNodes()
    {
        for (int i = 0; i < 40; i++)
        {
            nodeController.NodeList[i].UpdateNodeImage();
        }
    }

    [Button]
    void FillWithRocks()
    {
        for (int i = 0; i < 40; i++)
        {
            nodeController.NodeList[i].currentNodeInfo = rock;
            nodeController.NodeList[i].UpdateNodeImage();
        }
    }

    [Button]
    void ShowLevelOnInfo()
    {
        Debug.Log("BuildLevelOnInfo Start");


        for (int i = 0; i < 40; i++)
        {
            Debug.Log(i);
            nodeController.NodeList[i].currentNodeInfo = levelInfo.nodeInfosList[i];
        }


        ShowNodes();
        Debug.Log("BuildLevelOnInfo End");


    }


#endif
}
