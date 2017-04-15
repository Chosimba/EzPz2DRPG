using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace EzPzRPG.classes
{
    public class Character
    {
        /// <summary>
        /// Name used to identify this entity.
        /// </summary>
        public string Name { get { return NameActual; } }
        /// <summary>
        /// Number representing the maximum base HP.
        /// </summary>
        public double MaxHealth { get { return MaxHealthActual; } }
        /// <summary>
        /// Number representing how much HP this entity has left.
        /// </summary>
        public double Health { get { return HealthAfterProcessing(); } }
        /// <summary>
        /// Number representing the maximum base MP.
        /// </summary>
        public double MaxResource { get { return MaxResourceActual; } }
        /// <summary>
        /// Number representing how much MP this entity has left.
        /// </summary>
        public double Resource { get; } = 0.0;
        /// <summary>
        /// Number representing this entities power level
        /// </summary>
        public int Level { get; } = 1;
        /// <summary>
        /// Bucket of Items that this entity is carrying
        /// </summary>
        public List<Item> Inventory { get; } = new List<Item>();
        /// <summary>
        /// Spells available for this entity to use
        /// </summary>
        public List<Spell> Skills { get; } = new List<Spell>();
        /// <summary>
        /// Boolean indicating if this entity is alive.
        /// </summary>
        public bool Dead { get { return HealthActual <= 0.0; } }
        /// <summary>
        /// List of boons (positive and negative) currently applied to this entity
        /// </summary>
        public List<Boon> Buffs { get; } = new List<Boon>();
        /// <summary>
        /// Number representing the cumulative total experience gained
        /// </summary>
        public double TotalEXP { get; }

        private string NameActual = "";
        private double MaxHealthActual = 0.0;
        private double HealthActual = 0.0;
        private double MaxResourceActual = 0.0;
        private double ResourceActual = 0.0;
        /// <summary>
        /// Reduces this character's current HP by a fixed amount.
        /// </summary>
        /// <param name="dmg">Amount of HP to be reduced by.</param>
        public void ApplyDamage(double dmg) {
            HealthActual -= dmg;
            Console.WriteLine($"{Name} took {dmg} damage! ({HealthActual}/{MaxHealth})");
            if (Dead)
                Console.WriteLine($"{Name} has died!");
        }
        public void ApplyBoon(Boon buff) {
            Buffs.Add(buff);
            Console.WriteLine($"{Name} has gained the boon '{buff.Name}'");
        }
        public void BuffStep() {
            double HealthGained = Buffs.FindAll(x => x.TargetAttribute == Boon.Target.Health && !x.IsNegative).Sum(x => x.Value);
            double HealthLost = Buffs.FindAll(x => x.TargetAttribute == Boon.Target.Health && x.IsNegative).Sum(x => x.Value);
            ApplyDamage(-HealthGained);
            ApplyDamage(HealthLost);
            Console.WriteLine($"Net gain: {HealthGained}\nNet lost:{HealthLost}");
            
        }
        public EQItem getEquippedItem(string slot) {
            return new EQItem();
        }
        public double getBonusFrom(string attr) {
            return 10.0;
        }
        public void Rename(string name) {
            NameActual = name;
        }
        public void LearnSpell(Spell spellToLearn) {
            Skills.Add(spellToLearn);
        }
        private double HealthAfterProcessing() {
            BuffStep();
            return HealthActual;
        }
        public bool Update() {
            // Remove buffs that are past their expiration date.
            Buffs.RemoveAll(x => x.Expired);
            Console.WriteLine($"Health on tick:{Health}");
            return false;
        }

        /// <summary>
        /// Create a character with the default character values.
        /// </summary>
        /// <param name="name">The desired name for this entity.</param>
        public Character(string name)
        {
            NameActual = name;
        }
        /// <summary>
        /// Create a character with a set Maximum Health and Resources.
        /// </summary>
        /// <param name="name">The desired name for this entity.</param>
        /// <param name="hp">Maximum Base Health value for this entity.</param>
        /// <param name="mp">Maximum Base Resource value for this entity.</param>
        public Character(string name, double hp, double mp) {
            NameActual = name;
            MaxHealthActual = hp;
            HealthActual = hp;
            MaxResourceActual = mp;
            Console.WriteLine($"Welcome to the world, {Name}!");
        }
        /// <summary>
        /// Create a character with a set Maximum HP, MP, and Level.
        /// 
        /// </summary>
        /// <param name="name">The desired name for this entity.</param>
        /// <param name="hp">Maximum Base Health value for this entity.</param>
        /// <param name="mp">Maximum Base Resource value for this entity.</param>
        /// <param name="lvl">Power level of this entity.</param>
        public Character(string name, double hp, double mp, int lvl)
        {
            NameActual = name;
            MaxHealthActual = hp;
            MaxResourceActual = mp;
            Level = lvl;
        }
        public Character(string name, double hp, double mp, int lvl, List<Item> items)
        {
            NameActual = name;
            MaxHealthActual = hp;
            MaxResourceActual = mp;
            Level = lvl;
            Inventory = items;
        }
        public Character(string name, double hp, double mp, int lvl, List<Item> items, List<Spell> spells)
        {
            NameActual = name;
            MaxHealthActual = hp;
            MaxResourceActual = mp;
            Level = lvl;
            Inventory = items;
            Skills = spells;
        }

    }
}
