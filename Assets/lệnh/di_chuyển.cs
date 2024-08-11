using System.Collections;
using UnityEngine;

public class di_chuyển : MonoBehaviour {

    public GameObject[] trails;
    
    public static di_chuyển instance;
    public Rigidbody rb;
    public float tiến = 500f;
    public float né = 300f;

    private int fallCount;
    private bool isFall;

    private void Awake()
    {
        instance = this;
        isFall = false;
        if (PlayerPrefs.HasKey("Fall count"))
        {
            fallCount = PlayerPrefs.GetInt("Fall count");
        }
        else
        {
            fallCount = 0;
        }
    }
    void FixedUpdate()
    {
        rb.AddForce(0, 0, tiến * Time.deltaTime);      
        if (Input.GetKey("d"))
        {
            rb.AddForce(né * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(-né * Time.deltaTime, 0, 0, ForceMode.VelocityChange);//áp dụng lực lên người chơi mà không quan tâm khối lượng 
        }
        if (rb.position.y < -1f) 
        {
            if(isFall==false)
            {
                isFall = true;

                Quản_lý.instance.đã_thua();

                fallCount++;
                if (fallCount >= 5)
                {
                    StartCoroutine(Quản_lý.instance.AchievementUnlocked("Fall 5 times"));
                }
                PlayerPrefs.SetInt("Fall count", fallCount);
                PlayerPrefs.Save();
            }
        }
    }

    public void EquipTrail(int trailIndex)
    {
        foreach (GameObject trail in trails)
        {
            trail.SetActive(false);
        }
        trails[trailIndex].SetActive(true);
    }
}
