using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRatio : MonoBehaviour
{
    public static float PixelToCameraRatio = 0f;
    public static float ySize = 0f;
    public static float xSize = 0f;

    // Start is called before the first frame update
    void Awake()
    {
        PixelToCameraRatio = Camera.main.orthographicSize / Screen.height;
        ySize = Camera.main.orthographicSize;
        xSize = ySize * Screen.width / Screen.height;
    }

}
