using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class LogoAnimationController : MonoBehaviour
{

    [SerializeField] GameObject thanks;
    [SerializeField] LevelSelectButtonsManager levelSelectButtonsManager;
    [SerializeField] TextMeshProUGUI gameName;

    [SerializeField] TextMeshProUGUI madeBy;
    [SerializeField] Image logo;

    [SerializeField] CanvasGroup butonsGroup, butonsGroup2;
    public bool ShowThanks;

    void Start()
    {
        StartCoroutine(FirstAnimation());
        //ShowNumbers();
    }

    IEnumerator FirstAnimation()
    {
        gameName.DOFade(0, 0.001f);
        logo.DOFade(0, 0.001f);
        madeBy.DOFade(0, 0.001f);
        butonsGroup.alpha = 0;
        butonsGroup.gameObject.SetActive(false);
        butonsGroup2.alpha = 0;
        butonsGroup2.gameObject.SetActive(false);

        logo.gameObject.SetActive(true);
        madeBy.gameObject.SetActive(true);

        yield return new WaitForSeconds(1);
        gameName.DOFade(1, 1f).From(0);

        yield return new WaitForSeconds(1);
        madeBy.DOFade(1, 1f).From(0);
        logo.DOFade(1, 1f).From(0);

        yield return new WaitForSeconds(3);
        madeBy.DOFade(0, 1f).From(1);
        logo.DOFade(0, 1f).From(1);

        yield return new WaitForSeconds(1);

        ShowNumbers();

        yield return new WaitForSeconds(0.2f);

        if (ShowThanks)
            thanks.SetActive(true);

    }

    void ShowNumbers()
    {
        butonsGroup.gameObject.SetActive(true);
        butonsGroup.DOFade(1, 1f).OnComplete(() => levelSelectButtonsManager.ToggleLock(false));
        butonsGroup2.gameObject.SetActive(true);
        butonsGroup2.DOFade(1, 1f).OnComplete(() => levelSelectButtonsManager.ToggleLock(false));
    }

}
