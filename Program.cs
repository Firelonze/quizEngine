using System;
using System.Collections.Generic;
using System.Threading;
using System.IO;

namespace quizEngine
{ 
    class Program
    {
        private static int score = 0;
        static void Main(string[] args)
        {    
            //create questions and answers            
            List<Question> questions = CreateQuestions();
                       
            Console.ForegroundColor = ConsoleColor.Green;
            
            //loop through questions
            int i = 0;
            foreach(Question q in questions){
                Console.Clear();
                Console.WriteLine("Score : "+score);
                i++;
                Console.WriteLine("Vraag "+i+": "+ q.GetString());
                int j = 0;
                foreach(Answer a in q.GetOptions()){
                    j++;
                    Console.WriteLine("Vul "+ j + " in voor : "+a.GetString());   
                }
                
                //Await player input and validate if it's an int
                int input;
                bool parsed = false;
                do{
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Antwoorden met een nummer A.U.B");
                    parsed = int.TryParse(Console.ReadLine(), out input);
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                while(!parsed);
                 
                int result = q.AnswerIt(input-1);//returns -1 if wrong

                if(result > -1){//RIGHT
                    score += result;
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine(
"_▄████████___▄██████▄_____▄████████____▄████████____▄████████__▄████████_____███________" +
"_███____███_███____███___███____███___███____███___███____███_███____███_▀█████████▄____" +
"_███____█▀__███____███___███____███___███____███___███____█▀__███____█▀_____▀███▀▀██____" +
"_███________███____███__▄███▄▄▄▄██▀__▄███▄▄▄▄██▀__▄███▄▄▄_____███____________███___▀____" +
"_███________███____███_▀▀███▀▀▀▀▀___▀▀███▀▀▀▀▀___▀▀███▀▀▀_____███____________███________" +
"_███____█▄  ███____███_▀███████████_▀███████████___███____█▄  ███____█▄______███________" +
"_███____███ ███____███___███____███___███____███___███____███_███____███_____███________" +
"_████████▀___▀██████▀____███____███___███____███___██████████_████████▀_____▄████▀______" +
"_________________________███____███___███____███________________________________________");
                    Console.WriteLine("+" +result);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Beep(1000, 400);
                    Thread.Sleep(1000);
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Black;
                                    }
                else{//WRONG
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.BackgroundColor = ConsoleColor.Red;                    
                    Console.WriteLine(
"_______________▄█_____█▄_____▄████████__▄██████▄__███▄▄▄▄______▄██████▄__________________" +
"_____________███_____███___███____███_███____███_███▀▀▀██▄___███____███_________________" +
"_____________███_____███___███____███_███____███_███___███___███____█▀__________________" +
"_____________███_____███__▄███▄▄▄▄██▀_███____███_███___███__▄███________________________" +
"_____________███_____███_▀▀███▀▀▀▀▀___███____███_███___███_▀▀███_████▄__________________" +
"_____________███_____███_▀███████████_███____███_███___███___███____███_________________" +
"_____________███ ▄█▄ ███___███____███_███____███_███___███___███____███_________________" +
"______________▀███▀███▀____███____███__▀██████▀___▀█___█▀____████████▀__________________" +
"___________________________███____███___________________________________________________");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Beep(700, 1000);
                    Thread.Sleep(1000);
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Black;
                }                
            }
            //After questions are answered player enters name for highscore
            Console.Clear();
            Console.WriteLine("Game Over your score is "+ score + " points");       
            Console.WriteLine("Please enter your name:");
            string playerName = Console.ReadLine();
            HighScore.WriteHighScore(playerName,score,"highScore.txt");        


            //print highscore after highscore is saved
            string[] highScore = ListSorter.GetSortedHighScore("highScore.txt");
            
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("+++++++++++++ Highscore +++++++++++++");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
            int count = highScore.Length;
            if(count>10)count =10;
            for(int k=0;k<count;k++){
                Console.WriteLine(highScore[k]);
            }   
        }
       
        static List<Question> CreateQuestions(){
            return new List<Question>{

                new Question("Hoe lang was Michael Jackson?",
                50,
                new List<Answer>{
                    new Answer("1 meter 75"),
                    new Answer("2 meter"),
                    new Answer("1 meter 65")
                    },
                0),
                new Question("Waardoor stierf Bob Marley?",
                50,
                new List<Answer>{
                    new Answer("De sherrif schoot hem neer"),
                    new Answer("Hij had een overdisis drugs gebruikt"),
                    new Answer("Hij had kanker")
                    },
                2),
                new Question("Welke hit scoorde David Hasselhoff in 1989 in Nederland?",
                50,
                new List<Answer>{
                    new Answer("Creature of the night"),
                    new Answer("Baby you can drive my car"),
                    new Answer("I've been looking for freedom")
                    },
                2),
                new Question("Welke hit was niet van Whitney Houston?",
                75,
                new List<Answer>{
                    new Answer("I will always love you"),
                    new Answer("One moment in time"),
                    new Answer("My heart will go on"),
                    new Answer("So emotional")
                    },
                2),
                new Question("Welke artiest heeft niet opgetreden bij Live-Aid?",
                100,
                new List<Answer>
                {
                    new Answer("Queen"),
                    new Answer("Elton John"),
                    new Answer("David Bowie"),
                    new Answer("Wham!"),
                    new Answer("a-ha")
                },
                4),
                new Question("Welk liedje is niet van Queen?",
                100,
                new List<Answer>
                {
                    new Answer("Killer Queen"),
                    new Answer("Another one bites the dust"),
                    new Answer("Keep yourself alive"),
                    new Answer("Dancing Queen"),
                    new Answer("Bohemian Rhapsody"),
                },
                3),
                new Question("Welk liedje had Rick Astley niet geschreven?",
                75,
                new List<Answer>
                {
                    new Answer("Lights Out"),
                    new Answer("Never Gonna Give You Up"),
                    new Answer("Keep Singing"),
                    new Answer("Turn All the Lights On"),
                },
                3),
                new Question("Welke zin maakt geen deel uit van de lyrics in 'Turning Japanese'?",
                75,
                new List<Answer>
                {
                    new Answer("No sex,No drugs, No wine, No women"),
                    new Answer("I want to hang our pictures on the wall"),
                    new Answer("I'd like a million of you all 'round my cell"),
                    new Answer("Turning Japanese, I think I'm turning Japanese, I really think so"),
                },
                1),
                new Question("Welke zin maakt geen deel uit van de lyrics in 'Eye of the Tiger'?",
                75,
                new List<Answer>
                {
                    new Answer("For the kill with the skill to survive"),
                    new Answer("They stack the odds 'till we take to the street"),
                    new Answer("All sort of shit happens in the downtown"),
                    new Answer("Went the distance, now I'm not gonna stop"),
                },
                2),
                new Question("Welke zin maakt geen deel uit van de lyrics in 'Never Gonna give you up'?",
                75,
                new List<Answer>
                {
                    new Answer("Never gonna give, Never gonna miss"),
                    new Answer("Don't tell me you're too blind to see"),
                    new Answer("Never gonna give, never gonna give"),
                    new Answer("Your heart's been aching but you're too shy to say it"),
                },
                0),
                new Question("Welke horror film is gemaakt in de 80's?",
                150,
                new List<Answer>
                {
                    new Answer("The Texas Chainsaw Massacre"),
                    new Answer("The Blair Witch Project"),
                    new Answer("The Exorcist"),
                    new Answer("IT"),
                    new Answer("Psycho"),
                    new Answer("Alien"),
                    new Answer("The Shining"),
                    new Answer("RoseMary's Baby"),
                },
                6)
             };

        }
        
    }
}
