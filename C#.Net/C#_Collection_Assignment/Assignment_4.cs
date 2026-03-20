using System;
using System.Collections.Generic;
using System.Text;

namespace C__Collection_Assignment
{
    using System;
    using System.Collections.Generic;

    internal class Assignment_4
    {
        static void Main()
        {
            // Stack for Undo
            Stack<string> undoStack = new Stack<string>();

            // Stack for Redo (Bonus)
            Stack<string> redoStack = new Stack<string>();

            // Push actions
            undoStack.Push("Type A");
            undoStack.Push("Type B");
            undoStack.Push("Delete C");
            undoStack.Push("Type D");
            undoStack.Push("Delete E");

            Console.WriteLine("All Actions in Undo Stack:");
            DisplayStack(undoStack);

            // Undo last 3 actions
            Console.WriteLine("\nUndo Last 3 Actions:");
            for (int i = 0; i < 3; i++)
            {
                if (undoStack.Count > 0)
                {
                    string action = undoStack.Pop();
                    redoStack.Push(action); // move to redo stack
                    Console.WriteLine($"Undone: {action}");
                }
            }

            //Peek current action
            if (undoStack.Count > 0)
            {
                Console.WriteLine($"\nCurrent Top Action: {undoStack.Peek()}");
            }
            else
            {
                Console.WriteLine("\nNo actions left.");
            }

            // Redo last undone action (Bonus)
            Console.WriteLine("\nRedo Last Action:");
            if (redoStack.Count > 0)
            {
                string redoAction = redoStack.Pop();
                undoStack.Push(redoAction);
                Console.WriteLine($"Redone: {redoAction}");
            }
            else
            {
                Console.WriteLine("No actions to redo.");
            }

            // Final Undo Stack
            Console.WriteLine("\nFinal Undo Stack:");
            DisplayStack(undoStack);
        }

        //Helper method to display stack
        static void DisplayStack(Stack<string> stack)
        {
            foreach (var action in stack)
            {
                Console.WriteLine(action);
            }
        }
    }
}
