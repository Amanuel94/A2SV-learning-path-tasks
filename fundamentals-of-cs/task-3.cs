namespace Tasks{
    public class PalindromeChecker{
        public bool CheckPalindrome(string word){
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