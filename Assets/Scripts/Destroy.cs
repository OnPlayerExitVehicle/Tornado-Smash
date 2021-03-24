using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        GlobalData.TotalCubeDestroyed++;
        Destroy(other.gameObject);
        Debug.Log(GlobalData.TotalCubeDestroyed);
    }
}
