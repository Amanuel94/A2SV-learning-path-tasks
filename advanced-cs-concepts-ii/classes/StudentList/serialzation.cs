// contains serialization functionalities for StudentList<T> class

using System.Collections;
using System.Linq;
using System.Text.Json;
namespace Tasks
{
    public partial class StudentList<T> : IEnumerable<T> where T : IStudent
    {
        public async Task ToJsonAsync(string filePath)
        {
            var options = new JsonSerializerOptions { WriteIndented = true, IgnoreReadOnlyProperties = false, IgnoreReadOnlyFields = false };
            try
            {
                // string filePath = Path.Combine("serialized", FilePath);
                using (FileStream createStream = File.Create(filePath))
                {
                    Console.WriteLine("Serializing list...");
                    await JsonSerializer.SerializeAsync(createStream, _StudentList, options);
                }
                Console.WriteLine("Finalized Serializing to " + filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(SERIALIZATION_ERROR_MSG);
            }
        }

        // asynchronous deserialization
        public async Task<List<T>?>? DeserializeAsync<Tval>(string filePath)
        {
            Console.WriteLine("Deserializing JSON...");
            try{
            using FileStream stream = File.OpenRead(filePath);
            Console.WriteLine("Deserialization Done");
            return await JsonSerializer.DeserializeAsync<List<T>>(stream);}
            catch(Exception ex){
                Console.WriteLine("Deserialization Failed.");
                throw new Exception($"{DESERIALIZATION_ERROR_MSG}: {ex.Message}");
            }
        }

        
    }
}