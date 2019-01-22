using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CellScript : MonoBehaviour {

    CellInfo info;

    public void setup(CellInfo i) {
        info = i;
    }

    private void OnMouseDown() {
        /* Make sure mouse isn't over GUI element to prevent clickthrough on GUI */
        if (!EventSystem.current.IsPointerOverGameObject()) {
            info.changeAliveState(!info.getAlive());
        }
    }
}
