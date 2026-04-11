using System;
using System.Media;
using System.Threading;
using static System.Console;

class Program
{
    static void Main(string[] args)
    {
        
        ShowAppLogo();
        PlayVoiceGreeting();
        string userName = GetUserName();
        ShowWelcome(userName);
        RunChatbot(userName);
    }

    

    // Logo
    static void ShowAppLogo()
    {
        Clear();
        ForegroundColor = ConsoleColor.Cyan;
        WriteLine("===============================================================");
        WriteLine(@"  ▄████▄    ██████  ▄▄▄       ▄▄▄▄   
▒██▀ ▀█  ▒██    ▒ ▒████▄    ▓█████▄ 
▒▓█    ▄ ░ ▓██▄   ▒██  ▀█▄  ▒██▒ ▄██
▒▓▓▄ ▄██▒  ▒   ██▒░██▄▄▄▄██ ▒██░█▀  
▒ ▓███▀ ░▒██████▒▒ ▓█   ▓██▒░▓█  ▀█▓
░ ░▒ ▒  ░▒ ▒▓▒ ▒ ░ ▒▒   ▓▒█░░▒▓███▀▒
  ░  ▒   ░ ░▒  ░ ░  ▒   ▒▒ ░▒░▒   ░ 
░        ░  ░  ░    ░   ▒    ░    ░ 
░ ░            ░        ░  ░ ░      
░                                 ░  ");
        ForegroundColor = ConsoleColor.Yellow;
        WriteLine("  |         Cybersecurity Awareness Bot                |");
        WriteLine("  |       Your Security, OUR Passion!!                  |");
        ForegroundColor = ConsoleColor.Cyan;
        WriteLine("  |                                                          |");
        WriteLine("  ============================================================");
        ResetColor();
        WriteLine();
    }

    // User name request
    static string GetUserName()
    {
        string userName = "";

        while (string.IsNullOrWhiteSpace(userName))
        {
            ForegroundColor = ConsoleColor.Green;
            Write("  Bot: ");
            ResetColor();
            WriteLine("Hi there! What is your name?");

            ForegroundColor = ConsoleColor.White;
            Write("  You: ");
            ResetColor();
            userName = ReadLine();

            // Input validation - empty name.
            if (string.IsNullOrWhiteSpace(userName))
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("  Please enter a valid name.");
                ResetColor();
            }
        }

        return userName.Trim();
    }
    //method for voice greeting.
    private static void PlayVoiceGreeting()
    {
        try
        {
            string audioPath = "C:\\Users\\itebo\\source\\repos\\CyberSecurityBot Part 1\\CyberSecurityBot Part 1\\greeting.wav";
            if (System.IO.File.Exists(audioPath))
            {
                SoundPlayer player = new SoundPlayer(audioPath);
                player.PlaySync();
            }
        }
        catch
        {
            // If audio fails, just continue normally.
        }
    }

