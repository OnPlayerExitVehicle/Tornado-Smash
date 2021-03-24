using UnityEngine;


#if UNITY_EDITOR
public class Controller : MonoBehaviour
{

    [SerializeField] private float sensitivity = 10f;

    void Update()
    {

        if (Input.GetMouseButton(0) && GlobalData.Controllable)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x - (Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime), -GlobalData.TableXBorder, GlobalData.TableXBorder), transform.position.y,
                Mathf.Clamp(transform.position.z + (Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime), -GlobalData.TableZBorder, GlobalData.TableZBorder));
        }
    }
}

#elif UNITY_ANDROID
public class Controller : MonoBehaviour
{
    private float mobileSensitivity = 50;
    private Touch touch;

    void Update(){

        if (Input.touchCount > 0 && GlobalData.Controllable)
        {
            touch = Input.GetTouch(0);
            transform.position = new Vector3(Mathf.Clamp(transform.position.x + (-touch.deltaPosition.y * (mobileSensitivity / 100) * Time.deltaTime), -GlobalData.TableXBorder, GlobalData.TableXBorder), transform.position.y, Mathf.Clamp(transform.position.z + (touch.deltaPosition.x * (mobileSensitivity / 100) * Time.deltaTime), -GlobalData.TableZBorder, GlobalData.TableZBorder));
        }
    }
}
#endif