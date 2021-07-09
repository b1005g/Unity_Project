using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    public SerialPort serial = new SerialPort("COM3");
    void Start()
    {
        serial.Open(); 
        serial.DtrEnable = true; //Configuramos control de datos por DTR. // We configure data control by DTR. 
        serial.ReadTimeout = 500;
    }
    void Update()
    {
        print(serial.ReadLine());
    }
}
