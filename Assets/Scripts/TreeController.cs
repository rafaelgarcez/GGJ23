using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

public class TreeController : SerializedMonoBehaviour
{
    [SerializeField] TreeVisualController leftTrees, centerTrees, rightTrees;

    string leftTreeName, centerTreeName, rightTreeName;
    bool showing2Trees = false;

    public void SetupTree(string treeName)
    {
        showing2Trees = false;
        centerTreeName = treeName;
        ActivateBadTree();
    }
    public void SetupTrees(string tree1, string tree2)
    {
        showing2Trees = true;
        leftTreeName = tree1;
        rightTreeName = tree2;
        ActivateBadTree();
    }

    public void ActivateBadTree()
    {
        if (showing2Trees)
        {
            leftTrees.ActivateBadTree(leftTreeName);
            rightTrees.ActivateBadTree(rightTreeName);
        }
        else
            centerTrees.ActivateBadTree(centerTreeName);
    }

    public void ShowHealthyTree()
    {

        if (showing2Trees)
        {
            leftTrees.ShowHealthyTree(leftTreeName);
            rightTrees.ShowHealthyTree(rightTreeName);
        }
        else
            centerTrees.ShowHealthyTree(centerTreeName);
    }

    public void HideTrees()
    {
        if (showing2Trees)
        {
            leftTrees.HideTrees(leftTreeName);
            rightTrees.HideTrees(rightTreeName);
        }
        else
            centerTrees.HideTrees(centerTreeName);
    }
}
