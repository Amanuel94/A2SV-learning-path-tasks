using System.Text;
namespace Tasks{
    public class PalindromeChecker{
    

        private string Transform(string word){
            StringBuilder transformed_text = new StringBuilder();
            foreach (var ch in word)
            {
                if(char.IsLetter(ch))
                    transformed_text.Append(char.ToLower(ch));
            }
            return transformed_text.ToString();
        }
        public bool CheckPalindrome(string word){
            
            word = Transform(word);
            int len_word = word.Length;
            for (int i = 0; i <= len_word/2; i++)
            {
              if(!word[i].Equals(word[len_word-1-i])){
                return false;
              }      
            }
            return true;
        }
    }
}