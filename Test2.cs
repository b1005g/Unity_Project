using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO.Ports;
using System;

public class Test2 : MonoBehaviour
{
    SerialPort sp = new SerialPort("COM4", 9600);

    public Text EMG;


    // Start is called before the first frame update
    void Start()
    {
        sp.Open();
        sp.ReadTimeout = 50;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (sp.IsOpen)
        {

            try
            {
                Debug.Log("Hello world");
                string EMG = sp.ReadLine();
                Console.WriteLine(EMG.Substring(1));
                // string[] x = EMG.Split('?');
                // Console.WriteLine(x);
                // Debug.Log(x);
                // float EMG_NUMBER = float.Parse(x[1]);

            }

            catch (System.Exception)
            {

            }

        }
    }

    private void OnApplicationQuit()
    {
        sp.Close();
    }

}