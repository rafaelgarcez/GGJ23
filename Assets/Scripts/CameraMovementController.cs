using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraMovementController : MonoBehaviour
{
    [SerializeField] GameFlow gameFlow;
    [SerializeField] LevelSelectButtonsManager levelSelectButtonsManager;
    [SerializeField] SfxController sfxController;
    [SerializeField] Transform cameraTransform;

    float logo = 17.1f;
    float tree = 8.7f;
    float game = 0.35f;

    public void LevelSelected()
    {
        cameraTransform.DOMoveY(tree, 1.5f).SetEase(Ease.OutFlash);
        StartCoroutine(MoveToGame());
    }

    IEnumerator MoveToGame()
    {
        //yield return new WaitForSeconds(0.1f);
        yield return new WaitForSeconds(3);
        cameraTransform.DOMoveY(game, 2).SetEase(Ease.OutFlash).OnComplete(() => gameFlow.ToggleCanClick(true));
    }

    public void StartLevelCompleteSequence()
    {
        StartCoroutine(LevelComplete());
    }

    IEnumerator LevelComplete()
    {
        yield return new WaitForSeconds(0.1f);


        sfxController.PlayFinished();
        yield return new WaitForSeconds(0.5f);
        cameraTransform.DOMoveY(tree, 2).SetEase(Ease.OutFlash);
        yield return new WaitForSeconds(2f);
        gameFlow.ShowHealthyTree();
        levelSelectButtonsManager.ToggleWellDone(true);
        levelSelectButtonsManager.AnimateWellDone();
        sfxController.PlayTreeReveal();
        yield return new WaitForSeconds(2f);

        cameraTransform.DOMoveY(logo, 2).SetEase(Ease.OutFlash).OnComplete(() =>
        {
            levelSelectButtonsManager.ToggleLock(false);
            gameFlow.HideTrees();
        });
    }

}
