using System;
using System.Text.RegularExpressions;

namespace _02._Song_Encryption
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            Regex regex = new Regex(@"^^([A-Z][a-z'\s]+):([A-Z\s]+)$");

            while (line != "end")
            {
                if (regex.IsMatch(line))
                {
                    string artist = regex.Match(line).Groups[1].Value;
                    string song = regex.Match(line).Groups[2].Value;

                    string artistEncrypt = string.Empty;
                    string songEncrypt = string.Empty;
                    int key = artist.Length;

                    for (int i = 0; i < artist.Length; i++)
                    {
                        if (artist[i] == '\'' || artist[i] == ' ')
                        {
                            artistEncrypt += artist[i];
                            continue;
                        }
                        int encrypted = artist[i] + key;

                        if (artist[i] >= 65 && artist[i] <= 90)
                        {
                            if (encrypted > 90)
                            {
                                encrypted -= 26;
                            }
                        }
                        else if (artist[i] >= 97 && artist[i] <= 122)
                        {
                            if (encrypted > 122)
                            {
                                encrypted -= 26;
                            }
                        }

                        artistEncrypt += (char)encrypted;
                    }

                    for (int i = 0; i < song.Length; i++)
                    {
                        if (song[i] == '\'' || song[i] == ' ')
                        {
                            songEncrypt += song[i];
                            continue;
                        }
                        int encrypted = song[i] + key;

                        if (song[i] >= 65 && song[i] <= 90)
                        {
                            if (encrypted > 90)
                            {
                                encrypted -= 26;
                            }
                        }
                        else if (song[i] >= 97 && song[i] <= 122)
                        {
                            if (encrypted > 122)
                            {
                                encrypted -= 26;
                            }
                        }

                        songEncrypt += (char)encrypted;
                    }

                    Console.WriteLine($"Successful encryption: {artistEncrypt}@{songEncrypt}");
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }



                line = Console.ReadLine();
            }
        }
    }
}
