using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityOSC;

public class SonicListener : Controllable
{


    protected override void OnReceive(OSCPacket packet) {

        foreach (var item in packet.Data) {
            print(item.ToString());
            print(packet.Address);
        }

    
    }
}
