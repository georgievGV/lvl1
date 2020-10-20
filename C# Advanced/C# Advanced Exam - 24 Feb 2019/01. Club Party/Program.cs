using System;
using System.Collections.Generic;

namespace Club_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxCapacity = int.Parse(Console.ReadLine());
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Stack<string> reservationInfo = new Stack<string>();
            Queue<string> openHalls = new Queue<string>();

            for (int i = 0; i < input.Length; i++)
            {
                reservationInfo.Push(input[i]);
            }

            bool isHallOpen = false;
            List<int> reservations = new List<int>();
            int currHallCapacity = 0;

            while (reservationInfo.Count > 0)
            {
                bool isHall = false;
                string current = reservationInfo.Pop();

                for (int k = 0; k < current.Length; k++)
                {
                    if (char.IsLetter(current[k]))
                    {
                        isHall = true;
                        break;
                    }
                }

                if (isHall)
                {
                    openHalls.Enqueue(current);
                    isHallOpen = true;
                    continue;
                }

                if (isHallOpen)
                {
                    int currReservation = int.Parse(current);

                    if (currReservation <= maxCapacity)
                    {
                        currHallCapacity += currReservation;
                        if (currHallCapacity <= maxCapacity)
                        {
                            reservations.Add(currReservation);
                        }

                        if (currHallCapacity > maxCapacity)
                        {
                            currHallCapacity = 0;
                            Console.WriteLine($"{openHalls.Dequeue()} -> {String.Join(", ", reservations)}");
                            reservations.Clear();

                            if (openHalls.Count > 0)
                            {
                                currHallCapacity = currReservation;
                                reservations.Add(currReservation);
                            }
                            else
                            {
                                isHallOpen = false;
                            }

                        }
                    }
                }
            }
        }
    }
}
