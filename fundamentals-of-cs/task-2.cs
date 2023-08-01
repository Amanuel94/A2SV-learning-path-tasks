
using System.Text;
namespace Tasks{
    public class WordsCounter{
 
        /*  A function that is used to preprocess the text before counting 
        */
        private string[] Transform(string input){
            
            string[] words = input.Split(' ');
            int n_words = words.Length;
            string[] transformed_input = new string[n_words];
            for(int i = 0; i < n_words; i++)
            {
                string word = words[i];
                StringBuilder transformed_word = new StringBuilder();
                foreach (var ch in word)
                {
                    // since the word counter cannot be case sensetive and ignore punctuation
                    if (char.IsLetter(ch)){
                        transformed_word.Append(char.ToLower(ch));
                    }
                }
                transformed_input[i] = transformed_word.ToString();

            }
            return transformed_input;
        }

        public Dictionary<string, int> CountWords(string input){

            string [] transformed_input = this.Transform(input);
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            foreach (string word in transformed_input)
            {   
                  if(dictionary.ContainsKey(word)){
                    dictionary[word]+=1;
                  }  
                  else{
                    dictionary[word] = 1;
                  }
                
            }
            return dictionary;


        }
    }
}