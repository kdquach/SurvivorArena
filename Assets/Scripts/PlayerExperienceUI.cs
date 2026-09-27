
using UnityEngine;
using TMPro;

public class PlayerExperienceUI : MonoBehaviour
{
    public PlayerExperience playerExperience;
    public TMP_Text xpText;

    void Update()
    {
        if (playerExperience == null || xpText == null)
            return;

        xpText.text =
            "Level: " + playerExperience.level +
            "\nXP: " + playerExperience.currentXP +
            " / " + playerExperience.xpToNextLevel;
    }
}