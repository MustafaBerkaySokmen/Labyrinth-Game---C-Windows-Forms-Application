# Labyrinth Game - C# Windows Forms Application

## Overview
The **Labyrinth Game** is a **C# Windows Forms-based maze game** where the player navigates through a **randomly generated labyrinth** to reach the **gold prize (`$`)**. This project utilizes **.NET Windows Forms** for a graphical user interface (GUI) rather than a console-based output.

## Features
- **Graphical Maze Environment** (Windows Forms-based UI).
- **Random Maze Generation** with walls (`#`) and open paths (` `).
- **Random Prize Placement** (`$`) at an open position.
- **Arrow Key Movement (`← ↑ → ↓`)** to navigate the maze.
- **Winning Condition:** Reach the prize and get a congratulatory message.

## Installation

### **1. Clone the Repository**
```bash
git clone https://github.com/yourusername/Labyrinth-Game.git
cd Labyrinth-Game
```

### **2. Open the Project in Visual Studio**
- Launch **Visual Studio**.
- Open `labyrinth_game.sln`.

### **3. Build & Run the Game**
- Click **Start (F5)** to compile and run the game.

## How to Play
1. **Player starts at (1,1) (`R`)**.
2. **Use Arrow Keys (`← ↑ → ↓`)** to navigate.
3. **Avoid walls (`#`)**.
4. **Reach the gold prize (`$`)** to win the game.

## Example Gameplay (Graphical Output)
```
###################################################
#R      #        #           #                   #
#  ######  #######  ######## #      ###########  #
#           #     #         #      #         #  #
#####  #########  ######### #      #####     #  #
#       #        #         #         #       #  #
# ############### ######### ####### ###########  #
#             $                                   #
###################################################
```
- The **player (`R`) moves through the maze**.
- The **goal (`$`) is at a random open space**.
- **Walls (`#`) block movement**.

## Future Enhancements
- **Dynamic Maze Scaling** (Adjustable grid size).
- **AI Opponent Mode** (A second player controlled by AI competing for the prize).
- **Multiplayer Mode** (Two players race to the goal).
- **Leaderboard System** (Fastest completion time tracking).

## License
This project is licensed under the **MIT License**.

## Contributions
Contributions are welcome! To contribute:
1. Fork the repository.
2. Create a new branch (`feature-new-feature`).
3. Commit and push your changes.
4. Open a pull request.

## Contact
For any questions or support, please open an issue on GitHub.

