using UnityEngine;

public class va_chạm : MonoBehaviour
{
    public di_chuyển vận_tốc;

    public AudioSource bonk;

    void OnCollisionEnter(Collision va)
    {
        if (va.collider.tag == "vật cản")
        {
            bonk.Play();
            vận_tốc.enabled = false;
            Quản_lý.instance.đã_thua();
        }
    }
}
