using System;
using System.IO;
using System.Collections.Generic;
namespace quizEngine{
    class ListSorter{
            //Load and read textfile
            public static string[]  GetSortedHighScore(string file){            

            string[] raw = File.ReadAllLines(file);
            int lineCount = raw.Length;

            List<int> scoresUnsorted = new List<int>();
            List <string> namesUnsorted = new List<string>();

            //split names from scores
            for(int i=0;i<lineCount;i++){            
                string[] sub = raw[i].Split(':');
                namesUnsorted.Add(sub[0]); 
                int s; 
                Int32.TryParse(sub[1],out s);             
                scoresUnsorted.Add(s);  
            }            
            //sort algorithm
            List<int> sortedScores = new List<int>();
            List<string> sortedNames = new List<string>();
            int highest = 0;
            int highestIndex = 0;                   
            for(int j = scoresUnsorted.Count-1; j >= 0; j--){
                for(int i =scoresUnsorted.Count-1; i >= 0; i--){
                    if(scoresUnsorted[i] > highest){                        
                        highest = scoresUnsorted[i];
                        highestIndex = i;                                          
                    }
                }                
                sortedScores.Add(scoresUnsorted[highestIndex]);
                sortedNames.Add(namesUnsorted[highestIndex]);
                scoresUnsorted.RemoveAt(highestIndex);
                namesUnsorted.RemoveAt(highestIndex);
                highestIndex = 0;
                highest = 0;
            }
            //merge score and name lists
            string[] sortedHighScore = new string[lineCount]; 
            for(int k = 0; k < lineCount; k++){
                sortedHighScore[k] = sortedNames[k]+" : "+sortedScores[k];
            }
        return sortedHighScore;
        }
    }
}