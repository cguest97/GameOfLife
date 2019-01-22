using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellInfo : MonoBehaviour {

    /* Determine current state and next state */
    private bool alive;
    private bool aliveOnNextTick;

    /* Determine game location */
    private Vector2 location;

    /* Gameobject to instantiate */
    public GameObject cellPrefab;
    public GameObject cellObject;

    private List<CellInfo> neighbours;

    /* Setup the cell in an initial state */
    public void setup(GameObject g) {
        cellPrefab = g;
        generateObject();

        changeAliveState(false);
        aliveOnNextTick = false;
        neighbours = new List<CellInfo>();
    }

    /* Add the cells neighbours to a list */
    public void setNeighbours(List<CellInfo> l) {
        neighbours = l;
    }

    public void generateObject() {
        cellObject = (GameObject)Instantiate(cellPrefab, location, Quaternion.identity);
        cellObject.GetComponent<CellScript>().setup(this);
    }

    /* Count how many neighbours are alive to see if this cell is alive next tick */
    public bool checkNextState() {
        int count = 0;

        for (int i = 0; i < neighbours.Count; i++) {
            if (neighbours[i].getAlive())
                count++;
        }

        if (count < 2 && alive) return false;
        if ((count == 2 || count == 3) && alive) return true;
        if (count > 3 && alive) return false;
        if (count == 3 && !alive) return true;

        return false;
    }

    public void isAliveOnNextTick() {
        aliveOnNextTick = checkNextState();
    }

    /* When changing if the cell is alive we also need to change its colour */
    public void changeAliveState(bool b) {
        setAlive(b);
        if (b)
        {
            cellObject.GetComponent<Renderer>().material.color = new Color(255, 0, 0);
        }
        else
        {
            cellObject.GetComponent<Renderer>().material.color = new Color(0, 0, 255);
        }
    }

    /* Destroy the cell */
    public void destroyCell() {
        Destroy(cellObject);
        Destroy(this);
    }


    /* Getters and Setters */
    public bool getAlive() { return alive; }
    public bool getAliveOnNextTick() { return aliveOnNextTick; }
    public Vector2 getLocation() { return location; }

    public void setAlive(bool b) { alive = b; }
    public void setAliveOnNextTick(bool b) { aliveOnNextTick = b; }
    public void setLocation(Vector2 l) { location = l; }

}
