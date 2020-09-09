using UnityEngine;
using System.Collections;
using UnityEngine.Video;
using UnityEngine.UI;
using System.IO;

public class CameraController : MonoBehaviour
{
    /// <summary>
    /// 外部摄像头
    /// </summary>
    private WebCamTexture webTex;
    /// <summary>
    /// UI父物体
    /// </summary>
    private Canvas canvas;
    /// <summary>
    /// 摄像头映射画面
    /// </summary>
    private RawImage Camera_image;




    private void Start()
    {
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        Camera_image = canvas.transform.Find("Camera_screen").GetComponent<RawImage>();

        StartCoroutine(CallCamera());
    }


    /// <summary>
    /// 打开摄像头
    /// </summary>
    /// <returns></returns>
    IEnumerator CallCamera()
    {
        //等待用户允许访问
        yield return Application.RequestUserAuthorization(UserAuthorization.WebCam);
        //如果用户允许访问，开始获取图像        
        if (Application.HasUserAuthorization(UserAuthorization.WebCam))
        {
            WebCamDevice[] devices = WebCamTexture.devices;
            string devicename = devices[0].name;
            webTex = new WebCamTexture(devicename, Screen.width, Screen.height);
            Camera_image.texture = webTex;
            webTex.Play();
        }
    }
}