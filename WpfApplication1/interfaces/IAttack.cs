using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzPzRPG.classes;

namespace EzPzRPG
{

    public class Fireball : IElementalAttack
    {
        // Internals
        private classes.Character _Owner;

        // IAttack Implementation
        public double Angle { get { return 0.0; } }
        public double Damage { get { return _Owner.getBonusFrom("intelligence") + 75.0; } }
        public double Range { get { return _Owner.getEquippedItem("mainhand").Range; } }
        public Character Source { get { return _Owner; } }
        public double Speed { get { return _Owner.getEquippedItem("mainhand").Speed; } }
        public Spell.Element Element { get { return Spell.Element.Fire; } }
        public double Force { get { return 0.0; } }

    }

    public class Stab : IAttack
    {
        // Internals
        private classes.Character _Owner;
        private double _Angle;
        private double _Force;

        // IAttack Implementation
        public double Angle { get { return _Angle; } }
        public double Damage { get { return _Owner.getBonusFrom("strength") + 75.0; } }
        public double Range { get { return _Owner.getEquippedItem("mainhand").Range; } }
        public Character Source { get { return _Owner; } }
        public double Speed { get { return _Owner.getEquippedItem("mainhand").Speed; } }
        public double Force { get { return _Force; } }

        // Constructors
        public Stab(classes.Character Owner, double Angle, double Force) {
            _Owner = Owner;
            _Angle = Angle;
            _Force = Force;
        }

    }

    public interface IElementalAttack : IAttack {
        classes.Spell.Element Element { get; }
    }
    public interface IAttack
    {
        /// <summary>
        /// Entity that spawned this attack.
        /// </summary>
        classes.Character Source { get; }
        /// <summary>
        /// Amount to reduce victim's health by.
        /// </summary>
        double Damage { get; }

        double Speed { get; }
        double Range { get; }
        double Angle { get; }
        double Force { get; }
    }
}
