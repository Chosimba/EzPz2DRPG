using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzPzRPG.classes;
namespace EzPzRPG.Archetypes
{
    public class LearnedSkill { }
    public class Thief : ICharacterClass
    {
        public string Title { get { return "Theif"; } }
        public Weapon.Kind[] AllowedWeapons = { Weapon.Kind.Dagger, Weapon.Kind.OneHandedSword, Weapon.Kind.OneHandedAxe };
        public double BaseHealth { get { return 75.0; } }
        public double BaseResource { get { return 75.0; } }
        public int BaseStrength { get { return 10; } }
        public int BaseDexterity { get { return 10; } }
        public int BaseIntelligence { get { return 10; } }
        public int BaseLuck { get { return 20; } }
        public int Level { get { return lvl; } }
        public LearnedSkill[] Skills { get { return new LearnedSkill[] { }; } }

        private int lvl = 1;

        public void LevelUp() {
            lvl += 1;
        }

        public Thief() {

        }

    }


    public interface ICharacterClass {
        string Title { get; }
        double BaseHealth { get; }
        double BaseResource { get; }
        int BaseStrength { get; }
        int BaseDexterity { get; }
        int BaseIntelligence { get; }
        int BaseLuck { get; }
        int Level { get; }
        LearnedSkill[] Skills {get;}
        void LevelUp();
    }


}
