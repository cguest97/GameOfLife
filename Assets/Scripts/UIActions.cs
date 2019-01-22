using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIActions : MonoBehaviour {

    public Button genButton;
    public Text inputX;
    public Text inputY;

    public GameObject control;

    private void Start() {
        genButton.onClick.AddListener(genOnClick);
    }

    /* Given a valid input generate a new game board */
    void genOnClick() {
        int xSize = 0;
        int ySize = 0;

        bool xSuccess = int.TryParse(inputX.text, out xSize);
        bool ySuccess = int.TryParse(inputY.text, out ySize);

        if (xSuccess && ySuccess) {
            control.GetComponent<Controller>().regenerateBoard(xSize, ySize);
        }
    }
}
