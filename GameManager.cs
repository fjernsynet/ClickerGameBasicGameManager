using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //declaring
    public Text ClicksTotalText;
    public Text AutoClicksSecondText;
    public Text UpgradeCost;
    public Text UpgradeLevelText;
    public Text PercentClick;
    public Text UpgradeLevelTextBonusUpgrade;
    public Text clickBonusUpgradeCost;
    public Text ClickPerClickUpgradeLevel;
    public Text ClickPerClickUpgradeCost;

    float TotalClicks;
    double superClickChance = 0.9;
 
    public int autoClicksPerSecond;
    public int minimumClicksToUnlockAutoClick;
    public int minimumClicksToUnlockClickBonus;
    public int minimumClicksToUnlockClickPerClick;
    public int UpgradeLevel = 0;
    public int UpgradeLevelClickBonus = 0;
    public int ClickPerClickCurrentBonus = 0;

//upgrade 
    public void AutoClickUpgrade()
    {
        if (TotalClicks >= minimumClicksToUnlockAutoClick)
        {
            TotalClicks -= minimumClicksToUnlockAutoClick;
            minimumClicksToUnlockAutoClick = minimumClicksToUnlockAutoClick * 2;
            autoClicksPerSecond++;
            UpgradeLevel++;
        }
    }
 // increase chance of 10x click
    public void ClickBonusUpgrade()
    {
        if (TotalClicks >= minimumClicksToUnlockClickBonus)
        {
            TotalClicks -= minimumClicksToUnlockClickBonus;
            minimumClicksToUnlockClickBonus = minimumClicksToUnlockClickBonus * 4;
            superClickChance -= 0.05;
            UpgradeLevelClickBonus++;
        }
    }
    public void ClickPerClickUpgrade()
    {
        if (TotalClicks >= minimumClicksToUnlockClickPerClick)
        {
            TotalClicks -= minimumClicksToUnlockClickPerClick;
            minimumClicksToUnlockClickPerClick = minimumClicksToUnlockClickPerClick * 3;
            
            ClickPerClickCurrentBonus++;
        }
    }

// add clicks when clicking button
    public void AddClicks()
    {
        if (Random.value > superClickChance) //check if random value is over the 90th percentile, adding a 10% chance
        {
            TotalClicks += (10 + 10*ClickPerClickCurrentBonus);
        } else 
        {
            TotalClicks += (1 + 1*ClickPerClickCurrentBonus);
        }
        ClicksTotalText.text = TotalClicks.ToString("0");
    }
    

    private void Update()
    {
        TotalClicks += autoClicksPerSecond * Time.deltaTime;

        //update the score
        PercentClick.text = ((1 - superClickChance) * 100).ToString("0");
        UpgradeCost.text = minimumClicksToUnlockAutoClick.ToString("0");
        UpgradeLevelText.text = UpgradeLevel.ToString("0");
        ClicksTotalText.text = TotalClicks.ToString("0");
        AutoClicksSecondText.text = autoClicksPerSecond.ToString("0");
        UpgradeLevelTextBonusUpgrade.text = UpgradeLevelClickBonus.ToString("0");
        clickBonusUpgradeCost.text = minimumClicksToUnlockClickBonus.ToString("0");
        ClickPerClickUpgradeCost.text = minimumClicksToUnlockClickPerClick.ToString("0");
        ClickPerClickUpgradeLevel.text = ClickPerClickCurrentBonus.ToString("0");

    }
}
