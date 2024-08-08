using UnityEngine;

public class đích : MonoBehaviour
{
    public Quản_lý quản_lý;
    void OnTriggerEnter()
    {
        StartCoroutine(Quản_lý.instance.chiến_thắng());
    }
}
