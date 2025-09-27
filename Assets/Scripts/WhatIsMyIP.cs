using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Net;
using System.Net.Sockets;

public class WhatIsMyIP : MonoBehaviour
{
    public TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        string localIP = GetLocalIPAddress();
        text.text = $"This computer's IP : {localIP}";
    }

    private string GetLocalIPAddress()
    {
        try
        {
            foreach (var networkInterface in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
            {
                if (networkInterface.AddressFamily == AddressFamily.InterNetwork)
                {
                    return networkInterface.ToString();
                }
            }
            return "No IPv4 address found!";
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Error retrieving local IP: " + ex.Message);
            return "Error";
        }
    }
}
