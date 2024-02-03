/*
var birthday = new DateTime(2001, 01, 10);
var now = new DateTime(2003, 04, 08);
TimeSpan age = now - birthday;
Console.WriteLine(age.Days);

*/


using System;
using System.Collections.Generic;
using System.IO;




string nameFile = "salom.jpg";

string path_1 = @"D:\";

foreach (var item in Directory.GetFiles(path_1))
{
    string[] word = item.Split('\\');

    if (word[word.Length - 1] == nameFile)
    {
        Console.WriteLine(item.ToString());
    }
}
Open_directory(path_1, nameFile);
void Open_directory(string path, string nameFile)
{
    try
    {
        string[] directors = Directory.GetDirectories(path);

        foreach (string directory in directors)
        {
            foreach (var item in Directory.GetFiles(directory))
            {
                string[] text = item.Split('\\');

                if (text[text.Length - 1] == nameFile)
                {
                    Console.WriteLine(item.ToString());
                }
            }
            Open_directory(directory, nameFile);
        }
    }
    catch (Exception ex)
    {

    }

}







