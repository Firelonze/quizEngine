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

           
            Console.ForegroundColor = ConsoleColor.White;
            
            //loop through questions
            int i = 0;
            foreach(Question q in questions){
                Console.Clear();
                Console.WriteLine("Score : "+score);
                i++;
                Console.WriteLine("question "+i+": "+ q.GetString());
                int j = 0;
                foreach(Answer a in q.GetOptions()){
                    j++;
                    Console.WriteLine("Type  "+ j + " for : "+a.GetString());   
                }
                
                //Await player input
                //input still needs validation
                int input  = Convert.ToInt32(Console.ReadLine());
                int result = q.AnswerIt(input-1);//returns -1 if wrong
                if(result > -1){//RIGHT
                    score += result;
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.DarkGreen;                    
                    Console.WriteLine("Correct!");
                    Console.WriteLine("+" +result);
                    Console.Beep(1200, 200);
                    Thread.Sleep(1000);
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Black;    
                }else{//WRONG
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Red;                    
                    Console.WriteLine("WRONG!");
                    Console.Beep(900, 1000);
                    Thread.Sleep(1000);
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Black;                       
                }                
            }
            //After questions are answered player enters highscore
            Console.Clear();
            Console.WriteLine("Game Over your score is : "+ score + " points");       
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
            Console.ForegroundColor = ConsoleColor.White;
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
                new Question("Welke hit scoorde David Hasselhoff in 1989 in Nederland",
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
                2)
            };

        }
        
    }
}
