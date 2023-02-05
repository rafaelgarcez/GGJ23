using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class LevelSelectButtonsManager : MonoBehaviour
{
    [SerializeField] GameFlow gameFlow;
    [SerializeField] SfxController sfxController;
    [SerializeField] CameraMovementController cameraMovementController;
    [SerializeField] TextMeshProUGUI wellDone;
    [SerializeField] Button[] LevelSelectButtons;
    [SerializeField] TextMeshProUGUI[] LevelSelectNumbers;

    bool buttonsLocked = true;

    public void ToggleLock(bool toggle)
    {
        buttonsLocked = toggle;
    }

    public void ToggleWellDone(bool toggle)
    {
        wellDone.gameObject.SetActive(toggle);
        wellDone.DOFade(0, 0.001f);
    }

    public void AnimateWellDone()
    {
        wellDone.DOFade(1, 1).From(0);
    }

    public void OnButtonClicked(int index)
    {
        if (buttonsLocked)
            return;

        ToggleWellDone(false);
        sfxController.PlayClick3();
        buttonsLocked = true;
        LevelSelectButtons[index].transform.DOPunchScale(new Vector3(-0.2f, -0.2f, -0.2f), 0.1f, 1, 0).OnComplete(() => StartLevel(index));

    }

    void StartLevel(int lvlIndex)
    {
        Debug.Log("Start LEvel!");
        gameFlow.StageSelected(lvlIndex);
        cameraMovementController.LevelSelected();
    }

}
