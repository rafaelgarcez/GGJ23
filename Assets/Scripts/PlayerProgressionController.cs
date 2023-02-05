using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProgressionController : MonoBehaviour
{
    [SerializeField] LevelSelectButtonsManager levelSelectButtonsManager;
    [SerializeField] LogoAnimationController logoAnimationController;
    [SerializeField] GameObject thanks;

    int maxLevelReached;

    private void Start()
    {
        GetMaxLevel();
        //PlayerPrefs.SetInt("maxLevel", 9);
    }

    void GetMaxLevel()
    {
        maxLevelReached = 0;

        if (PlayerPrefs.HasKey("maxLevel"))
            maxLevelReached = PlayerPrefs.GetInt("maxLevel");

        Debug.Log("maxLevelReached: " + maxLevelReached);

        levelSelectButtonsManager.LockButtons(maxLevelReached);

        if (maxLevelReached > 10)
            logoAnimationController.ShowThanks = true;

    }

    public void NewLevelUnlocked(int level)
    {
        Debug.Log("NewLevelUnlocked: " + level);
        if (maxLevelReached > level)
            return;

        maxLevelReached = level;
        PlayerPrefs.SetInt("maxLevel", level);
        levelSelectButtonsManager.UnlockButton(level - 1);

        if (level > 10)
            thanks.SetActive(true);

    }
}
