using System;
using System.IO.Ports;
using UnityEngine;
using UnityEngine.UI;

public class ArduinoController : MonoBehaviour
{
    [Header("Messages")]
    [SerializeField] private String m_MessageReaded = "";
    [SerializeField] private String m_MessageSended = "";

    [Header("SerialPort values")]
    [SerializeField] private String m_COM = "COM3";
    [SerializeField] private int m_baudrate = 115200;
    [SerializeField] private int m_readTimeout = 10;
    [SerializeField] private int m_writeTimeout = 10;
    [SerializeField] private float m_delay = 0.05f;
    private SerialPort m_serialPort;
    private float m_lastSentTime;

    public SerialPort serial = new SerialPort("COM3");

        //Initialize and open SerialPort, set timers
        void Start()
    {
        m_serialPort = new SerialPort(m_COM, m_baudrate)
        {
            ReadTimeout = m_readTimeout,
            WriteTimeout = m_writeTimeout
        };

        OpenPort(m_serialPort);

        m_lastSentTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        ManageArduinoCommunication();
    }

    //Encapsulated try-catch to open the port
    void OpenPort(SerialPort port)
    {
        try
        {
            port.Open();
            print("Open Port " + port.PortName);

        }
        catch (Exception e)
        {
            print("Do not open Port " + port.PortName);
        }
    }

    public void ManageArduinoCommunication()
    {
        if (m_serialPort != null)
        {
            if (m_serialPort.IsOpen)
            {
                //WRITE TO ARDUINO
                WriteToArduino();

                //READ FROM ARDUINO
                ReadFromArduino();
            }
        }
        else
        {
            OpenPort(m_serialPort);
        }

    }

    private void WriteToArduino()
    {
        m_MessageSended = "";

        if (!Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                m_MessageSended = "openGate";
                m_serialPort.WriteLine(m_MessageSended);
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                m_MessageSended = "closeGate";
                m_serialPort.WriteLine(m_MessageSended);
            }
        }
    }

    private void ReadFromArduino()
    {
        if (Time.time - m_lastSentTime >= m_delay)
        {
            try
            {
                m_MessageReaded = m_serialPort.ReadLine();
            }
            catch (TimeoutException e)
            {
                // no-op, just to silence the timeouts.
                // (my arduino sends 12-16 byte packets every 0.1 secs)
            }
            m_lastSentTime = Time.time;
        }
    }

    private void OnApplicationQuit()
    {
        m_serialPort.Close();
    }
}
