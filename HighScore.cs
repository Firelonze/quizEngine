using System.IO;
namespace quizEngine{
    class HighScore{    

        public static void WriteHighScore(string playerName, int s, string file){
            using (StreamWriter sw = new StreamWriter(file,true)){
                sw.WriteLine(playerName + ":" + s);
            }  
        }
    }
}