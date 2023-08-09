using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
/*
This program runs a game called Mad Libs which takes user inputs and inserts them into a short story or poem.
Author: William Pearson
*/

// Variables:
string title = "Story Maker";
IDictionary<string, string> words = new Dictionary<string, string>()
            {
              {"Title", ""},
              {"Name",""},
              {"First Adjective"," "},
              {"Second Adjective",""},
              {"Third Adjective",""},
              {"Verb",""},
              {"First Noun",""},
              {"Second Noun",""},
              {"Animal",""},
              {"Food",""},
              {"Fruit",""},
              {"Superhero",""},
              {"Country",""},
              {"Dessert",""},
              {"Year",""}
            };

// The template for the story:
Func<IDictionary<string, string>, string> storyTemplate = words => $"This morning {words["Name"]} woke up feeling {words["First Adjective"]}. 'It is going to be a {words["Second Adjective"]} day!' Outside, a bunch of {words["Animal"]}s were protesting to keep {words["Food"]} in stores. They began to {words["Verb"]} to the rhythm of the {words["First Noun"]}, which made all the {words["Fruit"]}s very {words["Third Adjective"]}. Concerned, {words["Name"]} texted {words["Superhero"]}, who flew {words["Name"]} to {words["Country"]} and dropped {words["Name"]} in a puddle of frozen {words["Dessert"]}. {words["Name"]} woke up in the year {words["Year"]}, in a world where {words["Second Noun"]}s ruled the world.";


// Program Flow:
Console.WriteLine("Welcome to Mad Libs:");
Console.WriteLine(title);

Console.WriteLine("Please enter the following to create an story:");
bool valid = false;
foreach (var word in words.ToList())
{
    Console.WriteLine($"{word.Key}:");
    valid = false;
    while (!valid)
    {
        string? userInput = Console.ReadLine();
        if (ValidateUserInput(userInput))
        {
            words[word.Key] = userInput;
            valid = true;
        }
    }
}

Console.WriteLine("\nStory Generated, Mad Libs Presents...\n");
Console.WriteLine(words["Title"]);

Console.WriteLine(storyTemplate(words));

bool ValidateUserInput(string? input)
{
    string pattern = @"^([a-zA-Z0-9\D]{2,15})(?<!\s{3,})(?<!\\+)";
    if (!string.IsNullOrWhiteSpace(input) && Regex.IsMatch(input, pattern)) return true;
    else
    {
        Console.WriteLine("Please enter a Word!");
        return false;
    }
}
