using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO.Ports;

public class ArduinoMgr : MonoBehaviour
{
    // public Text accelx;
    public Text Test;
    public enum PortNumber
    {
        COM1, COM2, COM3, COM4,
        COM5, COM6, COM7, COM8,
        COM9, COM10, COM11, COM12,
        COM13, COM14, COM15, COM16
    }
    // 연결된 포트, baud rate(통신속도)
    private SerialPort serial;

    [SerializeField]
    private PortNumber portNumber = PortNumber.COM10;    // 포트 넘버
    [SerializeField]
    private string baudRate = "115200";                   // 통신속도



    void Start()
    {
        serial = new SerialPort(portNumber.ToString(), int.Parse(baudRate));
        serial.Open();
        serial.ReadTimeout = 50;
        Test = GameObject.Find("a").GetComponent<Text>();
    }

    private void Update()
    {
        if (!serial.IsOpen)
            serial.Open();

        if (serial.IsOpen)
        {
            try
            {
                string a = serial.ReadLine();
                Test.text = a;
            }

            catch
            {

            }
        }

    }

    // 포트 연결

}
       
       

