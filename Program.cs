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
            
            List<Question> questions = new List<Question>{
            
                new Question("Hoe lang is een chinees?",
                100,
                new List<Answer>{
                    new Answer("Dat is leuk"),
                    new Answer("2 meter"), 
                    new Answer("heel lang")
                    },
                0),
              

               

                new Question("Wie is Edgar Bosscher?",
                50,
                new List<Answer>{
                    new Answer("Burgermester van Amsterdam"),
                    new Answer("Directeur van het MA"), 
                    new Answer("Stagebegeleider van Game Artist"), 
                    new Answer("Een superspion")},
                2)
            };
            
/*
            
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

*/
/*
            Console.WriteLine("Please enter your name:");
            string playerName = Console.ReadLine();
            WriteHighScore(playerName,score);        
*/

//print highscore 

            string[] highScore = GetSortedHighScore("highScore.txt");   
            foreach(string s in highScore){
                Console.WriteLine(s);
            }   
        }
        static async void WriteHighScore(string playerName, int s){
            using (StreamWriter sw = new StreamWriter("highScore.txt",true)){
                await sw.WriteLineAsync(playerName + ":" + s);
            }  
        }
        static string[]  GetSortedHighScore(string file){            

            string[] raw = File.ReadAllLines(file);
            int lineCount = raw.Length;

            List<int> scoresUnsorted = new List<int>();
            string[] namesUnsorted = new string[lineCount];

            //split names from scores
            for(int i=0;i<lineCount;i++){            
                string[] sub = raw[i].Split(':');


                namesUnsorted[i] = sub[0]; 

                int s; 
                Int32.TryParse(sub[1],out s);             
                scoresUnsorted.Add(s);  



            }            
            //sort algorithm
            int[] sortedScores = new int[lineCount];
            string[] sortedNames = new string[lineCount];
            int highest = 0;
            int highestIndex = 0;
           

           //Algoritme klopt niet!!
            for(int j = lineCount-1; j >= 0; j--){



                Console.WriteLine("j:"+j);
                for(int i =scoresUnsorted.Count-1; i >= 0; i--){
                    Console.WriteLine("i"+i);
                    Console.WriteLine(scoresUnsorted[i]+" >? "+highest);
                    if(scoresUnsorted[i] > highest){
                        
                        highest = scoresUnsorted[i];
                        highestIndex = i;   
                        Console.WriteLine("highest:"+highest);                   
                    }
                }
                sortedScores[j] = scoresUnsorted[highestIndex];
                sortedNames[j] = namesUnsorted[highestIndex];
                scoresUnsorted.RemoveAt(highestIndex);
                highestIndex = 0;
            }
            Console.WriteLine(lineCount);
            string[] sortedHighScore = new string[lineCount]; 
            for(int k = 0; k < lineCount; k++){
                sortedHighScore[k] = sortedNames[k]+" : "+sortedScores[k];
                Console.WriteLine("sorted names"+sortedNames[k]);

            }
        return sortedHighScore;
        }
    }
}
