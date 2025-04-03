using System;
using System.Media;
using System.IO;

class CybersecurityBot
{
    // Automatic properties for personalization
    public string UserName { get; set; }
    public string LastResponse { get; set; }

    // Play the voice greeting
    public static void PlayVoiceGreeting()
    {
        try
        {
            string filePath = "welcome.wav";  // Path to your WAV file
            if (File.Exists(filePath)) // Check if file exists
            {
                SoundPlayer player = new SoundPlayer(filePath);
                player.PlaySync(); // Play the greeting sound synchronously
            }
            else
            {
                Console.WriteLine("Error: 'welcome.wav' file not found. Please ensure the file is in the project directory.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error playing voice greeting: " + ex.Message);
        }
    }

    // Display ASCII Art for the Cybersecurity Awareness Bot logo
    public static void DisplayAsciiLogo()
    {
        string asciiArt = @"
  ____ ____ ____ ____ ____ ____ 
 ||C |||y |||b |||e |||r |||S ||
 ||__|||__|||__|||__|||__|||__||
 |/__\|/__\|/__\|/__\|/__\|/__\|
 Cybersecurity Awareness Bot
        ";
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(asciiArt);
        Console.ResetColor();
    }

    // Function to handle user interactions
    public void GreetUser()
    {
        Console.Clear();

        // Display ASCII logo
        DisplayAsciiLogo();

        // Ask for the user's name
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Please enter your name: ");
        Console.ResetColor();
        UserName = Console.ReadLine();

        // Voice Greeting
        PlayVoiceGreeting();

        // Personalized greeting message
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Hello, {UserName}! Welcome to the Cybersecurity Awareness Bot!");
        Console.ResetColor();
    }

    // Basic response system for the chatbot
    public void RespondToUser(string userInput)
    {
        string response = string.Empty;

        // Convert input to lowercase to handle case-insensitive responses
        userInput = userInput.ToLower();

        if (userInput.Contains("how are you"))
        {
            response = "I'm doing great, thank you for asking! How can I assist you with cybersecurity today?";
        }
        else if (userInput.Contains("what's your purpose"))
        {
            response = "My purpose is to help you learn and stay safe online by providing cybersecurity tips and answering questions.";
        }
        else if (userInput.Contains("what can I ask"))
        {
            response = "You can ask me about topics like password safety, phishing, and safe browsing. Feel free to ask!";
        }
        else if (userInput.Contains("password safety"))
        {
            response = "It's important to use strong, unique passwords for each of your accounts. Consider using a password manager!";
        }
        else if (userInput.Contains("phishing"))
        {
            response = "Phishing attacks are when attackers try to trick you into giving away personal information. Always be cautious of suspicious emails!";
        }
        else if (userInput.Contains("safe browsing"))
        {
            response = "Make sure your browser is up-to-date and use trusted websites. Always look for HTTPS in the URL before entering any sensitive information.";
        }
        else
        {
            response = "I didn't quite understand that. Could you rephrase? If you need help with something related to cybersecurity, just ask!";
        }

        LastResponse = response;
        DisplayResponse(response);
    }

    // Function to display responses with some color formatting
    private void DisplayResponse(string response)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\nBot Response:");
        Console.ResetColor();
        Console.WriteLine(response);
    }

    // Input validation and interaction loop
    public void StartChatting()
    {
        bool continueChatting = true;

        while (continueChatting)
        {
            // Ask for user input
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\nYou: ");
            Console.ResetColor();
            string userInput = Console.ReadLine();

            // Validate input
            if (string.IsNullOrEmpty(userInput))
            {
                Console.WriteLine("Please enter something.");
                continue;
            }

            // Respond to the user
            RespondToUser(userInput);

            // Ask if they want to continue the conversation
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Would you like to ask another question? (yes/no): ");
            Console.ResetColor();
            string continueResponse = Console.ReadLine().ToLower();

            if (continueResponse != "yes")
            {
                continueChatting = false;
            }
        }

        // End the conversation
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nThank you for chatting! Stay safe online.");
        Console.ResetColor();
    }

    static void Main(string[] args)
    {
        // Create an instance of the bot
        CybersecurityBot bot = new CybersecurityBot();

        // Greet the user and start the interaction
        bot.GreetUser();
        bot.StartChatting();
    }
}
