using UnityEngine;

public class va_chạm : MonoBehaviour
{
    public di_chuyển vận_tốc;

    public AudioSource bonk;

    private int bonkCount;

    private void Start()
    {
        if (PlayerPrefs.HasKey("Bonk count"))
        {
            bonkCount = PlayerPrefs.GetInt("Bonk count");
        }
        else
        {
            bonkCount = 0;
        }
    }

    void OnCollisionEnter(Collision va)
    {
        if (va.collider.tag == "vật cản")
        {
            bonk.Play();
            vận_tốc.enabled = false;
            Quản_lý.instance.đã_thua();

            bonkCount++;
            if (bonkCount >= 5)
            {
                StartCoroutine(Quản_lý.instance.AchievementUnlocked("Get 5 bonks"));
            }
            // Lưu giá trị high score vào bộ nhớ cục bộ
            PlayerPrefs.SetInt("Bonk count", bonkCount);
            PlayerPrefs.Save();
        }
    }
}
