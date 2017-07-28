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
    public interface ISoldier
    {
        /// <summary>Gets the id.</summary>
        string Id { get;  }

        /// <summary>Gets the first name.</summary>
        string FirstName { get;  }

        /// <summary>Gets the last name.</summary>
        string LastName { get; }
    }
}