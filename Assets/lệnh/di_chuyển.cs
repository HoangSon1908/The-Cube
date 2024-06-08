using System.Collections;
using UnityEngine;

public class di_chuyển : MonoBehaviour {

    public static di_chuyển instance;
    public Rigidbody rb;
    public float tiến = 500f;
    public float né = 300f;

    private void Awake()
    {
        instance = this;
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
            Quản_lý.instance.đã_thua();
        }
    }
}
