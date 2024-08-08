using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Quản_lý : MonoBehaviour
{
    public static Quản_lý instance;
    public static bool kết_thúc;
    public GameObject Chiến_thắng;

    public GameObject achievementPrefab;
    public TextMeshProUGUI achievementText;
    void Awake()
    {
        Time.timeScale = 1;
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public IEnumerator AchievementUnlocked(string achievement)
    {
        if (PlayerPrefs.GetInt(achievement, 0) == 0)
        {
            Debug.Log("Achievement unlocked: " + achievement);
            PlayerPrefs.SetInt(achievement, 1);
            PlayerPrefs.Save();
            achievementText.text = achievement;
            achievementPrefab.SetActive(true);
            yield return new WaitForSeconds(3);
            if (achievementPrefab != null)
            {
                achievementPrefab.SetActive(false);
            }
        }
    }
    public IEnumerator chiến_thắng()
    {
       StartCoroutine(AchievementUnlocked("Beat the game"));
        yield return new WaitForSeconds(0.25f);
        Chiến_thắng.SetActive(true);
       Nhạc_nền.instance.YATTA();
       kết_thúc=true;
       Time.timeScale = 0;
    }
    bool thua=false;
    public void đã_thua()
    {
        if(thua == false) 
        {
            thua = true;
            StartCoroutine(chơi_lại());
        } 
    }
    public IEnumerator chơi_lại()
    {
        chờ.instance.đếm_ngược();
        yield return new WaitForSeconds(3);
        thua = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
