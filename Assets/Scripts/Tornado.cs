using UnityEngine;

public class Tornado : MonoBehaviour
{
    void Update()
    {
        transform.RotateAround(transform.position, Vector3.up, GlobalData.RotateSpeed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision other)
    {
        GlobalData.TotalCubeDestroyed++;
        Destroy(other.gameObject);
        Debug.Log(GlobalData.TotalCubeDestroyed);
    }
}
