// contains declarations and interface implementaions for StudentList<T> class
using System.Collections;
using System.Linq;
using System.Text.Json;
namespace Tasks
{
    public partial class StudentList<T> : IEnumerable<T> where T : IStudent
    {
        private readonly List<T> _StudentList;
        public StudentList()
        {
            _StudentList = new List<T>();
        }

        const string INVALID_INPUT_ERROR_MSG = "Error occured because of invalid input by the user";
        const string SERIALIZATION_ERROR_MSG = "Error occured while serialization";
        const string DESERIALIZATION_ERROR_MSG = "Error occured while deserialization";

        public enum Verbose
        {
            None = 0,
            Show = 1
        }

         public IEnumerator<T> GetEnumerator()
        {
            return _StudentList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _StudentList.GetEnumerator();
        }

        public object this[int index]
        {
            get { return _StudentList[index]; }
            set
            {
                _StudentList[index] = (T)value;
            }
        }




    }
}