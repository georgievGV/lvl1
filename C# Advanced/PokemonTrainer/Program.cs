using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Trainer> trainers = new List<Trainer>();

            while (input != "Tournament")
            {
                string[] info = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string trainerName = info[0];
                string pokemonName = info[1];
                string pokemonElement = info[2];
                int pokemonHealth = int.Parse(info[3]);
                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                if (trainers.Exists(x => x.Name == trainerName))
                {
                    Trainer current = trainers.FirstOrDefault(x => x.Name == trainerName);
                    current.Pokemons.Add(pokemon);
                }
                else
                {
                    Trainer trainer = new Trainer(trainerName);
                    trainer.Pokemons.Add(pokemon);
                    trainers.Add(trainer);
                }

                input = Console.ReadLine();
            }

            string command = Console.ReadLine();

            while (command != "End")
            {
                foreach (var trainer in trainers)
                {
                    bool isThereAny = false;
                    foreach (var pokemon in trainer.Pokemons)
                    {
                        if (pokemon.Element == command)
                        {
                            isThereAny = true;
                            trainer.Badges++;
                            break;
                        }
                    }

                    if (!isThereAny)
                    {
                        for (int i = 0; i < trainer.Pokemons.Count; i++)
                        {
                            trainer.Pokemons[i].Health -= 10;

                            if (trainer.Pokemons[i].Health <= 0)
                            {
                                trainer.Pokemons.RemoveAt(i);
                            }
                        }
                    }
                }

                command = Console.ReadLine();
            }

            List<Trainer> ordered = new List<Trainer>();
            int count = trainers.Count;

            for (int i = 0; i < count; i++)
            {
                int index = -1;
                int max = -1;

                for (int j = 0; j < trainers.Count; j++)
                {
                    if (trainers[j].Badges > max)
                    {
                        max = trainers[j].Badges;
                        index = j;
                    }
                }

                ordered.Add(trainers[index]);
                trainers.RemoveAt(index);
            }

            foreach (var trainer in ordered)
            {
                Console.WriteLine(trainer.ToString());
            }
        }
    }
}
