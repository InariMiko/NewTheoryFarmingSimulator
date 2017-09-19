using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class takescreenshot : MonoBehaviour {
    string Screen_Shot_File_Name;
    void Update()
    {


        if (Input.GetKey("p"))
        {
            Screen_Shot_File_Name = "Screenshot-" + System.DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".png";
            ScreenCapture.CaptureScreenshot(Screen_Shot_File_Name,4);
            print("Take Screen Shot Successfully");
        }
    }
}