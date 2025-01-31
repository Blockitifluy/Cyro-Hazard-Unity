using CH.Character.Damage.HediffDefs;

namespace CH.Character.Damage.Hediffs
{
    /// <summary>
    /// The base class of all Hediffs (excluding HediffDefs).
    /// </summary>
    public abstract class Hediff
    {
        /// <summary>
        /// This hediff applied to this body part.
        /// </summary>
        public CharacterBP AppliedTo;
        /// <summary>
        /// The hediff definition, this hediff is based on.
        /// </summary>
        public IDef HediffDef;

        public override string ToString()
        {
            return HediffDef.Name;
        }

        public abstract void OnUpdate();

        public abstract void OnApplied();

    }
}