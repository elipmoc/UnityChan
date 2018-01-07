using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateFloorDetect :BaseDetectCube {
    [SerializeField]
    private List<GameObject> floorList;

    public override void On()
    {
        base.On();
        floorList.ForEach(x=>x.SetActive(true));
    }

    public override void Off()
    {
        base.Off();
        floorList.ForEach(x => x.SetActive(false));
    }

}
