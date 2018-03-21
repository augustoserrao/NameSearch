/* Augusto Serrao
   Deepti Aggarwal
   Hartaj Dhillon
   Gagandeep Singh
   Shoaib Hassan
*/

using System.IO;

namespace NameSearch
{
    class NameFiles
    {
        const string BOY_NAMES_FILE_NAME = "BoyNames.txt";
        const string GIRL_NAMES_FILE_NAME = "GirlNames.txt";

        static public string[] GetBoyNames()
        {
            string[] nameArray = File.ReadAllLines(BOY_NAMES_FILE_NAME);

            // Set names to lower case
            for (int i = 0; i < nameArray.Length; i++)
            {
                nameArray[i] = nameArray[i].ToLower();
            }

            return nameArray;
        }
        static public string[] GetGirlNames()
        {
            string[] nameArray = File.ReadAllLines(GIRL_NAMES_FILE_NAME);

            // Set names to lower case
            for (int i = 0; i < nameArray.Length; i++)
            {
                nameArray[i] = nameArray[i].ToLower();
            }

            return nameArray;
        }
    }
}
