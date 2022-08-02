using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.IO;
using System.Diagnostics;
//using SpotifyAPI.Web;

namespace Jarvis
{
    public partial class Jarvis : Form
    {
        SpeechRecognitionEngine _recognizer = new SpeechRecognitionEngine();
        SpeechSynthesizer jarvis = new SpeechSynthesizer();
        SpeechRecognitionEngine startListening = new SpeechRecognitionEngine();
        Random random = new Random();
        int RecTimeOut = 0;
        DateTime timeNow = DateTime.Now;
        public Jarvis()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _recognizer.SetInputToDefaultAudioDevice();
            _recognizer.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices(File.ReadAllLines(@"DefaultCommands.txt")))));
            _recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(Default_SpeechRecognized);
            _recognizer.SpeechDetected += new EventHandler<SpeechDetectedEventArgs>(_recognizer_SpeechRecognized);
            _recognizer.RecognizeAsync(RecognizeMode.Multiple);

            startListening.SetInputToDefaultAudioDevice();
            startListening.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices(File.ReadAllLines(@"DefaultCommands.txt")))));
            startListening.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(startListening_SpeechRecognized);
        }

        string speechOutput;
        public void GameMode()
        {
            Process.Start(@"C:\Program Files (x86)\Steam\steam.exe");
            Process.Start(@"C:\Program Files (x86)\Epic Games\Launcher\Portal\Binaries\Win32\EpicGamesLauncher.exe");
            Process.Start(@"C:\Users\badgo\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Discord Inc\Discord.lnk");
        }

        public void CodeMode()
        {
            Process.Start(@"C:\Program Files\Microsoft Visual Studio\2022\Community\Common7\IDE\devenv.exe");
            Process.Start(@"C:\Program Files\Google\Chrome\Application\chrome.exe");
        }

        private void Default_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            int randomNumber;
            string speech = e.Result.Text;
            speechOutput = speech;
            if (speech == "Jarvis Open youtube")
            {
                jarvis.SpeakAsync("Opening Youtube");
                Process.Start("https://www.youtube.com");
            }
            if (speech == "Jarvis Open chrome")
            {
                jarvis.SpeakAsync("Opening google chrome");
                Process.Start(@"C:\Program Files\Google\Chrome\Application\chrome.exe");
            }
            if (speech == "Jarvis Open discord")
            {
                jarvis.SpeakAsync("Opening discord");
                Process.Start(@"C:\Users\badgo\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Discord Inc\Discord.lnk");
            }
            if (speech == "Jarvis Open fall guys")
            {
                jarvis.SpeakAsync("Opening fall guys");
                Process.Start(@"C:\\Program Files\\Epic Games\\FallGuys\\FallGuys_client.exe");
            }
            if (speech == "Jarvis Open powerwash simulator")
            {
                jarvis.SpeakAsync("Opening powerwash simulator");
                Process.Start(@"C:\\Program Files (x86)\\Steam\\steamapps\\common\\PowerWash Simulator\\PowerWashSimulator.exe");
            }
            if (speech == "Jarvis Open raindbow six siege")
            {
                jarvis.SpeakAsync("Opening raindbow six siege");
                Process.Start(@"C:\Program Files (x86)\Steam\steamapps\common\Tom Clancy's Rainbow Six Siege\\RainbowSix.exe");
            }
            if (speech == "Jarvis Game mode")
            {
                jarvis.SpeakAsync("Executing game mode");
                GameMode();
            }
            if (speech == "Jarvis Code mode")
            {
                jarvis.SpeakAsync("Executing code mode");
                CodeMode();
            }
            if (speech == "Jarvis What time is it")
            {
                jarvis.SpeakAsync(DateTime.Now.ToString("h mm tt"));
            }
            if (speech == "Jarvis Stop talking")
            {
                jarvis.SpeakAsyncCancelAll();
                randomNumber = random.Next(1, 2);
                if (randomNumber == 1)
                {
                    jarvis.SpeakAsync("Yes Sir");
                }
                if (randomNumber == 2)
                {
                    jarvis.SpeakAsync("I am sorry i will be quiet");
                }
            }
            if (speech == "Jarvis Sleep")
            {
                _recognizer.RecognizeAsyncCancel();
                startListening.RecognizeAsync(RecognizeMode.Multiple);
            }

            if (speech == "Jarvis Show commands")
            {
                string[] commands = (File.ReadAllLines(@"DefaultCommands.txt"));
                commandsListBox.Items.Clear();
                commandsListBox.SelectionMode = SelectionMode.None;
                commandsListBox.Visible = true;
                foreach (string command in commands)
                {
                    commandsListBox.Items.Add(command);
                }
            }
            if (speech == "Jarvis Hide commands")
            {
                commandsListBox.Visible = false;
            }
        }

        private void _recognizer_SpeechRecognized(object sender, SpeechDetectedEventArgs e)
        {
            RecTimeOut = 0;
        }

        private void startListening_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string speech = e.Result.Text;

            if(speech == "Jarvis Wake up")
            {
                startListening.RecognizeAsyncCancel();
                jarvis.SpeakAsync("I am here");
                _recognizer.RecognizeAsync(RecognizeMode.Multiple);
            }
        }

        private void speakingTimer_Tick(object sender, EventArgs e)
        {
            if (RecTimeOut == 10)
            {
                _recognizer.RecognizeAsyncCancel();
            }
            else if (RecTimeOut == 11)
            {
                speakingTimer.Stop();
                startListening.RecognizeAsync(RecognizeMode.Multiple);
                RecTimeOut = 0;
            }
        }

        private void speechOutputTimer_Tick(object sender, EventArgs e)
        {
            Console.WriteLine(speechOutput);
        }
    }
}
