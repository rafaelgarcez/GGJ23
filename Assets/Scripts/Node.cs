using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Node : MonoBehaviour
{
    [SerializeField] GameFlow gameFlow;
    [SerializeField] NodeController nodeController;
    public NodeInfo currentNodeInfo;
    [SerializeField] Button nodeButton;
    [SerializeField] Image nodeImage;
    [SerializeField] Transform imageTransform;
    public Node[] NeighbourList;

    Sequence animationSequence;
    void Start()
    {
        nodeButton.onClick.AddListener(OnNodeButtonClicked);
        animationSequence = DOTween.Sequence();
        animationSequence.Append(imageTransform.DOPunchScale(new Vector3(-0.2f, -0.2f, -0.2f), 0.1f, 1, 0));
        animationSequence.SetAutoKill(false);
        //animationSequence.Pause();
        //UpdateNodeImage();
    }

    void OnNodeButtonClicked()
    {
        if (gameFlow.ClickIsBlocked())
            return;

        if (currentNodeInfo != null)
        {
            if (currentNodeInfo.CheckIfIsImmovable() || currentNodeInfo.CheckIfIsEndNode())
                return;

            AnimateNodeImage();
        }

        nodeController.NodeClicked(this);

    }

    public void AnimateNodeImage()
    {
        animationSequence.Restart();
    }

    public void UpdateNodeImage()
    {
        if (currentNodeInfo == null)
        {
            nodeImage.enabled = false;
            return;
        }

        nodeImage.sprite = currentNodeInfo.GetNodeSprite();
        nodeImage.enabled = true;

    }

    public void UpdateNode(NodeInfo newNodeInfo)
    {
        currentNodeInfo = newNodeInfo;
        UpdateNodeImage();
    }

}
