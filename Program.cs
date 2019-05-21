using System;
using System.Collections.Generic;
using System.Threading;

namespace quizEngine
{
    class Program
    {
        private static int score = 0;
        static void Main(string[] args)
        {
            //create questions and answers
            List<Question> questions = new List<Question>{
                new Question("Hoe lang is een chinees?",
                10,
                new List<Answer>{
                    new Answer("Dat is leuk"),
                    new Answer("2 meter"), 
                    new Answer("heel lang")
                    },
                0),

                new Question("Hoe lang duurde de 2e wereld oorlog?",
                10,
                new List<Answer>{
                    new Answer("15 jaar"),
                    new Answer("5 jaar"), 
                    new Answer("2 jaar")
                    },
                1),

                new Question("Waarom zijn de bananen krom?",
                10,
                new List<Answer>{
                    new Answer("omdat ze geel zijn"),
                    new Answer("vanwege redenen"), 
                    new Answer("omdat ze niet recht zijn")
                    },
                1),

                new Question("Wie is Edgar Bosscher?",
                10,
                new List<Answer>{
                    new Answer("Burgermester van Amsterdam"),
                    new Answer("Directeur van het MA"), 
                    new Answer("Stagebegeleider van Game Artist"), 
                    new Answer("Een superspion")},
                2)
            };
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
                
                int input  = Convert.ToInt32(Console.ReadLine());
                int result = q.AnswerIt(input-1);//-1 ivm arrayIndex start bij 0
                if(result > -1){
                    score += result;
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.DarkGreen;                    
                    Console.WriteLine("Correct!");
                    Console.WriteLine("+" +result);
                    Console.Beep(1200, 200);
                    Thread.Sleep(1000);
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Black;    
                }else{
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Red;                    
                    Console.WriteLine("WRONG!");
                    Console.Beep(900, 1000);
                    Thread.Sleep(1000);
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Black;                       
                }                
            }
            Console.Clear();
            Console.WriteLine("Game Over your score is : "+ score + " points");            
        }
    }
}
