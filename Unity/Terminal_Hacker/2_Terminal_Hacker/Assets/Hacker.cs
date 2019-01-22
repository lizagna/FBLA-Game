using UnityEngine;

public class Hacker : MonoBehaviour {

    // Game configuration data
    const string menuHint = "You many type menu at any time. ";
    string[] level1Passwords = { "stats", "psych", "aplang", "dcush", "ochem", "music" };
    string[] level2Passwords = { "blouse", "wig", "teacup", "tablet", "mug"};

    // Game state
    int level; // member variable
    enum Screen {MainMenu, Password, Win}
    Screen currentScreen;
    string password;


    // Use this for initialization
    void Start()
    {
        ShowMainMenu();
    }

    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Press 1 for Schoology");
        Terminal.WriteLine("Press 2 for my Amazon account");
        Terminal.WriteLine("Enter you selection: ");
    }

    // OnUserInput should only decides how to handle input, NOT do something
    void OnUserInput(string input)
    {
        if (input == "menu") // we can always go direct to main menu
        {
            ShowMainMenu();
        } 
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }

    // determines if password corresponds with correct level
    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2");
        if (isValidLevelNumber)
        {
            level = int.Parse(input); //turns input into an int
            AskForPassword(); //goes to StartGame function
        }
        else if (input == "007") //easter egg
        {
            Terminal.WriteLine("Please select a level Mr. Bond!");
        }
        else
        {
            Terminal.WriteLine("Enter a valid level");
            Terminal.WriteLine(menuHint);
        }
    }

    void AskForPassword()
    {
        currentScreen = Screen.Password; // you are now at the password screen
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Enter your password, hint: " + password.Anagram());

    }

    void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                break;
            case 2:
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }
    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            AskForPassword();
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
        Terminal.WriteLine(menuHint);
    }

    void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("aye go get that 9");
                break;
            case 2:
                Terminal.WriteLine("Have a mug...");
                break;
            default:
                Debug.LogError("ERROR ERROR TERMINAL.EXE HAS FAILED");
                break;
        }
    }
}
