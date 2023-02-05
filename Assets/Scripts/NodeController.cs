using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class NodeController : MonoBehaviour
{
    [SerializeField] SfxController sfxController;
    [SerializeField] GameFlow gameFlow;
    [SerializeField] GameObject selectedMarker;
    public Node[] NodeList;
    Node firstNode;

    [Header("Game Flow")]
    [SerializeField] Node startNode;
    [SerializeField] Node secondStartNode;
    Sequence markerAnimationSequence;

    bool checkingSecondPath = false;

    private void Start()
    {
        markerAnimationSequence = DOTween.Sequence();
        markerAnimationSequence.Append(selectedMarker.transform.DOPunchScale(new Vector3(-0.1f, -0.1f, -0.1f), 0.1f, 1, 0));
        markerAnimationSequence.SetAutoKill(false);
    }

    public void SetStartNodes(Node node, Node node2)
    {
        startNode = node;
        secondStartNode = node2;
    }

    public void NodeClicked(Node selectedNode)
    {
        gameFlow.ToggleCanClick(false);

        if (firstNode == selectedNode)
        {
            selectedMarker.SetActive(false);
            firstNode = null;
            gameFlow.ToggleCanClick(true);
            sfxController.PlayClick1();
            return;
        }

        if (firstNode == null)
        {
            sfxController.PlayClick3();
            firstNode = selectedNode;
            selectedMarker.transform.position = firstNode.transform.position;
            selectedMarker.SetActive(true);
            markerAnimationSequence.Restart();
            gameFlow.ToggleCanClick(true);
            return;
        }

        //Swap
        sfxController.PlayClick2();
        selectedMarker.SetActive(false);
        NodeInfo tempNodeInfo = selectedNode.currentNodeInfo;
        selectedNode.UpdateNode(firstNode.currentNodeInfo);
        firstNode.UpdateNode(tempNodeInfo);
        selectedNode.AnimateNodeImage();
        firstNode = null;
        StartFlowCheck();

    }

    void StartFlowCheck()
    {
        checkingSecondPath = false;

        if (startNode.currentNodeInfo == null)
        {
            //   Debug.Log("Node on start is null. END");
            gameFlow.ToggleCanClick(true);
            return;
        }

        if (startNode.currentNodeInfo.ContaisEntry(0))
        {
            //  Debug.Log("Node on start contais entry 0. CONTINUE! ");
            FlowCheck(startNode.NeighbourList[startNode.currentNodeInfo.ReturnNeighbourIndex(0)], startNode.currentNodeInfo.ReturnNeighbourIndex(0));
        }
        else
        {
            //  Debug.Log("Node on start does not contais entry 0. END");
            gameFlow.ToggleCanClick(true);
            return;
        }
    }

    void StartSecondFlowCheck()
    {
        checkingSecondPath = true;
        if (secondStartNode.currentNodeInfo == null)
        {
            // Debug.Log("Second Node on start is null. END");
            gameFlow.ToggleCanClick(true);
            return;
        }

        if (secondStartNode.currentNodeInfo.ContaisEntry(0))
        {
            //  Debug.Log("Second Node on start contais entry 0. CONTINUE! ");
            FlowCheck(secondStartNode.NeighbourList[secondStartNode.currentNodeInfo.ReturnNeighbourIndex(0)], secondStartNode.currentNodeInfo.ReturnNeighbourIndex(0));
        }
        else
        {
            //  Debug.Log("Second Node on start does not contais entry 0. END");
            gameFlow.ToggleCanClick(true);
            return;
        }
    }


    void FlowCheck(Node currentNode, byte exitIndex)
    {
        byte entryIndex = GetEntryIndex(exitIndex);

        //Debug.Log("Node " + currentNode.name + " reached and entered on index: " + exitIndex);

        if (currentNode == null)
        {
            gameFlow.ToggleCanClick(true);
            return;
        }


        if (currentNode.currentNodeInfo == null)
        {
            //   Debug.Log("Node info is null. END");
            gameFlow.ToggleCanClick(true);
            return;
        }

        if (currentNode.currentNodeInfo.CheckIfIsImmovable())
        {
            // Debug.Log("is immovable ! END");
            gameFlow.ToggleCanClick(true);
            return;
        }

        if (currentNode.currentNodeInfo.CheckIfIsEndNode())
        {
            if (currentNode.currentNodeInfo.GetEndEntryIndex() == entryIndex)
            {
                // Debug.Log("is end node!");
                EndReached();
                return;
            }
            else
            {
                // Debug.Log("exit node does not have entry om " + entryIndex + ". ENDD: ");
                gameFlow.ToggleCanClick(true);
                return;
            }
        }

        if (currentNode.currentNodeInfo.ContaisEntry(entryIndex))
        {
            // Debug.Log("current node contais entry on " + entryIndex + ". CONTINUE!");
            FlowCheck(currentNode.NeighbourList[currentNode.currentNodeInfo.ReturnNeighbourIndex(entryIndex)], currentNode.currentNodeInfo.ReturnNeighbourIndex(entryIndex));
        }
        else
        {
            //  Debug.Log("current node does not contais entry on " + entryIndex + ". ENDD: ");
            gameFlow.ToggleCanClick(true);
        }

    }

    void EndReached()
    {

        if (secondStartNode == null)
        {
            gameFlow.LevelCleared();
            return;
        }

        if (checkingSecondPath)
            gameFlow.LevelCleared();
        else
            StartSecondFlowCheck();


    }

    private byte GetEntryIndex(byte exitIndex)
    {
        byte entryIndex = 99;
        //pick the entry index by the previous node exit
        switch (exitIndex)
        {
            case 0:
                entryIndex = 2;
                break;

            case 1:
                entryIndex = 3;
                break;

            case 2:
                entryIndex = 0;
                break;

            case 3:
                entryIndex = 1;
                break;

            default:
                Debug.LogError("entry index error!");
                break;
        }

        return entryIndex;
    }
}
