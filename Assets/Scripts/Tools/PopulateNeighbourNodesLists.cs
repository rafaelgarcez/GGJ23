using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

public class PopulateNeighbourNodesLists : MonoBehaviour
{
#if UNITY_EDITOR

    [SerializeField] NodeController nodeController;
    int[] nodesOnRight = { 4, 9, 14, 19, 24, 29, 34, 39 };
    int[] nodesOnLeft = { 0, 5, 10, 15, 20, 25, 30, 35 };

    [Button]
    void PopulateNeighbours()
    {
        Debug.Log("PopulateNeighbours Start");

        for (int i = 0; i < 40; i++)
        {
            Debug.Log(i);
            nodeController.NodeList[i].NeighbourList = new Node[4];

            SetTop(i, nodeController.NodeList[i]);
            SetBottom(i, nodeController.NodeList[i]);
            SetRigth(i, nodeController.NodeList[i]);
            SetLeft(i, nodeController.NodeList[i]);
        }

        Debug.Log("PopulateNeighbours End");
    }


    void SetTop(int index, Node node)
    {
        if (index <= 4)
        {
            node.NeighbourList[0] = null;
            return;
        }

        node.NeighbourList[0] = nodeController.NodeList[index - 5];
    }

    void SetBottom(int index, Node node)
    {
        if (index >= 35)
        {
            node.NeighbourList[2] = null;
            return;
        }

        node.NeighbourList[2] = nodeController.NodeList[index + 5];
    }
    void SetRigth(int index, Node node)
    {

        if (nodesOnRight.Contains(index))
        {
            node.NeighbourList[1] = null;
            return;
        }

        node.NeighbourList[1] = nodeController.NodeList[index + 1];
    }

    void SetLeft(int index, Node node)
    {

        if (nodesOnLeft.Contains(index))
        {
            node.NeighbourList[3] = null;
            return;
        }

        node.NeighbourList[3] = nodeController.NodeList[index - 1];
    }

    [Button]
    void ClearAllNodeInfos()
    {
        Debug.Log("ClearAllNodeInfos Start");
        foreach (Node item in nodeController.NodeList)
        {
            item.currentNodeInfo = null;
            item.UpdateNodeImage();
        }

        Debug.Log("ClearAllNodeInfos End");
    }

#endif
}
