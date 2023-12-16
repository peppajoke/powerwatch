using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Recognition;

class SpeechListener
{
    private SpeechRecognitionEngine sre;

    public void Listen()
    {
        sre = new SpeechRecognitionEngine();

        // Create SemanticResultValue objects for specific phrases and associate them with intents
        SemanticResultValue updateEnemyTeamIntent = new SemanticResultValue("update enemy team", "UpdateEnemyTeamIntent");

        // Create a Choices object and add the SemanticResultValue objects
        Choices commands = new Choices();
        commands.Add(updateEnemyTeamIntent);
        foreach(var heroSemantic in GetHeroNameSemantics())
        {
            commands.Add(heroSemantic);
        }

        // Build the phrase and add SemanticResultKeys
        GrammarBuilder chooseCommands = new GrammarBuilder();
        chooseCommands.Append(new SemanticResultKey("command", commands));

        // Build a Grammar object from the GrammarBuilder
        Grammar commandGrammar = new Grammar(chooseCommands);
        commandGrammar.Name = "CommandGrammar";

        // Load the grammar object to the recognizer
        sre.LoadGrammar(commandGrammar);

        sre.SpeechRecognized += SreSpeechRecognized;

        sre.SetInputToDefaultAudioDevice();
        sre.RecognizeAsync(RecognizeMode.Multiple);
    }

    private IEnumerable<SemanticResultValue> GetHeroNameSemantics()
    {
        var semantics = HeroDefinition.EveryHero().Select(x => new SemanticResultValue(x.ToString().ToLower(), "Hero:" + x.ToString())).ToList();

        var mumbles = new Dictionary<HeroName, List<string>>
        {
           { HeroName.DVA, new List<string> { "dee va", "diva", "deevuh", "deev"} },
           { HeroName.JUNKERQUEEN, new List<string> { "junker", "queen", "junkqueen", "junkyqueen", "junker queen", "junner queen"} },
           { HeroName.MAUGA, new List<string> { "mow guh", "maui", "mowee", "maga", "maw guh", "mowie", "mawguh", "mow ga"} },
           { HeroName.DOOMFIST, new List<string> { "doom", "doomf", "dume fest", "doom fist"} },
           { HeroName.GENJI, new List<string> { "gen", "gen jee"} },
           { HeroName.ECHO, new List<string> { "ecko", "eck oh"} },
           { HeroName.CASSIDY, new List<string> { "cass", "mccree", "mick kree", "cass iddie"} },
           { HeroName.BASTION, new List<string> { "bast yun", "basteon", "bast"} },
           { HeroName.ASHE, new List<string> { "ash", "ass", "ask"} },
           { HeroName.ZARYA, new List<string> { "zary uh", "zar e uh", "zaria", "zar yuh"} },
           { HeroName.WRECKINGBALL, new List<string> { "hampster", "hamp", "wrecking ball", "reck ing ball"} },
           { HeroName.WINSTON, new List<string> { "win", "win stun", "win ston"} },
           { HeroName.SIGMA, new List<string> { "sig ma", "sig muh", "sig"} },
           { HeroName.ROADHOG, new List<string> { "road hog", "rode hawg", "roadie", "hog"} },
           { HeroName.REINHARDT, new List<string> { "rine heart", "rine hart", "rhine heart"} },
           { HeroName.RAMATTRA, new List<string> { "ramat", "ramattr", "rahm"} },
           { HeroName.ORISA, new List<string> { "oh riss uh", "orissa", "o ris ah", "oris"} },
           { HeroName.SOLDIER76, new List<string> { "76"} },
        };

        foreach(var kvp in mumbles)
        {
            string heroName = kvp.Key.ToString();
            semantics.AddRange(kvp.Value.Select(x => new SemanticResultValue(x.ToLower(), "Hero:" + heroName)));
        }

        semantics.Add(new SemanticResultValue("enemies", PhraseType.Command + ":" + CommandState.ChangingEnemyTeam));
        semantics.Add(new SemanticResultValue("enemy", PhraseType.Command + ":" + CommandState.ChangingEnemyTeam));
        semantics.Add(new SemanticResultValue("update enemy team", PhraseType.Command + ":" + CommandState.ChangingEnemyTeam));

        return semantics;
    }

    private void SreSpeechRecognized(object sender, SpeechRecognizedEventArgs e)
    {
        if (e.Result.Confidence >= 0.1) // You can adjust this threshold
        {
            foreach (KeyValuePair<String, SemanticValue> child in e.Result.Semantics)
            {
                HandlePhrase(child.Value.Value.ToString());
            }
        }
        else
        {
            Console.WriteLine($"Low confidence result: {e.Result.Text} (Confidence: {e.Result.Confidence})");
            // You can implement a retry mechanism or take other actions for low-confidence results
        }
    }

    enum CommandState
    {
        Waiting, ChangingEnemyTeam, AddFoe
    }

    enum PhraseType
    {
        Command, Hero
    }

    private List<HeroName> _newHeroes = new List<HeroName>();

    private CommandState _commandState = CommandState.Waiting;

    private void HandlePhrase(string rawVoiceText)
    {
        var response = new VoiceResponse(rawVoiceText);
        switch(_commandState)
        {
            case CommandState.Waiting:

                CommandState cmd;
                if (Enum.TryParse(response.Value, out _commandState))
                {
                    Console.WriteLine("new command received...");
                }

                break;
            case CommandState.ChangingEnemyTeam:
                if (response.Phrase == PhraseType.Hero)
                {
                    HeroName hero;
                    if (Enum.TryParse(response.Value, out hero))
                    {
                        _newHeroes.Add(hero);
                        Console.WriteLine(hero.ToString());
                        if (_newHeroes.Count == 5)
                        {
                            Console.WriteLine("done, flushing team...");
                            Program.SwapEnemyTeam(_newHeroes);
                            _newHeroes.Clear();
                        }
                    }
                }
                break;
            default:
                break;
        }

    }



    class VoiceResponse
    {
        public PhraseType Phrase;
        public string Value;

        public VoiceResponse(string text)
        {
            var pieces  = text.Split(':');
            Value = pieces[1];

            if (!Enum.TryParse(pieces[0], out Phrase))
            {
                // The conversion failed (string does not match any enum value)
                Console.WriteLine($"Failed to convert string '{pieces[0]}' to enum value");
            }
        }
    }



    public void StopListening()
    {
        sre?.RecognizeAsyncCancel();
        sre?.Dispose();
    }
}