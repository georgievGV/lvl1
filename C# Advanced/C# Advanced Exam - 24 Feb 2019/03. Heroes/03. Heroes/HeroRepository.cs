using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes
{
    public class HeroRepository
    {
        private List<Hero> heroList = new List<Hero>();

        public int Count 
        {
            get
            {
                return heroList.Count;
            } 
        }

        public void Add(Hero hero)
        {
            heroList.Add(hero);
        }

        public void Remove(string name)
        {
            Hero unwanted = heroList.FirstOrDefault(x => x.Name == name);
            heroList.Remove(unwanted);
        }

        public Hero GetHeroWithHighestStrength()
        {
            List<Hero> orderedByStrength = heroList.OrderByDescending(x => x.Item.Strength)
                .ToList();
            Hero highestStrengthHero = orderedByStrength[0];

            return highestStrengthHero;
        }

        public Hero GetHeroWithHighestAbility()
        {
            List<Hero> orderedByAbility = heroList.OrderByDescending(x => x.Item.Ability)
                .ToList();
            Hero highestAbilityHero = orderedByAbility[0];

            return highestAbilityHero;
        }

        public Hero GetHeroWithHighestIntelligence()
        {
            List<Hero> orderedByIntelligence = heroList.OrderByDescending(x => x.Item.Intelligence)
                .ToList();
            Hero highestIntelligenceHero = orderedByIntelligence[0];

            return highestIntelligenceHero;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            foreach (Hero hero in heroList)
            {
                result.AppendLine(hero.ToString());
            }
            return result.ToString();
        }
    }
}
