using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    public TextMeshProUGUI HIGHSCORE;
    private int PlayerScore;

    public GameObject AchievementObject;
    public GameObject TrailObject;
    void Start()
    {
        // Kiểm tra xem có giá trị điểm_cao đã được lưu trữ trước đó không
        if (PlayerPrefs.HasKey("Điểm cao"))
        {
            // Nếu có, tải giá trị lưu trữ vào biến điểm_cao
            PlayerScore = PlayerPrefs.GetInt("Điểm cao");
            HIGHSCORE.text = PlayerScore.ToString();
        }
        else
        {
            // Nếu không, giá trị high score ban đầu được đặt là 0
            PlayerScore = 0;
            HIGHSCORE.text = "0";
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Achievement()
    {
        AchievementObject.SetActive(true);
        AchievementObject.GetComponent<Animator>().Play("OpenUI");
    }

    public void CloseAchivement()
    {
        AchievementObject.GetComponent<Animator>().Play("CloseUI");
        Invoke("deactiveAchievementObject", 0.25f);
    }

    private void deactiveAchievementObject()
    {
        AchievementObject.GetComponent<CanvasGroup>().alpha = 0;
        AchievementObject.SetActive(false);
    }

    public void Trail()
    {
        TrailObject.SetActive(true);
        TrailObject.GetComponent<Animator>().Play("OpenUI");
    }

    public void CloseTrail()
    {
        TrailObject.GetComponent<Animator>().Play("CloseUI");
        Invoke("deActiveTrailObject", 0.25f);

    }

    private void deActiveTrailObject()
    {
        TrailObject.GetComponent<CanvasGroup>().alpha = 0;
        TrailObject.SetActive(false);
    }

}