    // welocoming message.
    static void ShowWelcome(string userName)
    {
        WriteLine();
        ForegroundColor = ConsoleColor.Cyan;
        WriteLine("  ============================================================");
        ForegroundColor = ConsoleColor.Yellow;
        WriteLine($"  Welcome, {userName}! I am your Cybersecurity Awareness Assistant.");
        ForegroundColor = ConsoleColor.White;
        WriteLine("  I am here to help you stay safe in the digital world.");
        ForegroundColor = ConsoleColor.Cyan;
        WriteLine("  ============================================================");
        ResetColor();
        WriteLine();
        ForegroundColor = ConsoleColor.DarkGray;
        WriteLine("  Tip: Type 'topics' to see what I can help with, or 'exit' to quit.");
        ResetColor();
        WriteLine();
    }

   
    static void RunChatbot(string userName)
    {
        bool running = true;

        while (running)
        {
            ForegroundColor = ConsoleColor.White;
            Write($"  {userName}: ");
            ResetColor();

            string input = ReadLine();

        
            if (string.IsNullOrWhiteSpace(input))
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("  Please type something. I didn't receive any input.");
                ResetColor();
                WriteLine();
                continue;
            }

            input = input.Trim().ToLower();

            WriteLine();
            ForegroundColor = ConsoleColor.DarkCyan;
            WriteLine("  ------------------------------------------------------------");
            ResetColor();

          

           
            if (input == "exit" || input == "quit" || input == "bye" || input == "done")
            {
                PrintBotMessage($"Goodbye, {userName}! Thank you for using CSAB. Stay safe online. Remember: think before you click!");
                running = false;
            }

            // General questions
            else if (input.Contains("how are you"))
            {
                PrintBotMessage($"I am doing great, thank you for asking, {userName}! Ready to help you stay cyber-safe!");
            }
            else if (input.Contains("what is your purpose") || input.Contains("your purpose") || input.Contains("who are you"))
            {
                PrintBotMessage("My purpose is to educate South African citizens about cybersecurity threats like phishing, malware, and unsafe browsing.");
            }
            else if (input.Contains("what can i ask") || input.Contains("topics") || input.Contains("help"))
            {
                PrintTopics();
            }

            // Cybersecurity topics
            else if (input.Contains("password"))
            {
                PrintPasswordTips();
            }
            else if (input.Contains("phishing") || input.Contains("scam") || input.Contains("email"))
            {
                PrintPhishingTips();
            }
            else if (input.Contains("browsing") || input.Contains("website") || input.Contains("internet"))
            {
                PrintBrowsingTips();
            }
            else if (input.Contains("malware") || input.Contains("virus"))
            {
                PrintMalwareTips();
            }
            else if (input.Contains("social engineering") || input.Contains("vishing") || input.Contains("smishing"))
            {
                PrintSocialEngineeringTips();
            }
            else if (input.Contains("2fa") || input.Contains("two factor") || input.Contains("authentication"))
            {
                Print2FATips();
            }

            // default answer
            else
            {
                PrintBotMessage("I didn't quite understand that. Could you rephrase? Try typing 'topics' to see what I can help with.");
            }

            ForegroundColor = ConsoleColor.DarkCyan;
            WriteLine("  ------------------------------------------------------------");
            ResetColor();
            WriteLine();
        }
    }


    static void PrintBotMessage(string message)
    {
        ForegroundColor = ConsoleColor.Green;
        Write("  Bot: ");
        ResetColor();

        // Typing efects
        foreach (char c in message)
        {
            Write(c);
            Thread.Sleep(15);
        }
        WriteLine();
    }

    // Topic ideas

    static void PrintTopics()
    {
        ForegroundColor = ConsoleColor.Green;
        Write("  Bot: ");
        ResetColor();
        WriteLine("Here are the topics I can help you with:");
        WriteLine();
        ForegroundColor = ConsoleColor.Yellow;
        WriteLine("       - password        (Password safety tips)");
        WriteLine("       - phishing        (Phishing and email scams)");
        WriteLine("       - browsing        (Safe browsing habits)");
        WriteLine("       - malware         (Viruses and malware)");
        WriteLine("       - social engineering  (Manipulation tactics)");
        WriteLine("       - 2fa             (Two-factor authentication)");
        ResetColor();
    }

    static void PrintPasswordTips()
    {
        ForegroundColor = ConsoleColor.Green;
        WriteLine("  Bot: Here are some password safety tips:");
        ResetColor();
        WriteLine();
        ForegroundColor = ConsoleColor.White;
        WriteLine("       1. Use at least 12 characters with letters, numbers and symbols.");
        WriteLine("       2. Never reuse the same password on different websites.");
        WriteLine("       3. Use a password manager to store your passwords safely.");
        WriteLine("       4. Never share your password with anyone.");
        WriteLine("       5. Change your password immediately if a site gets hacked.");
        ResetColor();
    }

    static void PrintPhishingTips()
    {
        ForegroundColor = ConsoleColor.Green;
        WriteLine("  Bot: Here is how to spot and avoid phishing:");
        ResetColor();
        WriteLine();
        ForegroundColor = ConsoleColor.White;
        WriteLine("       - Phishing emails pretend to be from banks, SARS, or courier companies.");
        WriteLine("       - Look for urgent language like 'Your account will be closed!'");
        WriteLine("       - Check the sender's email address carefully for small typos.");
        WriteLine("       - Never click links in suspicious emails.");
        WriteLine("       - Rather go directly to the official website yourself.");
        ResetColor();
    }

    static void PrintBrowsingTips()
    {
        ForegroundColor = ConsoleColor.Green;
        WriteLine("  Bot: Here are safe browsing tips:");
        ResetColor();
        WriteLine();
        ForegroundColor = ConsoleColor.White;
        WriteLine("       - Always check for 'https://' and the padlock icon.");
        WriteLine("       - Avoid using public Wi-Fi for banking or sensitive tasks.");
        WriteLine("       - Keep your browser updated at all times.");
        WriteLine("       - Be careful of pop-ups warning you about viruses - they are often scams.");
        WriteLine("       - Only download software from official, trusted sources.");
        ResetColor();
    }

    static void PrintMalwareTips()
    {
        ForegroundColor = ConsoleColor.Green;
        WriteLine("  Bot: Here is how to protect yourself from malware:");
        ResetColor();
        WriteLine();
        ForegroundColor = ConsoleColor.White;
        WriteLine("       - Install a reputable antivirus program and keep it updated.");
        WriteLine("       - Do not open email attachments from unknown senders.");
        WriteLine("       - Avoid downloading pirated software - it often contains viruses.");
        WriteLine("       - Back up your important files regularly.");
        WriteLine("       - Keep your operating system updated.");
        ResetColor();
    }

    static void PrintSocialEngineeringTips()
    {
        ForegroundColor = ConsoleColor.Green;
        WriteLine("  Bot: Here is what you need to know about social engineering:");
        ResetColor();
        WriteLine();
        ForegroundColor = ConsoleColor.White;
        WriteLine("       - Vishing: Fake phone calls pretending to be your bank or SARS.");
        WriteLine("       - Smishing: Fraudulent SMS messages with malicious links.");
        WriteLine("       - Never share your OTP, PIN, or password - even with 'support staff'.");
        WriteLine("       - Verify the identity of anyone asking for sensitive information.");
        WriteLine("       - If something feels wrong, hang up or ignore the message.");
        ResetColor();
    }

    static void Print2FATips()
    {
        ForegroundColor = ConsoleColor.Green;
        WriteLine("  Bot: Here is what you should know about Two-Factor Authentication:");
        ResetColor();
        WriteLine();
        ForegroundColor = ConsoleColor.White;
        WriteLine("       - 2FA adds a second layer of security beyond just your password.");
        WriteLine("       - Even if someone steals your password, they cannot log in without 2FA.");
        WriteLine("       - Use an authenticator app like Google Authenticator or Authy.");
        WriteLine("       - Enable 2FA on your email, banking apps, and social media.");
        ResetColor();
    }
}
