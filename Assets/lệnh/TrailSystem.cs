using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TrailSystem : MonoBehaviour
{
    private Dictionary<string, bool> trail = new Dictionary<string, bool>();

    public List<TextMeshProUGUI> TrailTexts;

    private void Awake()
    {
        InitializeTrail();
        OpenTrail();
        LoadTrail();
        UnlockTrail("Default Trail");
        UpdateTrailTexts();
    }

    public void OpenTrail()
    {
        int achievementUnlocked = AchievementSystem.instance.GetAchievementCount();
        if (achievementUnlocked >= 2)
        {
            UnlockTrail("Lighting Trail");
        }
        if (achievementUnlocked >= 4)
        {
            UnlockTrail("Rainbow Trail");
        }
    }

    private void InitializeTrail()
    {
        trail.Add("Default Trail", true);
        trail.Add("Lighting Trail", false);
        trail.Add("Rainbow Trail", false);
    }

    public void UnlockTrail(string trailName)
    {
        trail[trailName] = true;
        SaveTrail();
    }

    private void SaveTrail()
    {
        foreach (var trail in trail)
        {
            PlayerPrefs.SetInt(trail.Key, trail.Value ? 1 : 0);
        }
        PlayerPrefs.Save();
    }

    private void LoadTrail()
    {
        var modifiedTrail = new Dictionary<string, bool>();

        foreach (var trail in trail)
        {
            int unlockStatus = PlayerPrefs.GetInt(trail.Key, 0);
            modifiedTrail[trail.Key] = unlockStatus == 1;
        }

        trail = modifiedTrail;
    }

    

    public void EquipTrail(int trailIndex)
    {
        bool Unlocked = trail.ContainsKey(TrailTexts[trailIndex].name) && trail[TrailTexts[trailIndex].name];
        if (Unlocked)
        {
            PlayerPrefs.SetInt("Equipped Trail", trailIndex);
            PlayerPrefs.Save();
            UpdateTrailTexts();
        }
    }

    //Update trail texts base on Equipped Trail
    public void UpdateTrailTexts()
    {
        for (int i = 0; i < TrailTexts.Count; i++)
        {
            string trails = TrailTexts[i].name;
            bool Unlocked = trail.ContainsKey(trails) && trail[trails];

            if (Unlocked)
            {
                TrailTexts[i].text = "Unlocked";
                if (PlayerPrefs.GetInt("Equipped Trail", 0) == i)
                {
                    TrailTexts[i].text = "Equipped";
                    Debug.Log("Equipped Trail: " + trails);
                }
            }
        }
    }

}
