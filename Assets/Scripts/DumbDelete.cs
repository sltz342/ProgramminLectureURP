using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumbDelete : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Console.Write("hanten");
        Console.WriteLine("cursed");

        string nameInput;
        string ageInputString;
        int ageInteger;
        Console.WriteLine("Enter your name");
        nameInput = Console.ReadLine();
        Console.WriteLine("Enter your age");
        ageInputString = Console.ReadLine();
        Int32.TryParse(ageInputString, out ageInteger);
        Console.WriteLine("Hi " + nameInput + ", you are " +  ageInteger + " years old.");
        Console.WriteLine("Enter to quit");
        Console.ReadLine();
    }
}
