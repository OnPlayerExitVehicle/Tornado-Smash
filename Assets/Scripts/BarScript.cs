using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BarScript : MonoBehaviour
{
    private Collider[] colliders;

    private List<Collider> pastColliders;

    void FixedUpdate()
    {
        colliders = Physics.OverlapSphere(transform.position, GlobalData.EffectRadius, LayerMask.GetMask("Ignore Raycast"));
        if (pastColliders == null) SavePastColliders(); // For the first time
        
        foreach (var collider in colliders)
        {
            Rigidbody rb;
            if (pastColliders == null) SavePastColliders();
            else if (!pastColliders.Contains(collider)) // Newly added
            {
                if (collider.gameObject.TryGetComponent<Rigidbody>(out rb))
                {
                    rb.useGravity = false;
                }
            }

            var position = transform.position + Vector3.Normalize(new Vector3(collider.transform.position.x - (transform.position.x + 1f), 0, collider.transform.position.z - (transform.position.z + 1f))) * .1f;
            collider.transform.position = Vector3.Lerp(collider.transform.position, new Vector3(position.x, collider.transform.position.y, position.z), GlobalData.HorizontalPullSpeed);
            collider.transform.position = Vector3.Lerp(collider.transform.position, new Vector3(collider.transform.position.x, GlobalData.TornadoHeight, collider.transform.position.z), GlobalData.VerticalPullSpeed);

            collider.transform.localScale = Vector3.Lerp(collider.transform.localScale, Vector3.one * GlobalData.MinimumScale, GlobalData.ScaleDecreaseSpeed);
            
            collider.transform.RotateAround(transform.position, Vector3.up, GlobalData.RotateSpeed * Time.fixedDeltaTime);
        }

        foreach (Collider pastCollider in pastColliders)
        {
            Rigidbody rb;
            if (!colliders.Contains(pastCollider) && pastCollider != null)
            {
                if (pastCollider.gameObject.TryGetComponent<Rigidbody>(out rb))
                {
                    rb.useGravity = true;
                }
            }
        }

        SavePastColliders();
    }

    private void SavePastColliders()
    {
        pastColliders = colliders.ToList();
    }

    void OnCollisionEnter(Collision other)
    {
        //Destroy(other.gameObject);
    }
}
