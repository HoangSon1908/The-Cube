using System.Collections;
using UnityEngine;

public class di_chuyển : MonoBehaviour
{
    public GameObject[] trails;

    public static di_chuyển instance;
    public float tiến = 500f;
    public float né = 300f;

    private int fallCount;
    private bool isFall;

    public Rigidbody rb;

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
            HandlePlayerMovement();

            if (rb.position.y < -1f)
            {
                HandlePlayerFall();
            }
    }

    void HandlePlayerMovement()
    {
        rb.AddForce(0, 0, tiến * Time.deltaTime);
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.position.x < Screen.width / 2)
            {
                MovePlayer(Vector3.left);
            }
            else
            {
                MovePlayer(Vector3.right);
            }
        }

        if (Input.GetKey("d"))
        {
            MovePlayer(Vector3.right);
        }
        if (Input.GetKey("a"))
        {
            MovePlayer(Vector3.left);
        }
    }

    void MovePlayer(Vector3 direction)
    {
        rb.AddForce(direction * né * Time.deltaTime, ForceMode.VelocityChange);
    }

    void HandlePlayerFall()
    {
        if (!isFall)
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

    public void EquipTrail(int trailIndex)
    {
        foreach (GameObject trail in trails)
        {
            trail.SetActive(false);
        }
        trails[trailIndex].SetActive(true);
    }
}