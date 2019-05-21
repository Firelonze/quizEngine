namespace quizEngine{
    class Answer{
        private string answer;
        public Answer(string answer){
            this.answer = answer;
        }
        public string GetString(){
            return this.answer;
        }
    }
}