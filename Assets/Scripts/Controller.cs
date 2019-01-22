using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Controller : MonoBehaviour {

    /* Size of the board */
    public int sizeX;
    public int sizeY;

    public GameObject cellPrefab;

    private CellInfo[,] board;

    public Slider timeSlider;

    /* Control how often game updates */
    private int timer;

    private void Start() {
        setup();
    }

    public void setup() {
        /* Initial generation of the board where all cells are dead */
        board = new CellInfo[sizeX, sizeY];
        timer = 0;

        for (int i = 0; i < sizeX; i++) {
            for (int j = 0; j < sizeY; j++) {
                board[i, j] = new CellInfo();
                board[i, j].setLocation(new Vector2(i, j));
                board[i, j].setup(cellPrefab);
            }
        }

        for (int i = 0; i < sizeX; i++) {
            for (int j = 0; j < sizeY; j++) {
                board[i, j].setNeighbours(genNeighbourList(i, j));
            }
        }
    }

    /* Every time we want to advance the game a step use this function */
    public void tick() {
        for (int i = 0; i < sizeX; i++) {
            for (int j = 0; j < sizeY; j++) {
                board[i, j].isAliveOnNextTick();
            }
        }

        for (int i = 0; i < sizeX; i++) {
            for (int j = 0; j < sizeY; j++) {
                board[i, j].changeAliveState(board[i, j].getAliveOnNextTick());
            }
        }
    }


    /* Add neighbours for each of the cells */
    private List<CellInfo> genNeighbourList(int x, int y) {
        List<CellInfo> neighbours = new List<CellInfo>();
        if (x > 0) {
            neighbours.Add(board[x - 1, y]);
            if (y > 0) {
                neighbours.Add(board[x - 1, y - 1]);
            }
            if (y < sizeY - 1) {
                neighbours.Add(board[x - 1, y + 1]);
            }
        }

        if (x < sizeX - 1) {
            neighbours.Add(board[x + 1, y]);
            if (y > 0) {
                neighbours.Add(board[x + 1, y - 1]);
            }
            if (y < sizeY - 1) {
                neighbours.Add(board[x + 1, y + 1]);
            }
        }

        if (y > 0) {
            neighbours.Add(board[x, y - 1]);
        }

        if (y < sizeY - 1) {
            neighbours.Add(board[x, y + 1]);
        }
        return neighbours;
    }

    private void FixedUpdate() {
        if (timer >= timeSlider.value) {
            /* Update the game state */
            tick();
            timer = 0;
        }
        else {
            timer++;
        }
    }

    /* Destroy board and build a new one with different dimensions */
    public void regenerateBoard(int newXSize, int newYSize) {
        destroyBoard();
        sizeX = newXSize;
        sizeY = newYSize;
        timer = 0;
        setup();
    }

    /* Destroy the current Board */
    public void destroyBoard() {
        for (int i = 0; i < sizeX; i++) {
            for (int j = 0; j < sizeY; j++) {
                board[i, j].destroyCell();
            }
        }
    }

}
