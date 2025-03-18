# Elden Ring Save Manager
**Elden Ring Save Manager** is a Windows application designed to help players manage their save files for the popular game Elden Ring. The application allows users to easily back up, load, and delete save files, as well as using memory so saves that be triggered without needing to go through the main menu. This functionality is especially useful for speedrunners or players looking to practice specific game scenarios without the need for lengthy menu navigation.

## Features
### Save File Management:

 - Create, load, and delete saved games with ease.
 - Organize and track save files in a list with an auto-updating interface.
   
### Quit-Out Save:

 - Automatically trigger a special "Quit-Out" save using a memory function, which can load the game progress immediately without requiring you to return to the main menu.
 - Ideal for speedrunners and players who want to practice specific in-game scenarios efficiently.

### Direct Memory Interaction:

 - The application interacts directly with Elden Ring's memory, enabling seamless save management and manipulation without manual intervention.
   
 ### Automatic State Monitoring:

 - Monitors the game state, including detecting when the player dies, enters a menu, or restarts, to handle save loading automatically based on specific events.
   
### User-Friendly Interface:

 - Simple and intuitive forms for creating, selecting, and deleting saves.
 - Easy-to-use buttons and confirmation dialogs to ensure a smooth user experience.
   
## How It Works
### Save File Management
The core of the application revolves around saving, loading, and deleting save files. Save files are stored locally, and each save contains a name, an ID, and a timestamp for easy identification. The app uses a JSON-based system for tracking save data and is automatically updated when a save is added or removed.

### Quit-Out Save
The unique feature of this project is the Quit-Out Save. This feature allows the player to interact with the game's memory to load a save directly from within the game, without having to go back to the main menu. This is accomplished by continuously monitoring the game's state and utilizing memory reading/writing techniques to trigger the save when certain conditions (like the player's death or quitting) are met.

For speedrunners and players wanting to practice specific parts of the game, this eliminates the need for time-consuming navigation through the menus, offering an efficient and smooth experience.

## Prerequisites:

1. Make sure you have .NET Framework installed on your machine.
2. The application is designed to run on Windows OS, and it requires Elden Ring to be running in the background.
3. The anti cheat needs to be disabled
4. Configuration:
- The application will automatically create necessary folders and files on the first run.
- Save location paths and data paths are set by default to the current user's Documents folder.

## Background Workers
The application uses BackgroundWorkers to monitor certain game states while the user is interacting with the app:

- Dead Worker: Monitors the player’s death status and triggers a quit-out save when the player dies.
- Menu Worker: Monitors if the player is in the menu. If the player is in the menu, it will trigger a quit-out save and load it.
- Restart Worker: Monitors the game state after a restart. It will automatically start the Dead Worker again if the player is no longer dead and the menu state is inactive.

## Technologies Used
- C#: The primary programming language used for developing the application.
- .NET Framework: Used for building the Windows Forms application and handling user interface components.
- Newtonsoft.Json: Used for serializing and deserializing save data in JSON format.
- Memory Access Libraries: Memory.Utils and Memory.Win64 are used for interacting with Elden Ring’s memory in real-time.
- Windows Forms: The application uses Windows Forms to create the user interface and manage interactions.
