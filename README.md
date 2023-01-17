CatLand [Version 1.0]

======= Controls =======

WASD - Movement;
E - interact / Pickup;
Q - Drop;

======= Scripts =======

- CatLand
 - Controllers
  ====================================================================================
  - BushController.cs
   - This script adds the ability for bush to be fruit-able.
  ====================================================================================
  - ComputerController.cs
   - This script represents a computer object which can be used to open the console.
  ====================================================================================
  - DoorController.cs
   - This script makes door able to be interactive for transitions between mountains and house scenes.
  ====================================================================================
  - GateController.cs
   - This script used to make gate able to switch between ON and OFF states.
  ====================================================================================
  - GateIndexesController.cs
   - This script controls gate indexes.
  ====================================================================================
  - LetterController.cs
   - This script added ability to create letters for the game.
   - It contains the header and main text.

 - Scriptable Objects
  - ItemData.cs
   - This script saves information about items.

 - Systems
  - Fundamental Systems
   - Interaction System
    ====================================================================================
    - Selectable.cs
     - Adds ability for object to be selectable.
    ====================================================================================
    - Interactable.cs
     - Implements Selectable.cs.
     - Contains all information to make an object which implements Interactable.cs to be interactable.
    ====================================================================================
    - InteractionSystem.cs
     - This script detects collision for interaction.

   - Inventory System
    ====================================================================================
    - Inventory System.cs
     - This script controls items in inventory.
    ====================================================================================
    - Item.cs
     - This script adds the ability to object to be picked-able.

   - AnimationEngine.cs
    - This script adds ability to control animations on an object which has attached AnimationEngine.cs.
   ====================================================================================
   - MovementEngine.cs
    - This script moves objects with acceleration and deceleration.

 - Console System
  - Commands
   - Command.cs
    - This script contains all information about the command.
   ====================================================================================
   - ProtectedCommand.cs
    - This script implements Command.cs and contains additional information about the binary expression generation.
  - Binary
   - BinaryExpression.cs
     - This script generates random binary expressions.
     ====================================================================================
     - Binary Mathematical Operations:
      - Addition
      - Subtraction
      - Multiplication
      - Division

  - ConsoleSystem.cs
   - This script controls console and console UI.

 - CatInput.cs
  - This script gets cat input.
 ====================================================================================
 - ComputerFixer.cs
  - This script adds the ability to computer to be fixed (Enables ComputerController.cs and destroys itself after fixing).
 ====================================================================================
 - FadeImageEvents.cs
  - This script calls events from animation.
 ====================================================================================
 - FPSCounter.cs
  - This script shows FPS.
 ====================================================================================
 - ToggleLighting.cs
  - This script adds the ability to be turned ON/OFF.
 ====================================================================================
 - TreeSelectable.cs
  - This script adds the ability for a tree to be selected.
