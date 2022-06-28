/* 
*   Assignment 1
*   Names: Marc Touma, Ben Collins
*   Student numbers : 0674328, 0672261
*   Date 10/17/2021
*/
using System;
using LinkedListBrowsing;
using Browsing;

    Console.WriteLine("Would you like to start the browser, Y or N?"); // Ask if user would like to open browser
    Char answer= char.Parse(Console.ReadLine()); // Take input and convert to char
    if (answer=='Y') // Decide correct action
    {
        System.Console.WriteLine("Input X to close the browser. To navigate the browser use S to start a tab. M to move to a tab. C to close a tab. V to visit a Webpge. B to move back to the previous webpage. F Move forward a Webpage");
        Browsing.Browser x =new Browsing.Browser(); // Create instance of Stack Implementation Browser class
        LinkedListBrowsing.Browser X= new LinkedListBrowsing.Browser(); // Instance in Doubly Linked List Implementation
        
        char input= 'T'; // Set a default input
        while (input != 'X') // Make a loop to be able to make multiple commands
        {
            input= char.Parse(Console.ReadLine()); // Take a command input
        if (input=='S') // Decide correct method to call based on input
        {
            X.Start(); // Start a tab for both implementations
            x.Start(); 
            System.Console.WriteLine(X.CurrentWebPage()); // Print Webpage
                       
        }
        else if (input=='M')
        {
            System.Console.WriteLine("Input the tab number you would like to visit"); // Switch tabs
            int m = int.Parse(Console.ReadLine()); // Take a number input to switch tabs and parse to int
            
            X.Move(m); // Call move tab method
            x.Move(m);
        }
        else if (input=='C')
        {
            System.Console.WriteLine("Input the tab number you would like to close"); // Close a Webpage
            int c= int.Parse(Console.ReadLine()); // Take input and parse to int
            X.Close(c); // Call close tab method at position c
            x.Close(c); 

        }
        else if (input=='V')
        {
            System.Console.WriteLine("Input the webpage you would like to visit"); // Visit a Webpage
            String w= Console.ReadLine(); // Take input
            x.MoveWeb(w); // Call visit method
            X.MoveWeb(w);
        }
        else if (input=='B') // Go back
        {
            X.Back(); // Call back method
            x.Back();
        }
        else if (input=='F') // Go forward
        {
            X.Forward(); // Call forward method
            x.Forward();
        }
        else 
        {
            System.Console.WriteLine("Please input S M C V F or B"); // Give an error
        }
        x.PrintBrowser(); // Print whole Browser
        X.PrintBrowser();
    }
    }
    else if (answer=='N') // If they do not wish to start browser close
    {  
        System.Console.WriteLine("Goodbye");
    }
    else
    {
        System.Console.WriteLine("Error, Please input y or n"); // Error for incorrect input
    }