using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameFlow : MonoBehaviour
{
    [SerializeField] PlayerProgressionController progressionController;
    [SerializeField] TreeController treeController;
    [SerializeField] CameraMovementController cameraMovementController;
    [SerializeField] NodeController nodeController;
    [SerializeField] LevelInfo[] levelInfoList;

    [SerializeField] GameObject[] startingPoints;
    // [SerializeField] int index;
    LevelInfo currentLevelInfo;

    int currentLevelIndex;
    bool canClick;

    private void Start()
    {
        //canClick = true;

        // BuildStage(levelInfoList[index]);
    }

    public void ToggleCanClick(bool toggle) => canClick = toggle;

    public bool ClickIsBlocked() => !canClick;

    public void StageSelected(int index)
    {
        Debug.Log("StageSelected: " + index);
        currentLevelIndex = index;
        BuildStage(levelInfoList[index]);
    }
    void BuildStage(LevelInfo info)
    {
        Debug.Log("BuildStage: " + info.name);
        currentLevelInfo = info;

        for (int i = 0; i < 40; i++)
        {
            nodeController.NodeList[i].currentNodeInfo = currentLevelInfo.nodeInfosList[i];
            nodeController.NodeList[i].UpdateNodeImage();
        }

        if (currentLevelInfo.NumberOfExits == 1)
        {
            treeController.SetupTree(currentLevelInfo.TreeName);
            SetStartingPoints(currentLevelInfo.StartNodeIndex);
            nodeController.SetStartNodes(nodeController.NodeList[currentLevelInfo.StartNodeIndex], null);
        }
        else
        {
            treeController.SetupTrees(currentLevelInfo.TreeName, currentLevelInfo.SecondTreeName);
            SetStartingPoints(currentLevelInfo.StartNodeIndex, currentLevelInfo.SecondStartNodeIndex);
            nodeController.SetStartNodes(nodeController.NodeList[currentLevelInfo.StartNodeIndex], nodeController.NodeList[currentLevelInfo.SecondStartNodeIndex]);
        }

    }

    public void LevelCleared()
    {
        Debug.Log("Level cleared!");
        progressionController.NewLevelUnlocked(currentLevelIndex + 2);
        cameraMovementController.StartLevelCompleteSequence();

    }

    public void ShowHealthyTree()
    {
        treeController.ShowHealthyTree();
    }

    public void HideTrees()
    {
        treeController.HideTrees();
    }

    void SetStartingPoints(int i)
    {
        startingPoints[1].SetActive(false);
        startingPoints[2].SetActive(false);
        startingPoints[3].SetActive(false);

        startingPoints[i].SetActive(true);

    }

    void SetStartingPoints(int i, int i2)
    {
        startingPoints[1].SetActive(false);
        startingPoints[2].SetActive(false);
        startingPoints[3].SetActive(false);

        startingPoints[i].SetActive(true);
        startingPoints[i2].SetActive(true);

    }
}
