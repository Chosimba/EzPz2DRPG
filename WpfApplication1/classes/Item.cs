using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzPzRPG.classes
{
    public class EQItem { public double Range { get; } public double Speed { get; } public EQItem() { Range = 60; Speed = 44; } }
    public class Item
    {
        public enum Kind { Equippable, Usable }
        public string Name { get; } = "Unknown Item";
        public string Description { get; } = "";
        public double MoneyValue { get; } = 0.0;
        public Currency.Kind MoneyType { get; } = Currency.Kind.Gold;
        public Kind ItemType { get; }
        public bool Unique { get; } = false;
        public bool Stackable { get; } = true;
        public List<Spell> OnUse { get; } = new List<Spell>();
        public Character Owner { get; } = null;

        public Item() {

        }
    }
}
