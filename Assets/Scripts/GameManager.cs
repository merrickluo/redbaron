using UnityEngine;

public class GameManager : MonoBehaviour {

    private Camera cam;
    private float camSpeed = 2f;

    // Use this for initialization
    void Start () {
        cam = GetComponent<Camera>();

        // Screen.SetResolution(600, 800, FullScreenMode.Windowed);
    }

    // Update is called once per frame
    void Update () {
        // Vector3 curPos = cam.transform.position;
        // cam.transform.position =
        //     new Vector3(curPos.x, curPos.y + camSpeed * Time.deltaTime, curPos.z);
    }
}
