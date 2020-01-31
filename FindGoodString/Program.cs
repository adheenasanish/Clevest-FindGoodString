using System;
using System.IO;

namespace FindGoodString
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] stringArray = { };
            string vowels = "aeiou";
            string[] excludedStrings = { "ab", "cd", "pq", "xy" };
            int vowelCount = 0;
            bool flag = false;
            bool checkFlag = false;
            int goodStringCount = 0;

            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader("C://USers/adhee/source/repos/FindGoodString/question03_input.txt"))
                {
                    // Read the stream to a string
                    string line = sr.ReadToEnd();
                    int l = line.Length;
                    // Console.WriteLine(line);
                    stringArray = new string[line.Length];

                    using (StringReader stringReader = new StringReader(line))
                    {
                        for (int index = 0; index < line.Length; index++)
                        {
                            string eachString = stringReader.ReadLine();
                            stringArray[index] = eachString;

                        }

                    }

                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            foreach (string word in stringArray)
            {
                if (word != null)
                {
                    // Check for vowels
                    foreach (char vowel in vowels)
                    {
                        if (word.Contains(vowel))
                        {
                            vowelCount++;
                        }
                    }
                    //Check if there is any excluded strings in the string
                    foreach (string excludedString in excludedStrings)
                    {
                        if (word.Contains(excludedString))
                        {
                            flag = true;
                            break;
                        }
                    }
                    //Check for double character
                    for (int firstIndex = 0; firstIndex < word.Length; firstIndex++)
                    {
                        for (int nextIndex = firstIndex + 1; nextIndex < word.Length; nextIndex++)
                        {
                            if (word[firstIndex] == word[nextIndex])
                            {
                                checkFlag = true;
                            }
                            break;
                        }
                    }
                    //Check wether the string meets all criteria
                    if (vowelCount >= 3 && flag == false && checkFlag == true)
                    {
                        goodStringCount++;
                    }
                    vowelCount = 0;
                    checkFlag = false;
                    flag = false;

                }

            }
            Console.WriteLine("This file contains {0} good string", goodStringCount);



            Console.ReadLine();

        }
    }
}
