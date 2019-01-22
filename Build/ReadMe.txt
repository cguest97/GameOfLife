A Simulation of Conway's game of life....

A cell exists in a binary state - either alive or dead, when the game state updates a cell evaluates if it is alive using the following factors:
    Any live cell with fewer than two live neighbors dies, as if by underpopulation.
    Any live cell with two or three live neighbors lives on to the next generation.
    Any live cell with more than three live neighbors dies, as if by overpopulation.
    Any dead cell with exactly three live neighbors becomes a live cell, as if by reproduction.

Controls:

W, A, S, D or Arrow Keys - Pan the camera.
Scroll Wheel - Zoom in or out of the board.
Generate Button - Build a new game board based on the size's which have been input.
Slider - Control the speed at which the game board updates state.