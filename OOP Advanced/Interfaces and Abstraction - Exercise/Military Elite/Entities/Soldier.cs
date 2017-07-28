// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISoldier.cs" company="softuni">
//   exercise task
// </copyright>
// <summary>
//   Defines the ISoldier type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Military_Elite
{
    /// <summary>The Soldier interface.</summary>
    public abstract class Soldier:ISoldier
    {
        public Soldier(string iD, string firstName, string lastName)
        {
            this.Id = iD;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        /// <summary>Gets the id.</summary>
        public string Id { get; }

        /// <summary>Gets the first name.</summary>
        public string FirstName { get; }

        /// <summary>Gets the last name.</summary>
        public string LastName { get; }

        public override string ToString()
        {
            return $"Name: {this.FirstName + " " +this.LastName} Id: {this.Id}";
        }
    }
}