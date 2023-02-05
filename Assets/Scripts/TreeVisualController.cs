using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

public class TreeVisualController : SerializedMonoBehaviour
{
    [SerializeField] Dictionary<string, SpriteRenderer> Trees;

    public void ActivateBadTree(string treeName)
    {
        Trees[treeName + "-Bad"].gameObject.SetActive(true);
    }

    public void ShowHealthyTree(string treeName)
    {
        Trees[treeName].gameObject.SetActive(true);
        Trees[treeName].DOFade(1, 1).From(0);
    }

    public void HideTrees(string treeName)
    {
        Trees[treeName].gameObject.SetActive(false);
        Trees[treeName + "-Bad"].gameObject.SetActive(false);
    }

}
